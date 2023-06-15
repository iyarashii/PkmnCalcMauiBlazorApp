// Copyright (c) 2022 iyarashii @ https://github.com/iyarashii 
// Licensed under the GNU General Public License v3.0.

namespace PkmnCalcMauiBlazor.Pages.Logic
{
    public class GoldSilverPokedex : DexType
    {
        public override string Name => "Gold / Silver";

        public override string Url => "https://www.serebii.net/pokedex-gs/";

        public override string Regex => "(?<=<option value=\"/pokedex-gs/.+?\">)(\\d.*)";

        public override string FileName => "pokedex-gs.txt";
    }
}
