// Copyright (c) 2023 iyarashii @ https://github.com/iyarashii 
// Licensed under the GNU General Public License v3.0.

namespace PkmnCalcMauiBlazor.Pages.Logic.Attackdex
{
    public class XyAttackdex : DexType
    {
        public override string Name => "X / Y";

        public override string Url => "https://www.serebii.net/attackdex-xy/";

        public override string Regex => "(?<=<option value=\"/attackdex-xy/.+?\">)(.*)(?=</option>)";

        public override string FileName => "attackdex-xy.txt";
    }
}
