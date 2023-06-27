// Copyright (c) 2023 iyarashii @ https://github.com/iyarashii 
// Licensed under the GNU General Public License v3.0.

namespace PkmnCalcMauiBlazor.Pages.Logic
{
    public class SwordShieldPokedex : DexType
    {
        public override string Name => "Sword / Shield";

        public override string Url => "https://www.serebii.net/pokedex-swsh/";

        public override string Regex => "(?<=<option value=\"/pokedex-swsh/.+?/\">)(.*)(?=</option>)";

        public override string FileName => "pokedex-swsh.txt";
    }
}
