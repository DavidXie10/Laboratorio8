using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Laboratorio08.Models;

namespace Laboratorio08.Handlers {
    public class ProductsHandler {
        private SqlConnection connection;
        private string connectionRoute;

        public ProductsHandler() {
            connectionRoute =
           ConfigurationManager.ConnectionStrings["Lab8Connection"].ToString();
            connection = new SqlConnection(connectionRoute);
        }

        private DataTable CreateTableFromQuery(string query) {
            SqlCommand queryCommand = new SqlCommand(query, connection);
            SqlDataAdapter tableAdapter = new SqlDataAdapter(queryCommand);
            DataTable queryTable = new DataTable();
            connection.Open();
            tableAdapter.Fill(queryTable);
            connection.Close();
            return queryTable;
        }

        public IEnumerable<Products> GetAll() {
            /*
             * IEnumerable es una estructura similar a List, la cual se utilizó en
            laboratorios previos
             * Llene esta lista con el resultado de su consulta.
             */
            IEnumerable <Products> productsList = new List<Products>();

            /*
            * Agregue la lógica y elementos necesarios para que este método retorne
            todos los productos
            * Es decir, debe realizar un SELECT * FROM Products
             */
            string query = "SELECT * FROM Products";
            DataTable resultingTable = CreateTableFromQuery(query);
            foreach (DataRow column in resultingTable.Rows) {
                productsList = productsList.Append(
                    new Products {
                        Name = Convert.ToString(column["name"]),
                        Quantity = Convert.ToInt32(column["quantity"]),
                        Id = Convert.ToInt32(column["Id"]),
                        Price = Convert.ToDouble(column["price"])
                    });
            }

            return productsList;
        }
    }
}