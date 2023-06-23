// Copyright (c) 2023 iyarashii @ https://github.com/iyarashii 
// Licensed under the GNU General Public License v3.0.

namespace PkmnCalcMauiBlazor.Pages.Logic
{
    public class RubySapphirePokedex : DexType
    {
        public override string Name => "Ruby / Sapphire";

        public override string Url => "https://www.serebii.net/pokedex-rs/";

        public override string Regex => "(?<=<option value=\"/pokedex-rs/.+?\">)(\\d.*)";

        public override string FileName => "pokedex-rs.txt";
    }
}
