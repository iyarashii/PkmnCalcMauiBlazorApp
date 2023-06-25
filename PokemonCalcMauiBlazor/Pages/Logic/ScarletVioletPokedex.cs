// Copyright (c) 2022 iyarashii @ https://github.com/iyarashii 
// Licensed under the GNU General Public License v3.0.

namespace PkmnCalcMauiBlazor.Pages.Logic
{
    public class ScarletVioletPokedex : DexType
    {
        public override string Name => "Scarlet / Violet";

        public override string Url => "https://www.serebii.net/pokedex-sv/";

        public override string Regex => "(?<=<option value=\"/pokedex-sv/.+?/\">\\d+? )(.*)(?=</option>)";

        public override string FileName => "pokedex-sv.txt";
    }
}
