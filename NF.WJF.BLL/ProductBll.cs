using NF.WJF.DAL;
using NF.WJF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NF.WJF.BLL
{
    public class ProductBll
    {
        private ProductDal dal;
        
        public ProductBll()
        {
            this.dal = new ProductDal();
        }
        /// <summary>
        /// 查询所有数据
        /// </summary>
        public List<Product> GetDataAll()
        {
            return dal.GetDataAll();
        }
        /// <summary>
        /// 查询所有类型名称
        /// </summary>
        /// <returns></returns>
        public List<ProductType> GetTypeName()
        {
            return dal.GetTypeName();
        }
        /// <summary>
        /// 根据类型名称查询数据
        /// </summary>
        /// <param name="tname"></param>
        /// <returns></returns>
        public List<Product> GetDataByType(string tname)
        {
            return dal.GetDataByType(tname);
        }
        /// <summary>
        /// 根据ID查询数据
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public List<Product> GetDataByID(int ID)
        {
            return dal.GetDataByID(ID);
        }
    }
}
