// Copyright (c) 2022 iyarashii @ https://github.com/iyarashii 
// Licensed under the GNU General Public License v3.0.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PkmnCalcMauiBlazor.Pages.Logic
{
    public class FullPokedex : PokedexType
    {
        public override string Name => "Full Pokédex";

        public override string Url => "https://www.serebii.net/pokemon/";

        public override string Regex => throw new NotImplementedException();

        public override string FileName => throw new NotImplementedException();
    }
}
