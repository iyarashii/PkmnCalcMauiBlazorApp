// Copyright (c) 2023 iyarashii @ https://github.com/iyarashii 
// Licensed under the GNU General Public License v3.0.

namespace PkmnCalcMauiBlazor.Pages.Logic.Attackdex
{
    public class Gen3Attackdex : DexType
    {
        public override string Name => "Ruby / Sapphire / Emerald";

        public override string Url => "https://www.serebii.net/attackdex/";

        public override string Regex => "(?<=<option value=\"/attackdex/.+?\">)(.*)";

        public override string FileName => "attackdex-rse.txt";
    }
}
