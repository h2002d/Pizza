using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaDomino.Models
{
    public class Goods
    {
        #region Properties
        public int? Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageSource { get; set; }


        static DAO.GoodsDAO DAO = new PizzaDomino.DAO.GoodsDAO();
        #endregion
        public int Save()
        {
            return DAO.saveGood(this);
        }

        public List<Ingredients> Ingredients
        {
            get { return Models.Ingredients.GetIngredientsByGoodId(Convert.ToInt32(Id)); }
        }

        public List<Size> Sizes
        {
            get { return Models.Size.GetSizeByGoodId(Convert.ToInt32(Id)); }
        }

        public static List<Goods> GetGoodById(int id)
        {
            return DAO.getGoodById(id);
        }

        public static List<Goods> GetGoodsByCategoryId(int id)
        {
            return DAO.getGoodByCategoryId(id);
        }
    }

    public class Ingredients
    {
        public int? IngredientId { get; set; }
        public int GoodId { get; set; }
        public string IngredientName { get; set; }
        public decimal Price { get; set; }

        static DAO.IngredientDAO DAO = new PizzaDomino.DAO.IngredientDAO();

        public void Save()
        {
            DAO.saveIngredient(this);
        }

        public void Delete()
        {
            DAO.deleteIngredient(Convert.ToInt32(this.IngredientId));
        }

        public static List<Ingredients> GetIngredientsById(int id)
        {
            return DAO.getIngredientById(id);
        }

        public static List<Ingredients> GetIngredientsByGoodId(int GoodId)
        {
            return DAO.getIngredientByGoodId(GoodId);
        }
    }

    public class Size
    {
        public int? SizeId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int GoodId { get; set; }

        static DAO.SizeDAO DAO = new PizzaDomino.DAO.SizeDAO();

        public void Save()
        {
            DAO.saveSize(this);
        }

        public void Delete()
        {
            DAO.deleteSize(Convert.ToInt32(this.SizeId));
        }

        public static List<Size> GetSizeById(int id)
        {
            return DAO.getSizeById(id);
        }

        public static List<Size> GetSizeByGoodId(int GoodId)
        {
            return DAO.getSizeByGoodId(GoodId);
        }
    }
}