// Copyright (c) 2023 iyarashii @ https://github.com/iyarashii 
// Licensed under the GNU General Public License v3.0.

using Microsoft.AspNetCore.Components;
using PkmnCalcMauiBlazor.Pages.Logic;

namespace PkmnCalcMauiBlazor.Pages
{
    public partial class PokedexSelect : ComponentBase
    {
        private IPokedexType _selectedPokedexType;
        private string _pokedexSource;
        private readonly List<IPokedexType> pokedexTypes = new()
        {
            new FullPokedex(),
            new RedBluePokedex(),
            new GoldSilverPokedex(),
            new RubySapphirePokedex(),
            new DiamondPearlPokedex(),
            new BlackWhitePokedex(),
            new XyPokedex(),
            new SunMoonPokedex(),
            new LetsGoPokedex(),
            new SwordShieldPokedex(),
            new BdspPokedex(),
            new LegendsPokedex(),
            new GoPokedex(),
            new ScarletVioletPokedex()
        };

        [Parameter]
        public string Label { get; set; }

        [Parameter]
        public IPokedexType SelectedPokedexType
        {
            get => _selectedPokedexType;
            set
            {
                if (_selectedPokedexType == value) return;
                _selectedPokedexType = value;
                PokedexSource = _selectedPokedexType.Url;
                SelectedPokedexTypeChanged.InvokeAsync(value);
            }
        }

        [Parameter]
        public string PokedexSource
        {
            get => _pokedexSource;
            set
            {
                if (_pokedexSource == value) return;
                _pokedexSource = value;
                PokedexSourceChanged.InvokeAsync(value);
            }
        }

        [Parameter]
        public EventCallback<string> PokedexSourceChanged { get; set; }

        [Parameter]
        public EventCallback<IPokedexType> SelectedPokedexTypeChanged { get; set; }
    }
}
