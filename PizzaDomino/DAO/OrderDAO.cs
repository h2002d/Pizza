using PizzaDomino.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PizzaDomino.DAO
{
    public class OrderDAO : DAO
    {
        internal List<Order> getOrderById(int? id)
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
                        List<Order> ingredientsList = new List<Order>();
                        while (rdr.Read())
                        {
                            Order order = new Order();
                            order.Id = Convert.ToInt32(rdr["Id"]);
                            order.StatusId = Convert.ToInt32(rdr["StatusId"]);
                            order.CreateDate = Convert.ToDateTime(rdr["CreateDate"].ToString());
                            order.OrderDetailId = Convert.ToInt32(rdr["OrderDetailId"]);

                            ingredientsList.Add(order);
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