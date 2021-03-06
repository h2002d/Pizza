﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaDomino.Models
{
    public class Category
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        private bool hasGoods;
        private List<Goods> goods;
        public List<Goods> Goods
        {
            get
            {
                if (hasGoods)
                    return goods;
                else
                {
                    hasGoods = true;
                    return Models.Goods.GetGoodsByCategoryId(Convert.ToInt32(Id));
                }
            }
        }

        static DAO.CategoryDAO DAO = new DAO.CategoryDAO();


        public int Save()
        {
            return DAO.saveCategory(this);
        }

        public void Delete()
        {
            DAO.deleteCategory(Convert.ToInt32(Id));
        }
        public static List<Category> GetCategoryById(int? id)
        {
            return DAO.getCategoryById(id);
        }

    }
}