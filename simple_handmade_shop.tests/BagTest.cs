using Moq;
using simple_handmade_shop.Models;
using simple_handmade_shop.Models.Interfaces;
using simple_handmade_shop.Models.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simple_handmade_shop.tests
{
    public class BagTest
    {
        Mock<IGetBag> MockGetBag = new Mock<IGetBag>();
        [Fact]
        public void AddItemTest()
        {
            int productId = 1;
            MockGetBag.Setup(m => m.AddBag(productId));
            MockGetBag.Object.AddBag(productId);
            MockGetBag.Verify(m => m.AddBag(productId), Times.Once);

        }
        [Fact]
        public void GetOrders_WhenBagsExist_ReturnsBags()
        {


            var bags = new List<Bag>
        {
            new Bag { Id = 1, Name = "Eco Bag", Price = 500 },
            new Bag { Id = 2, Name = "Leather Bag", Price = 1200 }
        };

            MockGetBag.Setup(x => x.GetAllBags()).Returns(bags);

            var orderChoice = new OrderChoice(MockGetBag.Object);


            var result = orderChoice.GetOrders();


            Assert.NotNull(result);

            Assert.Equal(2, result.Count());

            Assert.Equal("Eco Bag", result.First().Name);
        }
        [Fact]
        public void GetOrders_WhenBagsNull_ReturnsEmpty()
        {


            MockGetBag.Setup(x => x.GetAllBags()).Returns((IEnumerable<Bag>)null);

            var orderChoice = new OrderChoice(MockGetBag.Object);

            var result = orderChoice.GetOrders();


            Assert.NotNull(result);

            Assert.Empty(result);
        }
        [Fact]
        public void GetOrders_WhenBagsEmpty_ReturnsEmpty()
        {
            

            MockGetBag.Setup(x => x.GetAllBags()).Returns(new List<Bag>());

            var orderChoice = new OrderChoice(MockGetBag.Object);

           
            var result = orderChoice.GetOrders();

            
            Assert.NotNull(result);

            Assert.Empty(result);
        }


        [Fact]
        public void GetOrders_CallsGetAllBagsOnce()
        {


            MockGetBag.Setup(x => x.GetAllBags()).Returns(new List<Bag>());

            var orderChoice = new OrderChoice(MockGetBag.Object);


            orderChoice.GetOrders();


            MockGetBag.Verify(x => x.GetAllBags(), Times.Once);
        }
    }
}
