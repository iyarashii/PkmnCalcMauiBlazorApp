// Copyright (c) 2023 iyarashii @ https://github.com/iyarashii 
// Licensed under the GNU General Public License v3.0.

using Microsoft.AspNetCore.Components;
using PokemonTypeLibrary.Models;

namespace PkmnCalcMauiBlazor.Pages
{
    public partial class PokemonTypeCalculator : ComponentBase
    {
        public static string EmptyTypeName { get; } = PkmnTypeFactory.CreateEmptyPkmnType().TypeName;
        public List<IPkmnType> PrimaryPkmnTypeList { get; set; } = PkmnTypeFactory.GeneratePkmnTypeList();
        public List<IPkmnType> SecondaryPkmnTypeList { get; set; } = PkmnTypeFactory.GeneratePkmnTypeList();
        private string _selectedPrimaryTypeName = EmptyTypeName;
        public string SelectedPrimaryTypeName
        {
            get => _selectedPrimaryTypeName;
            set
            {
                _selectedPrimaryTypeName = value;
                Calculate();
            }
        }

        private string _selectedSecondaryTypeName = EmptyTypeName;

        public string SelectedSecondaryTypeName
        {
            get => _selectedSecondaryTypeName;
            set
            {
                _selectedSecondaryTypeName = value;
                Calculate();
            }
        }

        public List<IPkmnType> PkmnTypeList { get; set; } = PkmnTypeFactory.GeneratePkmnTypeList();

        public string SelectedPrimaryTypeColor { get => SelectedPrimaryType.TypeColor; }

        public string SelectedSecondaryTypeColor { get => SelectedSecondaryType.TypeColor; }

        public IPkmnType SelectedPrimaryType
        {
            get => PrimaryPkmnTypeList.Where(type => type.TypeName == SelectedPrimaryTypeName).Single();
        }
        public IPkmnType SelectedSecondaryType
        {
            get => SecondaryPkmnTypeList.Where(type => type.TypeName == SelectedSecondaryTypeName).Single();
        }

        public void Calculate()
        {
            if (SelectedPrimaryTypeName == EmptyTypeName && SelectedSecondaryTypeName == EmptyTypeName)
                return;

            // calculate damage multiplier for each pkmn type in the list
            foreach (var pkmnType in PkmnTypeList)
            {
                pkmnType.DmgMultiplier = pkmnType.CalculateDmgMultiplier(SelectedPrimaryType, SelectedSecondaryType);
            }

            // sort by damage multiplier from highest to lowest
            PkmnTypeList.Sort((x, y) => y.DmgMultiplier.CompareTo(x.DmgMultiplier));
        }
    }
}
