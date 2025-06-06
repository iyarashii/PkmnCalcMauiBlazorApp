﻿using MudBlazor.Services;
using MudBlazor;
using PokemonTypeLibrary.Models;
using System.Collections.Generic;
using System.Linq;
using PkmnCalcMauiBlazor.Pages.Components;

namespace PkmnCalcMauiBlazor.Tests
{
	public class PokemonTypeSelectTests : TestContext
	{
        public PokemonTypeSelectTests()
        {
			// Mud services test setup
			Services.AddMudServices();
			JSInterop.SetupVoid("mudPopover.initialize", "mudblazor-main-content", 0);
			JSInterop.SetupVoid("mudKeyInterceptor.connect", _ => true);
		}

        [Fact]
		public void VerifyMudSelectParams()
		{
			// Arrange
			string labelText = "Test";
			var pokemonTypeSelect = RenderComponent<PokemonTypeSelect>(p => p.Add(x => x.Label, labelText));
			var cut = pokemonTypeSelect.FindComponent<MudSelect<string>>();

			// Assert
			Assert.True(cut.Instance.Dense);
			Assert.Equal(-1, cut.Instance.MaxHeight);
			Assert.Equal(labelText, cut.Instance.Label);
			Assert.Equal(Origin.BottomCenter, cut.Instance.AnchorOrigin);
			Assert.Equal($"-webkit-text-fill-color:{PkmnTypeFactory.CreateEmptyPkmnType().TypeColor}", cut.Instance.Style);
			Assert.Equal(19, cut.FindComponents<MudSelectItem<string>>().Count);
			Assert.Equal(pokemonTypeSelect.Instance.PkmnTypeList.Select(x => x.TypeName).ToHashSet(),
						cut.FindComponents<MudSelectItem<string>>().Select(x => x.Instance.Value).ToHashSet());
			Assert.True(cut.FindComponents<MudSelectItem<string>>().All(x => x.Instance.Disabled is false));
			Assert.Equal(19, cut.FindComponents<MudSelectItem<string>>().DistinctBy(x => x.Instance.Style).Count());
		}

		public static IEnumerable<object[]> PreparePokemonTypeData()
		{
			yield return new object[] { PkmnTypeFactory.GeneratePkmnTypeList() };
		}

		[Theory]
		[MemberData(nameof(PreparePokemonTypeData))]
		public void VerifySelection(List<IPkmnType> pkmnTypes)
		{
			string labelText = "Test";
			var pokemonTypeSelect = RenderComponent<PokemonTypeSelect>(p => p.Add(x => x.Label, labelText));
			var cut = pokemonTypeSelect.FindComponent<MudSelect<string>>();
            foreach (var type in pkmnTypes)
            {
				pokemonTypeSelect.SetParametersAndRender(p => p.Add(x => x.SelectedTypeName, type.TypeName));
				Assert.Equal(type.TypeName, cut.Instance.Value);
				Assert.Contains(type.TypeColor, cut.Instance.Style);
			}
		}
	}
}
