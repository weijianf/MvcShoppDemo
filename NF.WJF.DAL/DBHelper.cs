using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace NF.WJF.DAL
{
    public static class DBHelper
    {
        private static  string connStr = ConfigurationManager.ConnectionStrings["Shopping"].ConnectionString;
        /// <summary>
        /// 添加，修改，删除数据
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="pas"></param>
        /// <returns></returns>
        public static bool Execute(string sql, params SqlParameter[] pas)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddRange(pas);
                return cmd.ExecuteNonQuery() > 0 ? true : false;
            }
        }
        public static bool ExecuteNonQuery(string sql, params SqlParameter[] para)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddRange(para);
                int result = cmd.ExecuteNonQuery();
                return result > 0 ? true : false;
            }
        }
        /// <summary>
        /// 查询所有数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="handler"></param>
        /// <param name="pas"></param>
        /// <returns></returns>
        public static List<T> Query<T>(string sql, Func<SqlDataReader, T> handler, params SqlParameter[] pas)
        {
            List<T> result = new List<T>();
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddRange(pas);
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        T ins = handler(sdr);
                        result.Add(ins);
                    }
                }
            }

            return result;
        }
    }
}
