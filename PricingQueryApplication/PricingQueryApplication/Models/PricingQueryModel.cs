using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;
using System.Web.Mvc;

namespace PricingQueryApplication.Models
{
    public class PricingQueryModel
    {
        CustomerDetails customer;
        List<Product> products;
        const string constr = @"Data Source= localhost; Database=new_Schema;User Id=root;Password=admin";

        public CustomerDetails Customer { get => customer; set => customer = value; }
        public List<Product> Products { get => products; set => products = value; }
        public IEnumerable<SelectListItem> Prods { get => prods; set => prods = value; }
        public string SelectedProd { get => selectedProd; set => selectedProd = value; }

        IEnumerable<SelectListItem> prods;
        String selectedProd;

        public void getProducts()
        {
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                string query = "Select * From Product";
                con.Open();
                using (MySqlDataAdapter cmd = new MySqlDataAdapter(query,con))
                {

                    DataTable ds = new DataTable("Product");
                    cmd.Fill(ds);
                    con.Close();
                    products = new List<Product>();
                    foreach (DataRow dr in ds.Rows)
                    {
                        products.Add(new Product { Name = Convert.ToString(dr["ProductName"]) });
                    }
                    Prods = products.Select(x => new SelectListItem
                    {
                        Value = x.Name,
                        Text = x.Name
                    });
                }
            }
        }

        public String callProcedure()
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    string proc = "new_schema.new_pricingQuery";
                    
                   
                    using (MySqlCommand cmd = new MySqlCommand(proc))
                    {
                        cmd.Connection = con;
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        con.Open();
                        //cmd.ExecuteScalar();
                        cmd.Parameters.AddWithValue("?FIRSTNAME",Customer.FirstName);
                        cmd.Parameters.AddWithValue("?LASTNAME", Customer.LastName);
                        cmd.Parameters.AddWithValue("?EMAIL", Customer.Email);
                        cmd.Parameters.AddWithValue("?LINE1", Customer.Address.Line1);
                        cmd.Parameters.AddWithValue("?CITY", Customer.Address.City);
                        cmd.Parameters.AddWithValue("?PC", Customer.Address.PostCode);
                        cmd.Parameters.AddWithValue("?CNTRY", Customer.Address.Country);
                        cmd.Parameters.AddWithValue("?PHNUM", Customer.Phone);
                        cmd.Parameters.AddWithValue("?PRODUCTLIST", SelectedProd);
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }catch(Exception ex)
            {
                //log connection exception        
                return ex.Message;
            }
            return "OK";
           
        }
    }
}