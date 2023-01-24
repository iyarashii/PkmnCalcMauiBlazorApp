﻿// Copyright (c) 2022 iyarashii @ https://github.com/iyarashii 
// Licensed under the GNU General Public License v3.0.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PkmnCalcMauiBlazor.Pages.Logic
{
    public class RedBluePokedex : PokedexType
    {
        public override string Name => "Red/Blue Pokédex";

        public override string Url => "https://www.serebii.net/pokedex/";

        public override string Regex => throw new NotImplementedException();

        public override string FileName => "pokedex.txt";
    }
}