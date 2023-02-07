// Copyright (c) 2023 iyarashii @ https://github.com/iyarashii 
// Licensed under the GNU General Public License v3.0.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PkmnCalcMauiBlazor.Pages.Logic
{
    public class SunMoonPokedex : PokedexType
    {
        public override string Name => "Sun & Moon Pokédex";

        public override string Url => "https://www.serebii.net/pokedex-sm/";

        public override string Regex => "(?<=<option value=\"/pokedex-sm/)(\\d.*)(?=\\s)"; // TODO: try to make better regex

        public override string FileName => "pokedex-sm.txt";
    }
}
