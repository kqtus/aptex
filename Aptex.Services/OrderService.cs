using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aptex.Contracts.Interfaces;
using Aptex.Contracts.Models;

namespace Aptex.Services
{
    public class OrderService : CrudService<Order>, IOrderService
    {
        public OrderService(IRepository<Order> repo)
            : base(repo)
        {
        }
    }
}
