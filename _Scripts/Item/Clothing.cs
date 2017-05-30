using System;

namespace Items
{
	public class Clothing : Item {

    	public string color {get; set;}

    	public Clothing (string aColor, string aName, double aValue,
                       double aWeight) : base (aName, aValue, aWeight) 
        {
        	color = aColor;
    	}

  	}

}

