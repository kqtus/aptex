using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

using Aptex.Contracts.Models;
using Aptex.Services;
using Aptex.Infrastructure.Mock;

namespace Aptex.Tests.UnitTests.Services
{
    public class BasketServiceTests
    {
        [Fact]
        public async Task ItemsCount_NoItems()
        {
            var prodRepo = new MockRepository<Product>();
            var basketRepo = new MockRepository<ProductInBasket>();
            var productsService = new ProductsService(prodRepo);
            var basketService = new BasketService(basketRepo, productsService);

            Assert.True(basketService.ItemsCount("usr") == 0);
        }

        [Fact]
        public async Task ItemsCount_FiveItems()
        {
            var prodRepo = new MockRepository<Product>();
            var basketRepo = new MockRepository<ProductInBasket>();
            var productsService = new ProductsService(prodRepo);
            var basketService = new BasketService(basketRepo, productsService);

            var userId = "UserA";

            basketService.Add(new ProductInBasket { Id = 1, ProductId = 2, UserId = userId, Count = 2 });
            basketService.Add(new ProductInBasket { Id = 2, ProductId = 2, UserId = userId, Count = 1 });
            basketService.Add(new ProductInBasket { Id = 2, ProductId = 3, UserId = userId, Count = 2});
            
            Assert.True(basketService.ItemsCount(userId) == 5);
        }

        [Fact]
        public async Task Clear_ThreeItems()
        {
            var prodRepo = new MockRepository<Product>();
            var basketRepo = new MockRepository<ProductInBasket>();
            var productsService = new ProductsService(prodRepo);
            var basketService = new BasketService(basketRepo, productsService);

            var userId = "UserA";

            basketService.Add(new ProductInBasket { Id = 1, ProductId = 2, UserId = userId, Count = 2 });
            basketService.Add(new ProductInBasket { Id = 2, ProductId = 2, UserId = userId, Count = 1 });

            basketService.Clear(userId);

            Assert.True(basketService.ItemsCount(userId) == 0);
        }

        [Fact]
        public async Task Clear_OneOfTwoBaskets()
        {
            var prodRepo = new MockRepository<Product>();
            var basketRepo = new MockRepository<ProductInBasket>();
            var productsService = new ProductsService(prodRepo);
            var basketService = new BasketService(basketRepo, productsService);

            var userId = "UserA";
            var otherUserId = "UserB";

            basketService.Add(new ProductInBasket { Id = 1, ProductId = 2, UserId = userId, Count = 50 });
            basketService.Add(new ProductInBasket { Id = 1, ProductId = 4, UserId = userId, Count = 2 });
            basketService.Add(new ProductInBasket { Id = 2, ProductId = 2, UserId = otherUserId, Count = 50 });

            basketService.Clear(userId);

            Assert.True(basketService.ItemsCount(userId) == 0);
            Assert.True(basketService.ItemsCount(otherUserId) == 50);
        }

        [Fact]
        public async Task TotalCost_NoCost()
        {
            var prodRepo = new MockRepository<Product>();
            var basketRepo = new MockRepository<ProductInBasket>();
            var productsService = new ProductsService(prodRepo);
            var basketService = new BasketService(basketRepo, productsService);

            Assert.True(basketService.TotalCost("usr") == 0.0M);
        }

        [Fact]
        public async Task TotalCost_SingleItemTenTimes()
        {
            var prodRepo = new MockRepository<Product>();
            var basketRepo = new MockRepository<ProductInBasket>();
            var productsService = new ProductsService(prodRepo);
            var basketService = new BasketService(basketRepo, productsService);

            productsService.Add(new Product
            {
                Id = 1,
                Price = 10.0M
            });

            var userId = "UserA";

            basketService.Add(new ProductInBasket { Id = 1, ProductId = 1, UserId = userId, Count = 20 });

            Assert.True(basketService.TotalCost(userId) == 200.0M);
        }

        [Fact]
        public async Task TotalCost_MultipleItemsSingleTimes()
        {
            var prodRepo = new MockRepository<Product>();
            var basketRepo = new MockRepository<ProductInBasket>();
            var productsService = new ProductsService(prodRepo);
            var basketService = new BasketService(basketRepo, productsService);

            productsService.Add(new Product
            {
                Id = 1,
                Price = 10.0M
            });

            productsService.Add(new Product
            {
                Id = 2,
                Price = 99.0M
            });

            productsService.Add(new Product
            {
                Id = 3,
                Price = 5.5M
            });

            var userId = "UserA";

            basketService.Add(new ProductInBasket { Id = 1, ProductId = 1, UserId = userId, Count = 20 });

            Assert.True(basketService.TotalCost(userId) == 200.0M);
        }
    }
}
