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
    public class OrderTest
    {
        Mock<IGetBag> _orderMock= new Mock<IGetBag>();

        [Fact]
        public void GetOrders_ReturnsBags_WhenBagsExist()
        {
            

            var bags = new List<Bag>
            {
            new Bag { Id = 1, Name = "Bag 1" },
            new Bag { Id = 2, Name = "Bag 2" }
            };

            _orderMock.Setup(x => x.GetAllBags()).Returns(bags);

            var service = new OrderChoice(_orderMock.Object);

            
            var result = service.GetOrders();

            
            Assert.Equal(2, result.Count());
        }
        [Fact]
        public void GetOrders_ReturnsEmpty_WhenNull()
        {
            

            _orderMock.Setup(x => x.GetAllBags())
                   .Returns((IEnumerable<Bag>)null);

            var service = new OrderChoice(_orderMock.Object);

            var result = service.GetOrders();

            
            Assert.Empty(result);
        }


        [Fact]
        public void GetOrders_ReturnsEmpty_WhenListEmpty()
        {
            _orderMock.Setup(x => x.GetAllBags())
                   .Returns(new List<Bag>());

            var service = new OrderChoice(_orderMock.Object);

            var result = service.GetOrders();

            
            Assert.Empty(result);
        }


        [Fact]
        public void GetOrders_CallsGetAllBags_Once()
        {
            

            _orderMock.Setup(x => x.GetAllBags())
                   .Returns(new List<Bag>());

            var service = new OrderChoice(_orderMock.Object);

            service.GetOrders();


            _orderMock.Verify(x => x.GetAllBags(), Times.Once);
        }

    }
}
