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
        
        //create a new instance of the math Class Random
        //      This instance will be shared by each instance of the die class
        //This instance will be created when the first instance of a Die is created
        //this is achieved through the static keyword
        private static Random _Rand = new Random();


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
            private set
            {
                //Takes the supplied user value and places it in the internal private data member
                //The supplied user value is placed into a special variable called "value"
                if (value >= 6 && value <= 20)
                {
                    _Sides = value;
                    RollDie(); //consider placing this method within the property if the set is public
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

        //Another version of Sides using a private set and auto implemented property
        //      this version requires you to code a method like SetSides()
        //public int Sides { get; private set; }

        //Auto Implemented Property
        //  public and have a 
        //  datatype  
        //  has a name
        //  has no internal data member that you can directly access
        //  the system will create, internally, a data storage area of the appropriate datatype and manage the area
        //  the only way ot access the data of an auto implemented property is via the property
        //  usually used when there is no need for any internal validation or other property logic
        public int FaceValue { get; private set; }
        
        //Constructors
        //Constructors are optional, in the case that one is not specified the system will provide default assignments for each property
        //      some system defaults are int, double = 0, strings and objects = null
        //You can have any number of constructors but its usually best to just make 2 the default constructor or the greedy constructor
        //      as soon as a constructor has been coded the system will not provide the system default anymore

        //Syntax public classname([list of parameters]){ . . .
        //      the parameters are optional as denoted by the square brackets


        //Default Constructor - Similar to the system default constructor
        public Die()
        {
            //You could leave this constructor empty and the system would assign the normal default value to datamembers and auto implemented properties
            //you can directly access a private datamember within a class
            _Sides = 6;

            //you can also access any propery any place within you class
            Colour = "White";

            //you can use a class method to generate a vlaue for a data member or auto property
            RollDie();

        }

        //Greedy Constructor - Typically has a parameter for each datamember and auto implemented property within the class
        //      Parameter order is not important
        //This constructor allows the outside user to create and assign their own values to the datamembers/autoproperties at the time of instance creation
        public Die(int sides, string colour)
        {
            //Since this data is coming from the users try to remember to set the data through the properties.
            //      The properties will likely have validation so its best to use that
            Sides = sides;
            Colour = colour;
            RollDie();
        }

        //Behaviours (Methods)
        //these are actions that the class can perform
        //      the actions may or may not alter the datamembers/autoproperty values
        //the actions could simply a value(s) from the user and perform logic/operations against the value
        //      eg. the console class is static it doesnt store anything that is sent to it

        //can be public or private
        //Create a method that allows the user to change the number of sides on a die
        public void SetSides(int sides)
        {
            if (sides >= 6 && sides <= 20)
            {
                Sides = sides;
                RollDie();
            }
            else
            {
                //optionally 
                //a) throw a new exception
                throw new Exception("Invalid value for sides");
                //b) set _Sides to a default value
                //Sides = 6;
            }
        }

        public void RollDie()
            //No parameters are required as it will be using the internal data values to complete it's functionality
        {
            //randomly generate a value between 1 and the max number of sides
            FaceValue = _Rand.Next(1,Sides+1);
        }

    }
}
