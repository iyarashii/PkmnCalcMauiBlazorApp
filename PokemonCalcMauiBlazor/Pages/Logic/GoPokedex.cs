﻿// Copyright (c) 2023 iyarashii @ https://github.com/iyarashii 
// Licensed under the GNU General Public License v3.0.

namespace PkmnCalcMauiBlazor.Pages.Logic
{
    public class GoPokedex : DexType
    {
        public override string Name => "GO";

        public override string Url => "https://www.serebii.net/pokemongo/pokemon/";

        public override string Regex => "(?<=<option value=\"/pokemongo/pokemon/.+?\">)(\\d.*)(?=</option>)";

        public override string FileName => "pokedex-go.txt";
    }
}
