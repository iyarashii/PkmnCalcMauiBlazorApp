// Copyright (c) 2023 iyarashii @ https://github.com/iyarashii 
// Licensed under the GNU General Public License v3.0.

namespace PkmnCalcMauiBlazor.Pages.Logic
{
    public class XyPokedex : DexType
    {
        public override string Name => "X / Y";

        public override string Url => "https://www.serebii.net/pokedex-xy/";

        public override string Regex => "(?<=<option value=\"/pokedex-xy/)(\\d.*)(?=\\s)"; // TODO: try to fix the positive look ahead

        public override string FileName => "pokedex-xy.txt";
    }
}
