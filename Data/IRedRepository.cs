using BurnRed.Data.Entities;
using System.Collections.Generic;

namespace BurnRed.Data
{
    public interface IRedRepository
    {
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetProductsByCategory(string category);
        bool SaveAll();
        IEnumerable<Order> GetAllOrders();
        Order GetOrderById(int id);
    }

}