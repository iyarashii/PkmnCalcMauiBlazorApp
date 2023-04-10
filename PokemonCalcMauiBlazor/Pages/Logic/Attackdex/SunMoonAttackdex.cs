// Copyright (c) 2023 iyarashii @ https://github.com/iyarashii 
// Licensed under the GNU General Public License v3.0.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PkmnCalcMauiBlazor.Pages.Logic.Attackdex
{
    public class SunMoonAttackdex : DexType
    {
        public override string Name => "Sun / Moon";

        public override string Url => "https://www.serebii.net/attackdex-sm/";

        public override string Regex => "(?<=<option value=\"/attackdex-sm/.+?\">)(.*)(?=</option>)";

        public override string FileName => "attackdex-sm.txt";
    }
}
