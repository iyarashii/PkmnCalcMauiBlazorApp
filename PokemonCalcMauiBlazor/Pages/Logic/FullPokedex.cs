﻿// Copyright (c) 2022 iyarashii @ https://github.com/iyarashii 
// Licensed under the GNU General Public License v3.0.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PkmnCalcMauiBlazor.Pages.Logic
{
    public class FullPokedex : IPokedexType
    {
        public string Name => "Full Pokédex";

        public string Url => "https://www.serebii.net/pokemon/";

        public string Regex => throw new NotImplementedException();
    }
}
