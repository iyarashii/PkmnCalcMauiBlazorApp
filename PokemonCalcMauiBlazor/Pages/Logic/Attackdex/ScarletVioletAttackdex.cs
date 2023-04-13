// Copyright (c) 2023 iyarashii @ https://github.com/iyarashii 
// Licensed under the GNU General Public License v3.0.

namespace PkmnCalcMauiBlazor.Pages.Logic.Attackdex
{
    public class ScarletVioletAttackdex : DexType
    {
        public override string Name => "Scarlet / Violet";

        public override string Url => "https://www.serebii.net/attackdex-sv/";

        public override string Regex => "(?<=<option value=\"/attackdex-sv/.+?\">)(.*)(?=</option>)";

        public override string FileName => "attackdex-sv.txt";
    }
}
