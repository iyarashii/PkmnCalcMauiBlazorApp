// Copyright (c) 2023 iyarashii @ https://github.com/iyarashii 
// Licensed under the GNU General Public License v3.0.

namespace PkmnCalcMauiBlazor.Pages.Logic.Attackdex
{
    public class GoldSilverCrystalAttackdex : DexType
    {
        public override string Name => "Gold/Silver/Crystal";

        public override string Url => "https://www.serebii.net/attackdex-gs/";

        public override string Regex => "(?<=<option value=\"/attackdex-gs/.+?\">)(.*)(?=</option>)";

        public override string FileName => "attackdex-gs.txt";
    }
}
