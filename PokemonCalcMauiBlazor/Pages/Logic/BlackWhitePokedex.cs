// Copyright (c) 2023 iyarashii @ https://github.com/iyarashii 
// Licensed under the GNU General Public License v3.0.

namespace PkmnCalcMauiBlazor.Pages.Logic
{
    public class BlackWhitePokedex : DexType
    {
        public override string Name => "Black / White";

        public override string Url => "https://www.serebii.net/pokedex-bw/";

        public override string Regex => "(?<=<option value=\"/pokedex-bw/.+?\">)(\\d.*)";

        public override string FileName => "pokedex-bw.txt";
    }
}
