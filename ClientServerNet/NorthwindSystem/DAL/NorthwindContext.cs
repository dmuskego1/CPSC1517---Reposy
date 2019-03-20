using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using System.Data.Entity; //for the entity framework ADO.Net Stuff
using NorthwindData; //for the <T> table definition stuff
#endregion


//This class needs to have access to ADO.Net in EntityFramework 
//  The nuget packages manager will have the EntityFramework, install it
//  this project also needs the assembly System.Data.Entity
//  This project also needs a referenece to the data project 
//  this project needs to use the following name spaces
//      System.Data.Entity
//      .Data project name space (NorthwindData in this case)
namespace NorthwindSystem.DAL
{
    //The class access is restricted to requests from within the library the class exists in: internal
    //  its like a barbed wire around the DAL stuff
    //  the class inherits (ties into EntityFramework) the class DbContext
    internal class NorthwindContext:DbContext
    {
        //Setup up the class default constructor to supply a connection string name 
        //to the DBContext Class inherited (base) class
        public NorthwindContext() : base("NWDB")
        {

        }
        //create an EntityFramework DBSet<T> for each mapped SQL table
        // <T> is your class in the data project this will be a property of the context
        public DbSet<Product> Products { get; set; } 
        public DbSet<Category> Categories { get; set; }
    }
}
