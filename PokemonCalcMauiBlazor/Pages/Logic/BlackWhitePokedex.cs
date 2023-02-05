﻿// Copyright (c) 2023 iyarashii @ https://github.com/iyarashii 
// Licensed under the GNU General Public License v3.0.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PkmnCalcMauiBlazor.Pages.Logic
{
    public class BlackWhitePokedex : PokedexType
    {
        public override string Name => "Black/White Pokédex";

        public override string Url => "https://www.serebii.net/pokedex-bw/";

        public override string Regex => "(?<=<option value=\"/pokedex-bw/.+?\">)(\\d.*)";

        public override string FileName => "pokedex-bw.txt";
    }
}
