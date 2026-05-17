using Moq;
using simple_handmade_shop.Models;
using simple_handmade_shop.Models.Interfaces;

namespace simple_handmade_shop.tests
{
    public class UnitTest1
    {
        Mock<IHelperAdmin> mock = new Mock<IHelperAdmin>();
        Mock<IDashboard> mockDashboard = new Mock<IDashboard>();
        [Fact]
        public void Product_Creation_Valid_Redirect()
        {

            var controller = new Controllers.AdminController(mock.Object, mockDashboard.Object);
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
        [Fact]
        public void Admin_delete_product_valid_redirect()
        {
            var controller = new Controllers.AdminController(mock.Object, mockDashboard.Object);
            int productId = 1;
            var result = controller.Delete(productId);
            Assert.IsType<Microsoft.AspNetCore.Mvc.RedirectToActionResult>(result);
            mock.Verify(m => m.RemoveProductList(productId), Times.Once);
        }
        [Fact]
        public async Task Admin_Edit_Product_Valid_Redirect()
        {
            var controller = new Controllers.AdminController(mock.Object, mockDashboard.Object);
            int productId = 1;
            Product product = new Product()
            {
                Id = 1,
                Name = "Test Product",
                Description = "This is a test product.",
                Price = 9.99m,
                FullDescription = "This is a full description of the test product."
            };
            mock.Setup(m => m.EditProduct(productId)).ReturnsAsync(product);
            var result = await controller.Edit(productId);
            Assert.IsType<Microsoft.AspNetCore.Mvc.ViewResult>(result);
            var viewResult = result as Microsoft.AspNetCore.Mvc.ViewResult;
            Assert.NotNull(viewResult);
            Assert.Equal(product, viewResult.Model);
        }
        [Fact]
        public void Admin_return_view_create_product()
        {
            var controller = new Controllers.AdminController(mock.Object, mockDashboard.Object);
            var result = controller.Create();
            Assert.IsType<Microsoft.AspNetCore.Mvc.ViewResult>(result);
        }
    }
}
