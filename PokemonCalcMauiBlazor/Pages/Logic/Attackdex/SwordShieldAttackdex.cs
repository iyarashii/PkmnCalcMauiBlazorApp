// Copyright (c) 2023 iyarashii @ https://github.com/iyarashii 
// Licensed under the GNU General Public License v3.0.

namespace PkmnCalcMauiBlazor.Pages.Logic.Attackdex
{
    public class SwordShieldAttackdex : DexType
    {
        public override string Name => "Sword / Shield";

        public override string Url => "https://www.serebii.net/attackdex-swsh/";

        public override string Regex => "(?<=<option value=\"/attackdex-swsh/.+?\">)(.*)(?=</option>)";

        public override string FileName => "attackdex-swsh.txt";
    }
}
