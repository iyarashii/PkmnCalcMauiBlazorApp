// Copyright (c) 2023 iyarashii @ https://github.com/iyarashii 
// Licensed under the GNU General Public License v3.0.

namespace PkmnCalcMauiBlazor.Pages.Logic
{
    public class DiamondPearlPokedex : DexType
    {
        public override string Name => "Diamond / Pearl";

        public override string Url => "https://www.serebii.net/pokedex-dp/";

        public override string Regex => "(?<=<option value=\"/pokedex-dp/.+?\">)(\\d.*)";

        public override string FileName => "pokedex-dp.txt";
    }
}
