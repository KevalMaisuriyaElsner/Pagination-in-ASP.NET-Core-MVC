using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Pagination_Asp.NetCoreMVC.Models;

namespace Pagination_Asp.NetCoreMVC.Database_Access_layer
{
    public class db
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-LOCR2E2;User ID=keval;Password=********;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
    
        public ProductModel GetProduct(int CurrentPage)
        {
            int maxRows = 5;
            SqlCommand com = new SqlCommand("Sp_Product",con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Pageindex", CurrentPage);
            com.Parameters.AddWithValue("@Pagesize", maxRows);

            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            ProductModel productmodel = new ProductModel();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                productmodel.Products.Add(new Product
                {
                    PName = dr["PName"].ToString(),
                    Price = Convert.ToInt32(dr["Price"]), 
                    Category = dr["Category"].ToString(),
                    Manufacturer = dr["Manufacturer"].ToString()
                });
            }
            productmodel.PageCount = Convert.ToInt32(ds.Tables[1].Rows[0][0]) / maxRows;
            productmodel.CurrentIndex = CurrentPage;
            return productmodel;
        }
    }
}
