using AutoFixture;
using Moq;
using Shope.Api.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopUnityTest
{
    [TestClass]
    public class ProductsControllerTests
    {
        private IProductService _productService;
        private Fixture _fixtrue;
        private ProductsController _controler;

        public ProductsControllerTests()
        {
            _fixtrue = new Fixture();
            _controler = new Mock<ProductService>();
        }
    }
}
