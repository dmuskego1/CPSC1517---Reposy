﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


#region Additional Namespaces
using NorthwindData; //obtains the <T> devinitions
using NorthwindSystem.DAL;  //obtains the context class
using System.Data.SqlClient;  //Required for parameter used in SQL proc calls
#endregion

namespace NorthwindSystem.BLL
{
    //this class needs to be called from another class(es)
    //this class is part of the system interface to the
    //   web application (and/or any other client that
    //   needs to get to the Northwind database)
    //this class is the enter point into the Northwind system
    //this class needs to be public
    public class ProductController
    {
        //this method will receive a value that
        //   represents the ProductID
        //this method will forward the value to
        //   the DbSet<T> in the DbContext class
        //   for processing
        //this method will return an instance of Product
        //this method must be public
        public Product Product_Get(int productid)
        {
            //the instantiation of the DbContext will
            //  be done in a transaction using group
            using (var context = new NorthwindContext())
            {
                //return the results of the method call
                //context points to the DAL context class
                //Products is theDbSet<T>
                //.Find(pkey value) looks for a set record
                //     whom's primary key is equal to the
                //     supplied value
                return context.Products.Find(productid);
            }
        }

        //this method will return all records of a DbSet<T>
        //no parameter value is necessarys
        public List<Product> Product_List()
        {
            using (var context = new NorthwindContext())
            {
                return context.Products.ToList();
            }
        }
        //This method will query the DbSet<T> using a sql procedure
        //The query will be against a non primary field
        //The result return will still be the complete entity <T> record
        //we need to add a using clause to System.Data.Entity to our class
        //input:categoryid
        //output:list<product> matching the categoryid input
        public List<Product> Product_GetByCategory(int categoryid)
        {
            using (var context = new NorthwindContext())
            {
                //generally data sets from DbSet calls return as a data type of IEnumerable<T>
                //  this IEnumerable<T> dataset will be turned into a list using ToList()
                IEnumerable<Product> results = context.Database.SqlQuery<Product>(
                    "Products_GetByCategories @CategoryID", new SqlParameter("CategoryID",categoryid));
                results.ToList();
                return results;
            }
        }
    }
}
