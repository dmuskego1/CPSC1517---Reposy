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
        private int _sides;


        //Properties
        //External interface between the user and a single piece of data within the instance
        //A property has 2 abilities, the ability to assign a value to the Internal data member, and return an internal data member value to the user.

        //Fully Implemented Property
        public int sides 
        {
            //think of these words from the user's perspective
            get
            {
                //takes internal values and returns it to the user
                return _sides;
            }
            set
            {
                //Takes the supplied user value and places it in the internal private data member
                //The supplied user value is placed into a special variable called "value"
                _sides = value;
            }
        }


        //Constructors

        //Behaviours (Methods)

    }
}
