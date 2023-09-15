using MudBlazor.Services;
using PkmnCalcMauiBlazor.Pages;
using PokemonTypeLibrary.Models;
using System.Linq;

namespace PkmnCalcMauiBlazor.Tests
{
	public class PokemonTypeCalculatorTests : TestContext
	{
		[Fact]
		public void VerifyPrimaryTypeDefaultSelection()
		{
            // Arrange
            Services.AddMudServices();
			JSInterop.SetupVoid("mudPopover.initialize", "mudblazor-main-content", 0);
			JSInterop.SetupVoid("mudKeyInterceptor.connect", _ => true);
			var cut = RenderComponent<PokemonTypeCalculator>();
			var primaryTypeSelect = cut.FindComponent<PokemonTypeSelect>();
            var expectedType = PkmnTypeFactory.CreateEmptyPkmnType();

			// Assert
			Assert.Equal(expectedType.TypeName, primaryTypeSelect.Instance.SelectedTypeName);
			Assert.Equal(expectedType.TypeColor, primaryTypeSelect.Instance.SelectedTypeColor);
		}

        [Fact]
        public void VerifySecondaryTypeDefaultSelection()
        {
            // Arrange
            Services.AddMudServices();
            JSInterop.SetupVoid("mudPopover.initialize", "mudblazor-main-content", 0);
            JSInterop.SetupVoid("mudKeyInterceptor.connect", _ => true);
            var cut = RenderComponent<PokemonTypeCalculator>();
            var secondaryTypeSelect = cut.FindComponents<PokemonTypeSelect>().First(x => x.Instance.Label == "Secondary Type");
            var expectedType = PkmnTypeFactory.CreateEmptyPkmnType();

            // Assert
            Assert.Equal(expectedType.TypeName, secondaryTypeSelect.Instance.SelectedTypeName);
            Assert.Equal(expectedType.TypeColor, secondaryTypeSelect.Instance.SelectedTypeColor);
        }
    }
}
