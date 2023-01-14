// Copyright (c) 2022 iyarashii @ https://github.com/iyarashii 
// Licensed under the GNU General Public License v3.0.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PkmnCalcMauiBlazor.Pages.Logic
{
    public abstract class PokedexType : IPokedexType
    {
        public abstract string Name { get; }
        public abstract string Url { get; }
        public abstract string Regex { get; }
        public abstract string FileName { get; }

        // Note: this is important so the MudSelect can compare pokedex types
        public override bool Equals(object o)
        {
            var other = o as PokedexType;
            return other?.Name == Name;
        }
        // Note: this is important too!
        public override int GetHashCode() => Name?.GetHashCode() ?? 0;

        // display PokedexType correctly in MudSelect
        public override string ToString() => Name;
    }
}
