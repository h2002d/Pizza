using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaDomino.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int OrderDetailId { get; set; }
        public DateTime CreateDate { get; set; }
        public int StatusId { get; set; }

        static DAO.OrderDAO DAO = new PizzaDomino.DAO.OrderDAO();

        public static List<Order> GetOrderById(int? id)
        {
            return DAO.getOrderById(id);
        }

    }

    public class OrderDetail
    {
        public int Id { get; set; }
        public int GoodId { get; set; }
        public decimal Quantity { get; set; }
        public int SizeId { get; set; }
        public List<OrderIngredients> ingredients
        {
            get
            {
                return null;//GetIngredientsById
            }
        }
        //list with ingredients
    }

    public class OrderIngredients
    {
        public int Id { get; set; }
        public int OrderDetailId { get; set; }
        public int IngredientId { get; set; }
    }
}