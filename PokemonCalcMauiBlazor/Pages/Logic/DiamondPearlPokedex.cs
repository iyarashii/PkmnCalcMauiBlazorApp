// Copyright (c) 2023 iyarashii @ https://github.com/iyarashii 
// Licensed under the GNU General Public License v3.0.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PkmnCalcMauiBlazor.Pages.Logic
{
    public class DiamondPearlPokedex : DexType
    {
        public override string Name => "Diamond/Pearl Pokédex";

        public override string Url => "https://www.serebii.net/pokedex-dp/";

        public override string Regex => "(?<=<option value=\"/pokedex-dp/.+?\">)(\\d.*)";

        public override string FileName => "pokedex-dp.txt";
    }
}
