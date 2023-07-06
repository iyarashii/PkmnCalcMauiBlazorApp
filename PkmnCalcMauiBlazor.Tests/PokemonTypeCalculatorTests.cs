using Microsoft.AspNetCore.Components.Web;
using MudBlazor.Services;
using PkmnCalcMauiBlazor.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

			// Assert
			Assert.Equal("(none)", primaryTypeSelect.Instance.SelectedTypeName);
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

            // Assert
            Assert.Equal("(none)", secondaryTypeSelect.Instance.SelectedTypeName);
        }
    }
}
