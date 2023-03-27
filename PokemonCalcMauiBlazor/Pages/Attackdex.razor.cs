﻿// Copyright (c) 2023 iyarashii @ https://github.com/iyarashii 
// Licensed under the GNU General Public License v3.0.

using MudBlazor;
using PkmnCalcMauiBlazor.Pages.Logic;
using PkmnCalcMauiBlazor.Pages.Logic.Attackdex;
using System.Text.RegularExpressions;

namespace PkmnCalcMauiBlazor.Pages
{
    public partial class Attackdex : BasePage
    {
        private bool progressVisible = false;
        private static IDexType selectedAttackdexType = new RedBlueYellowAttackdex();
#if DEBUG && WINDOWS
        private static string pathToData = $@"G:\repos\PkmnCalcMauiBlazor\PokemonCalcMauiBlazor\Data\{SelectedAttackdexType.FileName}";
#else
        private static string pathToData = Path.Combine(FileSystem.Current.AppDataDirectory, SelectedAttackdexType.FileName);
#endif
        private readonly List<IDexType> attackdexTypes = new()
        {
            new RedBlueYellowAttackdex(),
        };
        public static string AttackdexSource { get; set; } = "https://www.serebii.net/pokedex-sv/";
        public static IDexType SelectedAttackdexType
        {
            get => selectedAttackdexType;
            set
            {
                selectedAttackdexType = value;
#if DEBUG && WINDOWS
                pathToData = $@"G:\repos\PkmnCalcMauiBlazor\PokemonCalcMauiBlazor\Data\{SelectedAttackdexType.FileName}";
#else
                pathToData = Path.Combine(FileSystem.Current.AppDataDirectory, SelectedAttackdexType.FileName);
#endif
            }
        }
        public double SaveProgress { get; set; } = 0.0;
        public static string AttackName { get; set; } = "";
        private async Task<IEnumerable<string>> SearchForAttackName(string attackName)
        {
            // if text is null or empty, don't return values (drop-down will not open)
            if (string.IsNullOrEmpty(attackName))
                return Array.Empty<string>();
            var names = await File.ReadAllLinesAsync(pathToData);
            return names.Where(x => x.Contains(attackName, StringComparison.InvariantCultureIgnoreCase));
        }
        private async Task OpenSavePokemonDataDialog()
        {
            var options = new DialogOptions { CloseOnEscapeKey = true, NoHeader = true };
            var dialogRef = DialogService.Show<SavePokemonDataDialog>("", options);
            if (await dialogRef.GetReturnValueAsync<bool?>() ?? false)
            {
                await SaveNamesFromSerebii();
            }
        }
        private static string SerebiiAttackdexSource
        {
            get => $"{AttackdexSource}{GetPageName()}";
        }
        // returns pokemon number or pokemon name depending on the pokedex for example "25.shtml" or "pikachu"
        public static string GetPageName() =>
                                                    ((!string.IsNullOrEmpty(AttackName)
                                                    && char.IsDigit(AttackName[0]))
                                                    ? $"{AttackName[..3]}.shtml"
                                                    : AttackName?.Replace(" ", "").ToLower());
        public async Task SaveNamesFromSerebii()
        {
            using (HttpClient client = new())
            {
                string downloadString = await client.GetStringAsync(AttackdexSource);
                var nameMatches = Regex.Matches(downloadString, SelectedAttackdexType.Regex);
                HashSet<string> namesToSave = new();
                Action<Match> formatAndSaveName = SelectedAttackdexType switch
                {
                    RedBlueYellowAttackdex => nameMatch =>
                           namesToSave.Add(Regex.Replace(nameMatch.Value.Trim(), "</option>", "")),
                    _ => nameMatch =>
                            namesToSave.Add(Regex.Replace(nameMatch.Value, "\\d+? ", "").Trim()),
                };
                var progress = 0.0;
                foreach (Match nameMatch in nameMatches.Cast<Match>())
                {
                    formatAndSaveName(nameMatch);
                    progress++;
                    progressVisible = true;
                    SaveProgress = progress / nameMatches.Count * 100;
                    StateHasChanged();
                }
                File.WriteAllLines(pathToData, namesToSave);
            }
            await Task.Delay(3000);
            progressVisible = false;
            SaveProgress = 0.0;
        }
    }
}
