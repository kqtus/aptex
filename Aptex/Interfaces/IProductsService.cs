using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aptex.Models;

namespace Aptex.Interfaces
{
    public interface IProductsService
    {
        List<Product> List();
    }
}
