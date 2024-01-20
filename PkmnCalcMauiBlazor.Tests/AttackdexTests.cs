using MudBlazor.Services;
using PkmnCalcMauiBlazor.Pages;
using System;
using System.Collections.Generic;
using System.IO.Abstractions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

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
            var result = Attackdex.SearchForAttackName("").Result;
            // Assert
            Assert.NotNull(cut);
            Assert.Empty(result);
        }
    }
}
