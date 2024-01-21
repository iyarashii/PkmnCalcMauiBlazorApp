using MudBlazor.Services;
using NSubstitute;
using PkmnCalcMauiBlazor.Pages;
using System.IO.Abstractions;

namespace PkmnCalcMauiBlazor.Tests
{
    public class AttackdexTests : TestContext
    {
        public AttackdexTests()
        {
            // Mud services test setup
            Services.AddMudServices();
            Services.AddSingleton<IFileSystem, FileSystem>();
            JSInterop.SetupVoid("mudPopover.initialize", "mudblazor-main-content", 0);
            JSInterop.SetupVoid("mudKeyInterceptor.connect", _ => true);
        }
        [Fact]
        public void SearchForAttackName_GivenEmptyName_ReturnEmptyArray()
        {
            // Arrange
            var cut = RenderComponent<Attackdex>();
            // Act
            var result = cut.Instance.SearchForAttackName("").Result;
            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public void SearchForAttackName_GivenNotEmptyName_ReturnsMatchingNames()
        {
            // Arrange
            var fileSystemMock = Substitute.For<FileSystem>();
            fileSystemMock.File.ReadAllLinesAsync(Arg.Any<string>()).Returns(["thunderbolt", "thunder", "thunder fang", "THUNDER CAGE"]);
            Services.AddSingleton<IFileSystem>(fileSystemMock);
            var cut = RenderComponent<Attackdex>();
            // Act
            var result = cut.Instance.SearchForAttackName("thunder").Result;
            // Assert
            Assert.NotNull(cut);
            Assert.Contains("thunderbolt", result);
            Assert.Contains("thunder", result);
            Assert.Contains("thunder fang", result);
            Assert.Contains("THUNDER CAGE", result);
        }
    }
}
