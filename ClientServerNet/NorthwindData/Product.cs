using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//The annotations used within the .data Project will require the System.ComponentModel.DataAnnotations assembly.
//  this assembly is added via the references for the project

#region Additional Namespaces
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
#endregion
namespace NorthwindData
{
    //use an annotation to link this class to the appropriate sql database table
    //  all annotations are in square brackets
    //  [Table("Name-Of-SQL-Table")]
    [Table("Products")]
    public class Product
    {
        //mapping of the sql table attributes will be to class properties. one to one relationship
        private string _QuantityPerUnit;

        // use an annotation to identify the primary key
        //1) identity pkey on your sql table (default)
        //      [Key] assumes identity pkey ending in ID or id
        //2) a compound pkey on the sql table
        //      [Key,Column(Order=n)] where n is the numeric value of the physical order of the attribute in the key
        //3) a user supplied pkey on your sql tabel
        //      [Key, DatabseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int? SupplierID { get; set; }
        public int? CategoryID { get; set; }
        public string QuantityPerUnit
        {
            get
            {
                return _QuantityPerUnit;
            }
            set
            {
                _QuantityPerUnit = string.IsNullOrEmpty(value.Trim()) ? null : value;
            }
        }
        public decimal? UnitPrice { get; set; }
        public Int16? UnitsInStock { get; set; }
        public Int16? UnitsOnOrder { get; set; }
        public Int16? ReorderLevel { get; set; }
        public bool Discontinued { get; set; }

        //sample of a computed field on your SQL table
        //  to annotate this property to be taken as an SQL computed field use:
        //  [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        //  public decimal somecomputedsqlfield{get;set;}

        //creating a read only property that is NOT an actual field on your SQL table means that no data is actually transfered
        //  example: FirstName and LastName attributes are often combined into a single field for display
        //  use the NotMapped annotation to handle this
        //[notMapped]
        //public string FullName
        //{
        //    get
        //    {
        //        return FirstName + ' ' + LastName;
        //    }
        //}
    }   
}
