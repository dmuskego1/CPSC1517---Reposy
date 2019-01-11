using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPSReview
{
    public class Die
    {
        /* This class is defaulted to Private we need to add public at the beginning if we would like to use it
            this is the definition of an object, 
            it is a conceptualview of the data that
            will be held by a physical instance 
            (object) of this class */

        //Data Members
        //internal private data storage item
        //Private data members can not be reached directly by the user
        //Public data members can be reached directly by the user
        //peoples often put underscores before the vairable names here so that the data members and the properties carry the same name
        private int _Sides;
        private string _Colour;


        //Properties
        //External interface between the user and a single piece of data within the instance
        //A property has 2 abilities, the ability to assign a value to the Internal data member, and return an internal data member value to the user.

        //Fully Implemented Property
        public int Sides 
        {
            //think of these words from the user's perspective
            get
            {
                //takes internal values and returns it to the user
                return _Sides;
            }
            set
            {
                //Takes the supplied user value and places it in the internal private data member
                //The supplied user value is placed into a special variable called "value"
                if(value >= 6 && value <= 20)
                {
                    _Sides = value;
                }
                else
                {
                    throw new Exception("Die cannot be " + value.ToString() + " sides. Die must have between 6 and 20 sides.");
                }
            }
        }

        public string Colour
        {
            get
            {
                return _Colour;
            }
            set
            {
                //(value == null) will only test to see if the value is null it will fail to catch an empty string
                //(value == "") this will fail for a null string
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Colour has no value.");
                }
                else
                {
                    _Colour = value;
                }                
            }
        }


        //Auto Implemented Property
        //  public and have a 
        //  datatype  
        //  has a name
        //  has no internal data member that you can directly access
        //  the system will create, internally, a data storage area of the appropriate datatype and manage the area
        //  the only way ot access the data of an auto implemented property is via the property
        //  usually used when there is no need for any internal validation or other property logic
        public int FaceValue { get; set; }




        //Constructors

        //Behaviours (Methods)

    }
}
