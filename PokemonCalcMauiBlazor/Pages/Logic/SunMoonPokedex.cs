﻿// Copyright (c) 2023 iyarashii @ https://github.com/iyarashii 
// Licensed under the GNU General Public License v3.0.

namespace PkmnCalcMauiBlazor.Pages.Logic
{
    public class SunMoonPokedex : DexType
    {
        public override string Name => "Sun / Moon";

        public override string Url => "https://www.serebii.net/pokedex-sm/";

        public override string Regex => "(?<=<option value=\"/pokedex-sm/)(\\d.*)(?=\\s)"; // TODO: try to make better regex

        public override string FileName => "pokedex-sm.txt";
    }
}
