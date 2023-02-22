// Copyright (c) 2023 iyarashii @ https://github.com/iyarashii 
// Licensed under the GNU General Public License v3.0.

using Microsoft.AspNetCore.Components;

namespace PkmnCalcMauiBlazor.Pages
{
    public partial class SavePokemonNamesProgress : ComponentBase
    {
        private double _value;
        [Parameter]
        public double Value
        {
            get => _value;
            set
            {
                if (_value == value) return;
                _value = value;
                if (_disposed)
                {
                    return;
                }
                StateHasChanged();
            }
        }
        bool _disposed;
        public void Dispose() => _disposed = true;
    }
}
