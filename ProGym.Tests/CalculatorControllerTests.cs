using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProGym.Controllers;
using ProGym.ViewModels;
using System.Web.Mvc;

namespace ProGym.Tests
{
    [TestClass]
    public class CalculatorControllerTests
    {
        [TestMethod]
        public void Test_TypeOfReturnedDataFromCalculateBMIActionMethod()
        {
            var controller = new CalculatorsController();
            var data = new CalculatorsViewModel()
            {
                Height = 166,
                Weight = 54
            };

            var result = controller.CalculateBMI(data);

            Assert.IsInstanceOfType(result, typeof(JsonResult));
        }

        [TestMethod]
        public void Test_CorrectDataFromCalculateBMIActionMethod()
        {
            var controller = new CalculatorsController();
            var data = new CalculatorsViewModel()
            {
                Height = 170,
                Weight = 54
            };

            var result = controller.CalculateBMI(data);
            var deserializedResult = (CalculatorsViewModel)result.Data;

            Assert.AreEqual(18, 6851211072664, deserializedResult.ResultBMI);
            Assert.AreEqual("Prawidłowa masa ciała", deserializedResult.Range);
        }


        [TestMethod]
        [DataRow('K', 56.1, 58, 59.4)]
        [DataRow('M', 59.4, 62, 62.7)]
        public void Test_CorrectDataFromCalculatePerfectWeightActionMethod(char gender, double resultB, double resultL, double resultP)
        {
            var controller = new CalculatorsController();
            var data = new CalculatorsViewModel()
            {
                Height = 166,
                Gender = gender
            };

            var result = controller.CalculatePerfectWeight(data);
            var deserializedResult = (CalculatorsViewModel)result.Data;

            Assert.AreEqual(deserializedResult.PerfectWeightBroc, resultB);
            Assert.AreEqual(deserializedResult.PerfectWeightLorentz, resultL);
            Assert.AreEqual(deserializedResult.PerfectWeightPotton, resultP);
        }
    }
}
