﻿// Copyright (c) 2024 iyarashii @ https://github.com/iyarashii 
// Licensed under the GNU General Public License v3.0.

using Microsoft.AspNetCore.Components.Web;
using MudBlazor;
using PkmnCalcMauiBlazor.Pages.Components;
using PkmnCalcMauiBlazor.Pages.Logic;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
[assembly: InternalsVisibleTo("PkmnCalcMauiBlazor.Tests")]

namespace PkmnCalcMauiBlazor.Pages
{
    public partial class Pokedex : BasePage
    {
        private readonly List<IDexType> pokedexTypes =
        [
            new FullPokedex(),
            new RedBluePokedex(),
            new GoldSilverPokedex(),
            new RubySapphirePokedex(),
            new DiamondPearlPokedex(),
            new BlackWhitePokedex(),
            new XyPokedex(),
            new SunMoonPokedex(),
            new LetsGoPokedex(),
            new SwordShieldPokedex(),
            new BdspPokedex(),
            new LegendsPokedex(),
            new GoPokedex(),
            new ScarletVioletPokedex()
        ];
        private static string SerebiiPokedexSource
        {
            get => $"{PokedexSource}{GetPokedexPageName()}";
        }
        internal bool progressVisible = false;
        private static IDexType selectedPokedexType = new ScarletVioletPokedex();
        public static string PokedexSource { get; set; } = "https://www.serebii.net/pokedex-sv/";
        public static string PokemonName { get; set; } = "";
        public double SaveProgress { get; set; } = 0.0;
#if (DEBUG && WINDOWS) || UNIT_TEST
        internal static string pathToPokemonNames = $@"F:\repos\PkmnCalcMauiBlazor\PokemonCalcMauiBlazor\Data\{SelectedPokedexType.FileName}";
#else
        internal static string pathToPokemonNames = Path.Combine(FileSystem.Current.AppDataDirectory, SelectedPokedexType.FileName);
#endif
        public static IDexType SelectedPokedexType
        {
            get => selectedPokedexType;
            set
            {
                selectedPokedexType = value;
#if (DEBUG && WINDOWS) || UNIT_TEST
                pathToPokemonNames = $@"F:\repos\PkmnCalcMauiBlazor\PokemonCalcMauiBlazor\Data\{SelectedPokedexType.FileName}";
#else
                pathToPokemonNames = Path.Combine(FileSystem.Current.AppDataDirectory, SelectedPokedexType.FileName);
#endif
            }
        }

        // returns pokemon number or pokemon name depending on the pokedex for example "25.shtml" or "pikachu"
        public static string GetPokedexPageName() =>
                                                    ((!string.IsNullOrEmpty(PokemonName)
                                                    && char.IsDigit(PokemonName[0]))
                                                    ? $"{PokemonName[..3]}.shtml"
                                                    : PokemonName?.Replace(" ", "").ToLower());
        internal async Task<IEnumerable<string>> SearchForPokemonName(string pokemonName)
        {
            return await SearchForMatchingNamesInFile(pokemonName, FileSystemAbstraction, pathToPokemonNames);
        }

        public void HandleRightClick(MouseEventArgs args)
        {
            if (args.Button == 2)
            {
                Snackbar.Add("Copied to the clipboard!", Severity.Success);
                Clipboard.SetTextAsync(SerebiiPokedexSource);
            }
        }
        public async Task SavePokemonNames()
        {
            progressVisible = true;
            StateHasChanged();
            using (HttpClient client = new())
            {
                string downloadString = await client.GetStringAsync(PokedexSource);
                if (selectedPokedexType is SwordShieldPokedex)
                    downloadString = downloadString.Split("</SELECT> </FORM></td></tr></table><option value=\"/pokedex-swsh/")[0];
                var pokemonNameMatches = Regex.Matches(downloadString, SelectedPokedexType.Regex);
                HashSet<string> pokemonNamesToSave = [];
                Action<Match> formatAndSavePokemonName = selectedPokedexType switch
                {
                    XyPokedex or SunMoonPokedex => pokemonNameMatch =>
                                            {
                                                var pokemonNumber = pokemonNameMatch.Value[..3];
                                                if (pokemonNumber == pokemonNameMatch.Value.Substring(11, 3))
                                                {
                                                    var pokemonName = OptionClosingTag().Replace(pokemonNameMatch.Value, "").Remove(0, 14).Trim();
                                                    pokemonNamesToSave.Add($"{pokemonNumber} {pokemonName}");
                                                }
                                            },
                    RedBluePokedex or GoldSilverPokedex or RubySapphirePokedex
                        or DiamondPearlPokedex or BlackWhitePokedex or SwordShieldPokedex or GoPokedex => pokemonNameMatch =>
                           pokemonNamesToSave.Add(OptionClosingTag().Replace(pokemonNameMatch.Value.Trim(), "")),
                    _ => pokemonNameMatch =>
                            pokemonNamesToSave.Add(DigitsFollowedBySpace().Replace(pokemonNameMatch.Value, "").Trim()),
                };
                var progress = 0.0;
                foreach (Match pokemonNameMatch in pokemonNameMatches.Cast<Match>())
                {
                    formatAndSavePokemonName(pokemonNameMatch);
                    progress++;
                    SaveProgress = progress / pokemonNameMatches.Count * 100;
                    StateHasChanged();
                }
                File.WriteAllLines(pathToPokemonNames, pokemonNamesToSave);
            }
            await Task.Delay(3000);
            progressVisible = false;
            SaveProgress = 0.0;
        }

        public async Task<bool> OpenSavePokemonDataDialog()
        {
            var options = new DialogOptions { CloseOnEscapeKey = true, NoHeader = true };
            var dialogRef = DialogService.Show<SavePokemonDataDialog>("", options);
            if (await dialogRef.GetReturnValueAsync<bool?>() ?? false)
            {
                await SavePokemonNames();
                return true;
            }
            return false;
        }

        [GeneratedRegex("\\d+? ")]
        private static partial Regex DigitsFollowedBySpace();
    }
}
