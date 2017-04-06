using NF.WJF.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace NF.WJF.DAL
{
    public class ProductDal
    {
        public List<Product> GetDataAll()
        {
            string sql = "select  Product.ProductID,Product.ProductName,Product.Poster,Product.Price,Product.Describe,ProductType.TypeName from Product inner join ProductType on Product.TypeID=ProductType.ID";
            return DBHelper.Query<Product>(sql, sdr =>
            {
                Product p = new Product();
                p.ProductID = Convert.ToInt32(sdr["ProductID"]);
                p.ProductName = sdr["ProductName"].ToString();
                p.Type = new ProductType();
                p.Type.TypeName = sdr["TypeName"].ToString();
                p.Poster = sdr["Poster"].ToString();
                p.Price = Convert.ToDecimal(sdr["Price"]);
                p.Describe = sdr["Describe"].ToString();
                return p;
            });
        }
        public List<Product> GetDataByType(string tname)
        {
            string sql = "select  Product.ProductID,Product.ProductName,Product.Poster,Product.Price,Product.Describe,ProductType.TypeName from Product inner join ProductType on Product.TypeID=ProductType.ID where ProductType.TypeName=@TypeName";
            SqlParameter typename = new SqlParameter("@TypeName", tname);
            return DBHelper.Query<Product>(sql, sdr =>
            {
                Product p = new Product();
                p.ProductID = Convert.ToInt32(sdr["ProductID"]);
                p.ProductName = sdr["ProductName"].ToString();
                p.Type = new ProductType();
                p.Type.TypeName = sdr["TypeName"].ToString();
                p.Poster = sdr["Poster"].ToString();
                p.Price = Convert.ToDecimal(sdr["Price"]);
                p.Describe = sdr["Describe"].ToString();
                return p;
            }, typename);
        }
        public List<Product> GetDataByID(int ID)
        {
            string sql = "select  Product.ProductID,Product.ProductName,Product.Poster,Product.Price,Product.Describe,ProductType.TypeName from Product inner join ProductType on Product.TypeID=ProductType.ID where ProductID=@ProductID";
            SqlParameter id = new SqlParameter("@ProductID", ID);
            return DBHelper.Query<Product>(sql, sdr =>
            {
                Product p = new Product();
                p.ProductID = Convert.ToInt32(sdr["ProductID"]);
                p.ProductName = sdr["ProductName"].ToString();
                p.Type = new ProductType();
                p.Type.TypeName = sdr["TypeName"].ToString();
                p.Poster = sdr["Poster"].ToString();
                p.Price = Convert.ToDecimal(sdr["Price"]);
                p.Describe = sdr["Describe"].ToString();
                return p;
            }, id);
        }
        public List<ProductType> GetTypeName()
        {
            string sql = "select * from ProductType";
            return DBHelper.Query<ProductType>(sql, sdr => {
                ProductType t = new ProductType();
                t.ID = Convert.ToInt32(sdr["ID"]);
                t.TypeName = sdr["TypeName"].ToString();
                return t;
            });
        }
        public int Text()
        {
            return 1;
        }
    }
}
