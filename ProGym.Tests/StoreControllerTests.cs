using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ProGym.Controllers;
using ProGym.DAL;
using ProGym.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace ProGym.Tests
{
    [TestClass]
    public class StoreControllerTests
    {
        [TestMethod]
        public void TestIndexActionMethod()
        {
            var data = new List<Product>()
            {
                new Product()
                {ProductID = 1,
                Name = "GASPARI NUTRITION BCAA 6000 - 180tabs",
                ProducerName = "Gaspari Nutrition",
                Price =89,
                ShortDescription ="Zażywając BCAA 6000 dostarczysz do organizmu bardzo duże dawki aminokwasów rozgałęzionych. " +
                "Dzięki niemu zbudujesz suchą masę mięśniową i znacznie szybciej się zregenerujesz.",
                Description ="4:1:1 to stosunek aminokwasów rozgałęzionych znajdujących się w tym suplemencie. 4000mg leucyny dostarczanej w każdej porcji przyspieszy Twoją biosyntezę i regenerację. " +
                "Wyjątkowy jest również sposób uwalniania aminokwasów zawartych w BCAA 6000. " +
                "Następuje on stopniowo gwarantując Ci ich stały dopływ prowadząc do wzrostu suchej masy.",
                Ingredients = "fosforan dwuwapniowy, kwas stearynowy, celuloza mikrokrystaliczna, stearynian magnezu, kroskarmeloza sodowa, dwutlenek krzemu, karboksymetyloceluloza sodowa, dekstryna. Zawiera soję.",
                Parameters = "Wartości odżywcze	W porcji: Witamina B6 3mg, L-Leucyna 4000mg, L-Walina 1000mg,L-Izoleucyna 1000mg",
                DateAdded = new DateTime(2021,9,25), PhotoFileName ="BCAA6000.jpg", CategoryID =1
            },
            new Product() {ProductID = 2,
                Name = "EXTRIFIT BCAA 2:1:1 Pure - 240caps",
                ProducerName = "EXTRIFIT",
                Price =69,
                ShortDescription ="Kompletny zestaw aminokwasów rozgałęzionych BCAA, które mają bardzo silne działanie antykataboliczne. " +
                "Dzięki nim możesz zapomnieć o rozpadzie białek, gdyż w ogóle nie ma prawa to nastąpić.",
                Description ="BCAA Pure 2:1:1 firmy Extrifit jest niezwykle skutecznym suplementem, który oprócz tego, że gwarantuje walkę z katabolizmem to dodatkowo przyczynia się do przyrostu beztłuszczowej masy mięśniowej. " +
                "Mięśnie są prawidłowo odżywione i zregenerowane, " +
                "dzięki czemu znajdują się w nieustannym procesie anabolicznym. Każda osoba regularnie trenująca może być spokojna, gdyż BCAA Pure 2:1:1 gwarantuje znakomite rezultaty już w krótkim czasie!",
                Ingredients = "L-Leucyna, L-Izoleucyna, L-Walina, żelatynowa kapsułka, stearynian magnezu (substancja przeciwzbrylająca)",
                Parameters = "Wartości odżywcze	W porcji: L-Leucyna 1000 mg, L-Izoleucyna 500 mg, Walina 500 mg, Suma BCAA 2000 mg",
                DateAdded = new DateTime(2021,9,25), PhotoFileName ="BCAA-2-1-1-Pure-240caps.jpg", CategoryID =1
            }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Product>>();
            mockSet.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<StoreContext>();
            mockContext.Setup(c => c.Products).Returns(mockSet.Object);

            var controller = new StoreController(mockContext.Object);
            string all = "Wszystkie";
            var result = controller.Index(all) as ViewResult;
            var viewModel = result.ViewData.Model as IEnumerable<Product>;

            Assert.IsTrue(viewModel.Count() == 2);
        }

        [TestMethod]
        public void TestDetailsActionMethod()
        {
            var products = new List<Product>
            {
                new Product (){ProductID = 1,
                Name = "GASPARI NUTRITION BCAA 6000 - 180tabs",
                ProducerName = "Gaspari Nutrition",
                Price =89,
                ShortDescription ="Zażywając BCAA 6000 dostarczysz do organizmu bardzo duże dawki aminokwasów rozgałęzionych. " +
                "Dzięki niemu zbudujesz suchą masę mięśniową i znacznie szybciej się zregenerujesz.",
                Description ="4:1:1 to stosunek aminokwasów rozgałęzionych znajdujących się w tym suplemencie. 4000mg leucyny dostarczanej w każdej porcji przyspieszy Twoją biosyntezę i regenerację. " +
                "Wyjątkowy jest również sposób uwalniania aminokwasów zawartych w BCAA 6000. " +
                "Następuje on stopniowo gwarantując Ci ich stały dopływ prowadząc do wzrostu suchej masy.",
                Ingredients = "fosforan dwuwapniowy, kwas stearynowy, celuloza mikrokrystaliczna, stearynian magnezu, kroskarmeloza sodowa, dwutlenek krzemu, karboksymetyloceluloza sodowa, dekstryna. Zawiera soję.",
                Parameters = "Wartości odżywcze	W porcji: Witamina B6 3mg, L-Leucyna 4000mg, L-Walina 1000mg,L-Izoleucyna 1000mg",
                DateAdded = new DateTime(2021,9,25), PhotoFileName ="BCAA6000.jpg", CategoryID =1
            },
            new Product() {ProductID = 2,
                Name = "EXTRIFIT BCAA 2:1:1 Pure - 240caps",
                ProducerName = "EXTRIFIT",
                Price =69,
                ShortDescription ="Kompletny zestaw aminokwasów rozgałęzionych BCAA, które mają bardzo silne działanie antykataboliczne. " +
                "Dzięki nim możesz zapomnieć o rozpadzie białek, gdyż w ogóle nie ma prawa to nastąpić.",
                Description ="BCAA Pure 2:1:1 firmy Extrifit jest niezwykle skutecznym suplementem, który oprócz tego, że gwarantuje walkę z katabolizmem to dodatkowo przyczynia się do przyrostu beztłuszczowej masy mięśniowej. " +
                "Mięśnie są prawidłowo odżywione i zregenerowane, " +
                "dzięki czemu znajdują się w nieustannym procesie anabolicznym. Każda osoba regularnie trenująca może być spokojna, gdyż BCAA Pure 2:1:1 gwarantuje znakomite rezultaty już w krótkim czasie!",
                Ingredients = "L-Leucyna, L-Izoleucyna, L-Walina, żelatynowa kapsułka, stearynian magnezu (substancja przeciwzbrylająca)",
                Parameters = "Wartości odżywcze	W porcji: L-Leucyna 1000 mg, L-Izoleucyna 500 mg, Walina 500 mg, Suma BCAA 2000 mg",
                DateAdded = new DateTime(2021,9,25), PhotoFileName ="BCAA-2-1-1-Pure-240caps.jpg", CategoryID =1
            }
            }.AsQueryable();

            var id = 2;
            var mockSet = new Mock<DbSet<Product>>();
            mockSet.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(products.Provider);
            mockSet.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(products.Expression);
            mockSet.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(products.ElementType);
            mockSet.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(products.GetEnumerator());
            mockSet.Setup(m => m.Find(It.IsAny<int>())).Returns(products.Single(p => p.ProductID == id));

            var mockContext = new Mock<StoreContext>();
            mockContext.Setup(p => p.Products).Returns(mockSet.Object);
            var controller = new StoreController(mockContext.Object);

            var product = new Product()
            {
                ProductID = 2,
                Name = "EXTRIFIT BCAA 2:1:1 Pure - 240caps",
                ProducerName = "EXTRIFIT",
                Price = 69,
                ShortDescription = "Kompletny zestaw aminokwasów rozgałęzionych BCAA, które mają bardzo silne działanie antykataboliczne. " +
                "Dzięki nim możesz zapomnieć o rozpadzie białek, gdyż w ogóle nie ma prawa to nastąpić.",
                Description = "BCAA Pure 2:1:1 firmy Extrifit jest niezwykle skutecznym suplementem, który oprócz tego, że gwarantuje walkę z katabolizmem to dodatkowo przyczynia się do przyrostu beztłuszczowej masy mięśniowej. " +
                "Mięśnie są prawidłowo odżywione i zregenerowane, " +
                "dzięki czemu znajdują się w nieustannym procesie anabolicznym. Każda osoba regularnie trenująca może być spokojna, gdyż BCAA Pure 2:1:1 gwarantuje znakomite rezultaty już w krótkim czasie!",
                Ingredients = "L-Leucyna, L-Izoleucyna, L-Walina, żelatynowa kapsułka, stearynian magnezu (substancja przeciwzbrylająca)",
                Parameters = "Wartości odżywcze	W porcji: L-Leucyna 1000 mg, L-Izoleucyna 500 mg, Walina 500 mg, Suma BCAA 2000 mg",
                DateAdded = new DateTime(2021, 9, 25),
                PhotoFileName = "BCAA-2-1-1-Pure-240caps.jpg",
                CategoryID = 1

            };

            var result = controller.Details(id) as ViewResult;

            var viewModel = result.ViewData.Model as Product;
            Assert.AreEqual(product.ProductID, viewModel.ProductID);
        }
    }
}
