// Copyright (c) 2023 iyarashii @ https://github.com/iyarashii 
// Licensed under the GNU General Public License v3.0.

using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokemonTypeLibrary.Models;

namespace PkmnCalcMauiBlazor.Pages
{
    public partial class PokemonTypeSelect : ComponentBase
    {
        #if ANDROID
            private int maxHeight = 600;
        #else
            private int maxHeight = -1;
        #endif
        private string _selectedTypeName;
        public static string emptyTypeName = PkmnTypeFactory.CreateEmptyPkmnType().TypeName;
        [Parameter]
        public string Label { get; set; }
        [Parameter]
        public string SelectedTypeColor { get; set; }
        [Parameter]
        public string SelectedTypeName
        {
            get => _selectedTypeName;
            set
            {
                if (_selectedTypeName == value) return;
                _selectedTypeName = value;
                SelectedTypeNameChanged.InvokeAsync(value);
            }
        }
        [Parameter]
        public EventCallback<string> SelectedTypeNameChanged { get; set; }
        [Parameter]
        public string Selected2ndTypeName { get; set; }
        [Parameter]
        public List<IPkmnType> PkmnTypeList { get; set; }
    }
}
