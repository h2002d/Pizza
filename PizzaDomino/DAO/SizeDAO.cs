using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;

namespace PizzaDomino.DAO
{
    public class SizeDAO:DAO
    {
        internal List<Models.Size> getSizeById(int? id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("sp_GetSizeById", sqlConnection))
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
                        List<Models.Size> goodsList = new List<Models.Size>();
                        while (rdr.Read())
                        {
                            Models.Size size = new Models.Size();
                            size.SizeId = Convert.ToInt32(rdr["Id"]);
                            size.GoodId = Convert.ToInt32(rdr["GoodId"]);
                            size.Name = rdr["Name"].ToString();
                            size.Price = Convert.ToDecimal(rdr["Price"].ToString());
                            goodsList.Add(size);
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

        internal List<Models.Size> getSizeByGoodId(int? id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("sp_GetSizeByGoodId", sqlConnection))
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
                        List<Models.Size> goodsList = new List<Models.Size>();
                        while (rdr.Read())
                        {
                            Models.Size size = new Models.Size();
                            size.SizeId = Convert.ToInt32(rdr["Id"]);
                            size.GoodId = Convert.ToInt32(rdr["GoodId"]);
                            size.Name = rdr["Name"].ToString();
                            size.Price = Convert.ToDecimal(rdr["Price"].ToString());
                            goodsList.Add(size);
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

        internal int saveSize(Models.Size size)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("sp_CreateSize", sqlConnection))
                {
                    try
                    {
                        sqlConnection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        if (size.SizeId == null)
                            command.Parameters.AddWithValue("@Id", DBNull.Value);
                        else
                            command.Parameters.AddWithValue("@Id", size.SizeId);
                        command.Parameters.AddWithValue("@GoodId", size.GoodId);
                        command.Parameters.AddWithValue("@Price", size.Price);
                        command.Parameters.AddWithValue("@Name", size.Name);

                        return Convert.ToInt32(command.ExecuteScalar());
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        }

        internal void deleteSize(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("sp_AdminDeleteSize", sqlConnection))
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