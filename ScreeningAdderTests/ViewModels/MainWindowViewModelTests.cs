using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScreeningAdder.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreeningAdder.ViewModels.Tests
{
    [TestClass()]
    public class MainWindowViewModelTests
    {
        [TestMethod()]
        public void SetAdditionTest()
        {
            MainWindowViewModel vm = new MainWindowViewModel();
            vm.FirstText = "2";
            vm.SecondText = "22";
            vm.SetAddition();
            Assert.AreEqual("24", vm.OutcomeText, false, $"Addition is incorrect, expected 24, found {vm.OutcomeText} in OutcomeText");
        }
    }
}