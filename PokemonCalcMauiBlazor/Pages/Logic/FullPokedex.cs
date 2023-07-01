// Copyright (c) 2022 iyarashii @ https://github.com/iyarashii 
// Licensed under the GNU General Public License v3.0.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PkmnCalcMauiBlazor.Pages.Logic
{
    public class FullPokedex : DexType
    {
        public override string Name => "Full";

        public override string Url => "https://www.serebii.net/pokemon/";

        public override string Regex => "(?<=<option value=\"/pokemon/.+?/\">)(.*)(?=</option>)";

        public override string FileName => "pokedex-full.txt";
    }
}
