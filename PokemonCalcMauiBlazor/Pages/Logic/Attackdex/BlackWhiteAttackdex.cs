// Copyright (c) 2023 iyarashii @ https://github.com/iyarashii 
// Licensed under the GNU General Public License v3.0.

namespace PkmnCalcMauiBlazor.Pages.Logic.Attackdex
{
    public class BlackWhiteAttackdex : DexType
    {
        public override string Name => "Black/White";

        public override string Url => "https://www.serebii.net/attackdex-bw/";

        public override string Regex => "(?<=<option value=\"/attackdex-bw/.+?\">)(.*)(?=</option>)";

        public override string FileName => "attackdex-bw.txt";
    }
}
