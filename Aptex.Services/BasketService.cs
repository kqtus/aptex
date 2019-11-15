using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aptex.Contracts.Interfaces;
using Aptex.Contracts.Models;

namespace Aptex.Services
{
    public class BasketService : CrudService<ProductInBasket>, IBasketService
    {
        public BasketService(IRepository<ProductInBasket> repo)
            : base(repo)
        {
        }

        public int ItemsCount()
        {
            return this._repo.List().Count();
        }
    }
}
