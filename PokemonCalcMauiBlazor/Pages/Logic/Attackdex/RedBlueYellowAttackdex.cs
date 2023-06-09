// Copyright (c) 2023 iyarashii @ https://github.com/iyarashii 
// Licensed under the GNU General Public License v3.0.

namespace PkmnCalcMauiBlazor.Pages.Logic.Attackdex
{
    public class RedBlueYellowAttackdex : DexType
    {
        public override string Name => "Red / Blue / Yellow";

        public override string Url => "https://www.serebii.net/attackdex-rby/";

        public override string Regex => "(?<=<option value=\"/attackdex-rby/.+?\">)(.*)(?=</option>)";

        public override string FileName => "attackdex-rby.txt";
    }
}
