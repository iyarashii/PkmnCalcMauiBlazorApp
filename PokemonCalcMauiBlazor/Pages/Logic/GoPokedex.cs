// Copyright (c) 2023 iyarashii @ https://github.com/iyarashii 
// Licensed under the GNU General Public License v3.0.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PkmnCalcMauiBlazor.Pages.Logic
{
    public class GoPokedex : PokedexType
    {
        public override string Name => "GO Pokédex";

        public override string Url => "https://www.serebii.net/pokemongo/pokemon/";

        public override string Regex => "(?<=<option value=\"/pokemongo/pokemon/.+?\">)(\\d.*)(?=</option>)";

        public override string FileName => "pokedex-go.txt";
    }
}
