﻿using MudBlazor;
using MudBlazor.Services;
using NSubstitute;
using PkmnCalcMauiBlazor.Pages;
using PkmnCalcMauiBlazor.Pages.Components;
using System.IO;
using System.IO.Abstractions;
using System.Threading.Tasks;

namespace PkmnCalcMauiBlazor.Tests
{
    public class PokedexTests : TestContext
    {
        public PokedexTests()
        {
            // Mud services test setup
            Services.AddMudServices();
            Services.AddSingleton<IFileSystem, FileSystem>();
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
            Assert.True(File.Exists(Pokedex.pathToPokemonNames));
        }

        [Fact]
        public void SavePokemonNames_DisplaysProgress()
        {
            // Arrange
            var cut = RenderComponent<Pokedex>();
            Assert.False(cut.Instance.progressVisible);
            Assert.Equal(0.0, cut.Instance.SaveProgress);
            // Act
            var savePokemonNamesTask = cut.InvokeAsync(() => cut.Instance.SavePokemonNames());
            while (savePokemonNamesTask.Status != TaskStatus.RanToCompletion)
            {
                if (cut.Instance.progressVisible && cut.Instance.SaveProgress != 0.0)
                {
                    Assert.True(cut.Instance.SaveProgress > 0.0);
                    break;
                }
            }
            savePokemonNamesTask.Wait();
            // Assert
            Assert.NotNull(cut);
            Assert.False(cut.Instance.progressVisible);
            Assert.Equal(0.0, cut.Instance.SaveProgress);
        }

        [Fact]
        public void SearchForPokemonName_GivenEmptyString_ReturnsEmptyArray()
        {
            // Arrange
            var cut = RenderComponent<Pokedex>();
            // Act
            var result = cut.Instance.SearchForPokemonName("").Result;
            // Assert
            Assert.NotNull(cut);
            Assert.Empty(result);
        }

        [Fact]
        public void SearchForPokemonName_GivenNotEmptyString_ReturnsMatchingNames()
        {
            // Arrange
            var fileSystemMock = Substitute.For<FileSystem>();
            fileSystemMock.File.ReadAllLinesAsync(Arg.Any<string>()).Returns(["pikachu", "pichu", "raichu" ]);
            Services.AddSingleton<IFileSystem>(fileSystemMock);
            var cut = RenderComponent<Pokedex>();
            // Act
            var result = cut.Instance.SearchForPokemonName("pi").Result;
            // Assert
            Assert.NotNull(cut);
            Assert.Contains("pikachu", result);
            Assert.Contains("pichu", result);
        }

        [Fact]
        public void OpenSavePokemonDataDialog_DialogClickedYes_ReturnsTrue()
        {
            // Arrange
            var dialogServiceMock = Substitute.For<IDialogService>();
            var dialogRefMock = Substitute.For<IDialogReference>();
            dialogRefMock.GetReturnValueAsync<bool?>().Returns(true);
            dialogServiceMock.Show<SavePokemonDataDialog>(Arg.Any<string>(), Arg.Any<DialogOptions>()).Returns(dialogRefMock);
            Services.AddSingleton(dialogServiceMock);
            var cut = RenderComponent<Pokedex>();
            // Act
            var result = cut.InvokeAsync(() => cut.Instance.OpenSavePokemonDataDialog()).Result;
            // Assert
            Assert.True(result);
        }

        [Fact]
        public void OpenSavePokemonDataDialog_DialogClickedNo_ReturnsFalse()
        {
            // Arrange
            var dialogServiceMock = Substitute.For<IDialogService>();
            var dialogRefMock = Substitute.For<IDialogReference>();
            dialogRefMock.GetReturnValueAsync<bool?>().Returns(false);
            dialogServiceMock.Show<SavePokemonDataDialog>(Arg.Any<string>(), Arg.Any<DialogOptions>()).Returns(dialogRefMock);
            Services.AddSingleton(dialogServiceMock);
            var cut = RenderComponent<Pokedex>();
            // Act
            var result = cut.InvokeAsync(() => cut.Instance.OpenSavePokemonDataDialog()).Result;
            // Assert
            Assert.False(result);
        }
    }
}