using MudBlazor.Services;
using MudBlazor;
using PokemonTypeLibrary.Models;
using System.Collections.Generic;
using System.Linq;
using PkmnCalcMauiBlazor.Pages;
using System;
using Xunit;

namespace PkmnCalcMauiBlazor.Tests
{
	public class PokedexTests : TestContext
    {
		public PokedexTests()
		{
			// Mud services test setup
			Services.AddMudServices();
			JSInterop.SetupVoid("mudPopover.initialize", "mudblazor-main-content", 0);
			JSInterop.SetupVoid("mudKeyInterceptor.connect", _ => true);
		}

		[Fact]
		public void GetPokedexPageName_PokemonNameWithWhitespace_ReturnsLowercaseWithoutSpace()
		{
            // Arrange
            string testName = "test Pokemon NAME";
			Pokedex.PokemonName = testName;
			var cut = RenderComponent<Pokedex>();
			// Act
			var result = Pokedex.GetPokedexPageName();
            // Assert
            Assert.NotNull(cut);
            Assert.Equal("testpokemonname", result);
		}
	}
}
