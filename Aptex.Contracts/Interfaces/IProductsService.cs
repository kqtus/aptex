using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aptex.Contracts.Models;

namespace Aptex.Contracts.Interfaces
{
    public interface IProductsService : ICrudService<Product>
    {
        List<Product> List();

        List<Product> ListByCategories(List<int> categoryIds);
    }
}
