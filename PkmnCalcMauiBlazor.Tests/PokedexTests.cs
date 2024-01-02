using MudBlazor.Services;
using PkmnCalcMauiBlazor.Pages;
using System.IO;

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

		[Fact]
		public void GetPokedexPageName_PokemonNameStartsWithDigit_Returns3DigitsWithShtml()
		{
            // Arrange
            string testName = "393";
            Pokedex.PokemonName = testName;
            var cut = RenderComponent<Pokedex>();
            // Act
            var result = Pokedex.GetPokedexPageName();
            // Assert
            Assert.NotNull(cut);
            Assert.Equal("393.shtml", result);
        }

        [Fact]
        public void SavePokemonNames_CreatesFileWithPokemonNames()
        {
            // Arrange
            var cut = RenderComponent<Pokedex>();

            // Act
            cut.InvokeAsync(() => cut.Instance.SavePokemonNames()).Wait();

            // Assert
            Assert.NotNull(cut);
            //Assert.False(cut.Instance.progressVisible);
            //Assert.Equal(0.0, cut.Instance.SaveProgress);
            Assert.True(File.Exists(Pokedex.pathToPokemonNames));
        }

    }
}
