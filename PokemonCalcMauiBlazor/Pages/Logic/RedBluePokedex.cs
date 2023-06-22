// Copyright (c) 2022 iyarashii @ https://github.com/iyarashii 
// Licensed under the GNU General Public License v3.0.

namespace PkmnCalcMauiBlazor.Pages.Logic
{
    public class RedBluePokedex : DexType
    {
        public override string Name => "Red / Blue";

        public override string Url => "https://www.serebii.net/pokedex/";

        public override string Regex => "(?<=<option value=\"/pokedex/.+?\">)(\\d.*)(?=</option>)";

        public override string FileName => "pokedex.txt";
    }
}
