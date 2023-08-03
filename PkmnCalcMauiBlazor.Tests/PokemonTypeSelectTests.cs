using MudBlazor.Services;
using MudBlazor;
using PokemonTypeLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using PkmnCalcMauiBlazor.Pages;
using Xunit;

namespace PkmnCalcMauiBlazor.Tests
{
	public class PokemonTypeSelectTests : TestContext
	{
		[Fact]
		public void VerifyMudSelectParams()
		{
			// Arrange
			Services.AddMudServices();
			JSInterop.SetupVoid("mudPopover.initialize", "mudblazor-main-content", 0);
			JSInterop.SetupVoid("mudKeyInterceptor.connect", _ => true);
			string labelText = "Test";
			var pokemonTypeSelect = RenderComponent<PokemonTypeSelect>(p => p
																	.Add(x => x.Label, labelText)
																	.Add(x => x.PkmnTypeList, PkmnTypeFactory.GeneratePkmnTypeList()));
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

		[Fact]
		public void VerifySelection()
		{
			Services.AddMudServices();
			JSInterop.SetupVoid("mudPopover.initialize", "mudblazor-main-content", 0);
			JSInterop.SetupVoid("mudKeyInterceptor.connect", _ => true);
			string labelText = "Test";
			var pokemonTypeSelect = RenderComponent<PokemonTypeSelect>(p => p
																	.Add(x => x.Label, labelText)
																	.Add(x => x.PkmnTypeList, PkmnTypeFactory.GeneratePkmnTypeList()));
			var cut = pokemonTypeSelect.FindComponent<MudSelect<string>>();
			pokemonTypeSelect.SetParametersAndRender(p => p.Add(x => x.SelectedTypeName, PkmnTypeFactory.CreateDragonPkmnType().TypeName));

			Assert.Equal(PkmnTypeFactory.CreateDragonPkmnType().TypeName, cut.Instance.Value);
			Assert.Contains(PkmnTypeFactory.CreateDragonPkmnType().TypeColor, cut.Instance.Style);
		}
	}
}
