// Copyright (c) 2023 iyarashii @ https://github.com/iyarashii 
// Licensed under the GNU General Public License v3.0.

using PkmnCalcMauiBlazor.Pages.Logic;

namespace PkmnCalcMauiBlazor.Pages
{
    public partial class Attackdex : BasePage
    {
        private static IDexType selectedAttackdexType = new ScarletVioletPokedex();
#if DEBUG && WINDOWS
        private static string pathToData = $@"G:\repos\PkmnCalcMauiBlazor\PokemonCalcMauiBlazor\Data\{SelectedAttackdexType.FileName}";
#else
        private static string pathToPokemonNames = Path.Combine(FileSystem.Current.AppDataDirectory, SelectedAttackdexType.FileName);
#endif
        private readonly List<IDexType> attackdexTypes = new()
        {
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
                pathToPokemonNames = Path.Combine(FileSystem.Current.AppDataDirectory, SelectedAttackdexType.FileName);
#endif
            }
        }
    }
}
