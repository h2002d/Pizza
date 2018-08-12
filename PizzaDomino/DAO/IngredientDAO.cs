using PizzaDomino.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace PizzaDomino.DAO
{
    public class IngredientDAO: DAO
    {
        internal int saveIngredient(Ingredients ingredients)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("sp_CreateIngredients", sqlConnection))
                {
                    try
                    {
                        sqlConnection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        if (ingredients.IngredientId == null)
                            command.Parameters.AddWithValue("@Id", DBNull.Value);
                        else
                            command.Parameters.AddWithValue("@Id", ingredients.IngredientId);
                        command.Parameters.AddWithValue("@GoodId", ingredients.GoodId);
                        command.Parameters.AddWithValue("@Price", ingredients.Price);
                        command.Parameters.AddWithValue("@Name", ingredients.Name);
                        return Convert.ToInt32(command.ExecuteScalar());
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        }

        internal List<Ingredients> getIngredientById(int? id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("sp_GetIngredientsById", sqlConnection))
                {
                    try
                    {
                        sqlConnection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        if (id == null)
                            command.Parameters.AddWithValue("@Id", DBNull.Value);
                        else
                            command.Parameters.AddWithValue("@Id", id);

                        SqlDataReader rdr = command.ExecuteReader();
                        List<Ingredients> ingredientsList = new List<Ingredients>();
                        while (rdr.Read())
                        {
                            Ingredients ingredient = new Ingredients();
                            ingredient.IngredientId = Convert.ToInt32(rdr["Id"]);
                            ingredient.Name = rdr["Name"].ToString();
                            ingredient.Price = Convert.ToDecimal(rdr["Price"].ToString());
                            ingredient.GoodId = Convert.ToInt32(rdr["GoodId"]);

                            ingredientsList.Add(ingredient);
                        }
                        return ingredientsList;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        }

        internal List<Ingredients> getIngredientByGoodId(int goodId)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("sp_GetIngredientsByGoodId", sqlConnection))
                {
                    try
                    {
                        sqlConnection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                       
                            command.Parameters.AddWithValue("@GoodId", goodId);

                        SqlDataReader rdr = command.ExecuteReader();
                        List<Ingredients> ingredientsList = new List<Ingredients>();
                        while (rdr.Read())
                        {
                            Ingredients ingredient = new Ingredients();
                            ingredient.IngredientId = Convert.ToInt32(rdr["Id"]);
                            ingredient.Name = rdr["Name"].ToString();
                            ingredient.Price = Convert.ToDecimal(rdr["Price"].ToString());
                            ingredient.GoodId = Convert.ToInt32(rdr["GoodId"]);

                            ingredientsList.Add(ingredient);
                        }
                        return ingredientsList;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        }
    }
}