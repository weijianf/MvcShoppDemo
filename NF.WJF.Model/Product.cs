using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NF.WJF.Model
{
   public class Product
    {

       public int ProductID { get; set; }
       public string ProductName {get;set;}
       public string Poster {get;set;}
       public int TypeID {get;set;}
       public decimal Price{get;set;}
       public string Describe {get;set;}
       public ProductType Type { get; set; }

    }
}
