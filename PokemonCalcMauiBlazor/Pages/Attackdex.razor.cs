// Copyright (c) 2023 iyarashii @ https://github.com/iyarashii 
// Licensed under the GNU General Public License v3.0.

using MudBlazor;
using PkmnCalcMauiBlazor.Pages.Components;
using PkmnCalcMauiBlazor.Pages.Logic;
using PkmnCalcMauiBlazor.Pages.Logic.Attackdex;
using System.Text.RegularExpressions;

namespace PkmnCalcMauiBlazor.Pages
{
    public partial class Attackdex : BasePage
    {
        private bool progressVisible = false;
        private static IDexType selectedAttackdexType = new ScarletVioletAttackdex();
#if (DEBUG && WINDOWS) || UNIT_TEST
        private static string pathToData = $@"F:\repos\PkmnCalcMauiBlazor\PokemonCalcMauiBlazor\Data\{SelectedAttackdexType.FileName}";
#else
        private static string pathToData = Path.Combine(FileSystem.Current.AppDataDirectory, SelectedAttackdexType.FileName);
#endif
        private readonly List<IDexType> attackdexTypes =
        [
            new RedBlueYellowAttackdex(),
            new GoldSilverCrystalAttackdex(),
            new Gen3Attackdex(),
            new DiamondPearlAttackdex(),
            new BlackWhiteAttackdex(),
            new XyAttackdex(),
            new SunMoonAttackdex(),
            new SwordShieldAttackdex(),
            new ScarletVioletAttackdex(),
        ];
        public static string AttackdexSource { get; set; } = selectedAttackdexType.Url;
        public static IDexType SelectedAttackdexType
        {
            get => selectedAttackdexType;
            set
            {
                selectedAttackdexType = value;
#if (DEBUG && WINDOWS) || UNIT_TEST
                pathToData = $@"F:\repos\PkmnCalcMauiBlazor\PokemonCalcMauiBlazor\Data\{SelectedAttackdexType.FileName}";
#else
                pathToData = Path.Combine(FileSystem.Current.AppDataDirectory, SelectedAttackdexType.FileName);
#endif
            }
        }
        public double SaveProgress { get; set; } = 0.0;
        public static string AttackName { get; set; } = "";
        public async Task<IEnumerable<string>> SearchForAttackName(string attackName)
        {
            return await SearchForMatchingNamesInFile(attackName, FileSystemAbstraction, pathToData);
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

        public static string GetPageName() => 
            string.IsNullOrEmpty(AttackName) ? null : $"{AttackName?.Replace(" ", "").ToLower()}.shtml";
        public async Task SaveNamesFromSerebii()
        {
            progressVisible = true;
            StateHasChanged();
            using (HttpClient client = new())
            {
                string downloadString = await client.GetStringAsync(AttackdexSource);
                var nameMatches = Regex.Matches(downloadString, SelectedAttackdexType.Regex);
                HashSet<string> namesToSave = [];
                void formatAndSaveName(Match nameMatch) => 
                    namesToSave.Add(OptionClosingTag().Replace(nameMatch.Value.Trim(), ""));
                var progress = 0.0;
                foreach (Match nameMatch in nameMatches.Cast<Match>())
                {
                    formatAndSaveName(nameMatch);
                    progress++;
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
