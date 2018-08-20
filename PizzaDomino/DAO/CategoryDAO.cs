using PizzaDomino.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace PizzaDomino.DAO
{
    public class CategoryDAO : DAO
    {
        internal List<Category> getCategoryById(int? id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("sp_GetCategoryById", sqlConnection))
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
                        List<Category> goodsList = new List<Category>();
                        while (rdr.Read())
                        {
                            Category category = new Category();
                            category.Id = Convert.ToInt32(rdr["Id"]);
                            category.Name = rdr["Name"].ToString();
                            goodsList.Add(category);
                        }
                        return goodsList;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        }

        internal int saveCategory(Category category)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("sp_CreateCategory", sqlConnection))
                {
                    try
                    {
                        sqlConnection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        if (category.Id == null)
                            command.Parameters.AddWithValue("@Id", DBNull.Value);
                        else
                            command.Parameters.AddWithValue("@Id", category.Id);
                        command.Parameters.AddWithValue("@Name", category.Name);

                        return Convert.ToInt32(command.ExecuteScalar());
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        }
        internal void deleteCategory(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("sp_AdminDeleteCategory", sqlConnection))
                {
                    try
                    {
                        sqlConnection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Id", id);
                        //command.Parameters.AddWithValue("@DateBirth", user.DateBirth);
                        command.ExecuteNonQuery();
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