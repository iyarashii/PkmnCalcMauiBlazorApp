// Copyright (c) 2023 iyarashii @ https://github.com/iyarashii 
// Licensed under the GNU General Public License v3.0.

using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Text.RegularExpressions;
using PkmnCalcMauiBlazor.Pages.Logic;

namespace PkmnCalcMauiBlazor.Pages
{
    public partial class Pokedex : ComponentBase
    {
        private bool progressVisible = false;
        private static IPokedexType selectedPokedexType = new ScarletVioletPokedex();
        public string PokedexSource { get; set; } = "https://www.serebii.net/pokedex-sv/";
        public string PokemonName { get; set; } = "";
        public double SaveProgress { get; set; } = 0.0;
#if DEBUG && WINDOWS
        private static string pathToPokemonNames = $@"G:\repos\PkmnCalcMauiBlazor\PokemonCalcMauiBlazor\Data\{SelectedPokedexType.FileName}";
#else
        private static string pathToPokemonNames = Path.Combine(FileSystem.Current.AppDataDirectory, SelectedPokedexType.FileName);
#endif
        public static IPokedexType SelectedPokedexType
        {
            get => selectedPokedexType;
            set
            {
                selectedPokedexType = value;
#if DEBUG && WINDOWS
                pathToPokemonNames = $@"G:\repos\PkmnCalcMauiBlazor\PokemonCalcMauiBlazor\Data\{SelectedPokedexType.FileName}";
#else
                pathToPokemonNames = Path.Combine(FileSystem.Current.AppDataDirectory, SelectedPokedexType.FileName);
#endif
            }
        }
        private async Task<IEnumerable<string>> SearchForPokemonName(string pokemonName)
        {
            // if text is null or empty, don't return values (drop-down will not open)
            if (string.IsNullOrEmpty(pokemonName))
                return Array.Empty<string>();
            var names = await File.ReadAllLinesAsync(pathToPokemonNames);
            return names.Where(x => x.Contains(pokemonName, StringComparison.InvariantCultureIgnoreCase));
        }

        public async Task SavePokemonNames()
        {
            using (HttpClient client = new())
            {
                string downloadString = await client.GetStringAsync(PokedexSource);
                if (selectedPokedexType is SwordShieldPokedex)
                    downloadString = downloadString.Split("</SELECT> </FORM></td></tr></table><option value=\"/pokedex-swsh/")[0];
                var pokemonNameMatches = Regex.Matches(downloadString, SelectedPokedexType.Regex);
                HashSet<string> pokemonNamesToSave = new();
                Action<Match> formatAndSavePokemonName;
                switch (selectedPokedexType)
                {
                    case XyPokedex or SunMoonPokedex:
                        formatAndSavePokemonName = pokemonNameMatch =>
                        {
                            var pokemonNumber = pokemonNameMatch.Value.Substring(0, 3);
                            if (pokemonNumber == pokemonNameMatch.Value.Substring(11, 3))
                            {
                                var pokemonName = Regex.Replace(pokemonNameMatch.Value, "</option>", "").Remove(0, 14).Trim();
                                pokemonNamesToSave.Add($"{pokemonNumber} {pokemonName}");
                            }
                        };
                        break;
                    case RedBluePokedex or GoldSilverPokedex or RubySapphirePokedex
                        or DiamondPearlPokedex or BlackWhitePokedex or SwordShieldPokedex or GoPokedex:
                        formatAndSavePokemonName = pokemonNameMatch =>
                           pokemonNamesToSave.Add(Regex.Replace(pokemonNameMatch.Value.Trim(), "</option>", ""));
                        break;
                    default:
                        formatAndSavePokemonName = pokemonNameMatch =>
                            pokemonNamesToSave.Add(Regex.Replace(pokemonNameMatch.Value, "\\d+? ", "").Trim());
                        break;
                }
                var progress = 0.0;
                foreach (Match pokemonNameMatch in pokemonNameMatches)
                {
                    formatAndSavePokemonName(pokemonNameMatch);
                    progress++;
                    progressVisible = true;
                    SaveProgress = progress / pokemonNameMatches.Count * 100;
                    StateHasChanged();
                }
                File.WriteAllLines(pathToPokemonNames, pokemonNamesToSave);
            }
            await Task.Delay(3000);
            progressVisible = false;
            SaveProgress = 0.0;
        }

        private async Task OpenSavePokemonDataDialog()
        {
            var options = new DialogOptions { CloseOnEscapeKey = true, NoHeader = true };
            var dialogRef = DialogService.Show<SavePokemonDataDialog>("", options);
            if (await dialogRef.GetReturnValueAsync<bool?>() ?? false)
            {
                await SavePokemonNames();
            }
        }

        public static bool IsDebug()
        {
#if DEBUG
            return true;
#else
            return false;
#endif
        }
    }
}
