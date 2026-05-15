using Moq;
using simple_handmade_shop.Models;
using simple_handmade_shop.Models.Interfaces;

namespace simple_handmade_shop.tests
{
    public class UnitTest1
    {
        [Fact]
        public void Product_Creation_Valid_Redirect()
        {
            Mock<IHelperAdmin> mock = new Mock<IHelperAdmin>();
            Mock<IDashboard> mockDashboard = new Mock<IDashboard>();    
            var controller = new Controllers.AdminController(mock.Object,mockDashboard.Object );
            Product product = new Product()
            {
                Id = 1,
                Name = "Test Product",
                Description = "This is a test product.",
                Price = 9.99m,
                FullDescription = "This is a full description of the test product."
            };
            var result = controller.Create(product);
            Assert.IsType<Microsoft.AspNetCore.Mvc.RedirectToActionResult>(result);
            mock.Verify(m => m.AddProductList(It.IsAny<Product>()), Times.Once);
            
        }
    }
}
