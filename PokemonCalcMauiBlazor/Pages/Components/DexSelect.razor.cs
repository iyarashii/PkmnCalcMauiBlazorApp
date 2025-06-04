// Copyright (c) 2024 iyarashii @ https://github.com/iyarashii 
// Licensed under the GNU General Public License v3.0.

using Microsoft.AspNetCore.Components;
using PkmnCalcMauiBlazor.Pages.Logic;

namespace PkmnCalcMauiBlazor.Pages.Components
{
    public partial class DexSelect : ComponentBase
    {
        private IDexType _selectedDexType;
        private string _dexSource;

        [Parameter]
        public string Label { get; set; }

        [Parameter]
        public List<IDexType> DexTypes { get; set; }

        [Parameter]
        public IDexType SelectedDexType
        {
            get => _selectedDexType;
            set
            {
                if (_selectedDexType == value) return;
                _selectedDexType = value;
                DexSource = _selectedDexType.Url;
                SelectedDexTypeChanged.InvokeAsync(value);
            }
        }

        [Parameter]
        public string DexSource
        {
            get => _dexSource;
            set
            {
                if (_dexSource == value) return;
                _dexSource = value;
                DexSourceChanged.InvokeAsync(value);
            }
        }

        [Parameter]
        public EventCallback<string> DexSourceChanged { get; set; }

        [Parameter]
        public EventCallback<IDexType> SelectedDexTypeChanged { get; set; }
    }
}
