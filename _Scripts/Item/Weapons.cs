using System;

namespace Items
{
	public class Weapons : Item {

    	public double damage {get; set;}  //  Between 1.0 - 100.0
    	public double range {get; set;}   //  Between 1.0 - 25.0
    	public double speed {get; set;}   //  Betweem 1.0 - 100.0
        // Are these three stats suitable to be choices for upgrades?

    	public Weapons (string aName, double aWeight, double aValue, double aDamage, double aRange, double aSpeed)
    					: base (aName, aValue, aWeight) 
    	{
        	damage = aDamage;
        	range = aRange;
        	speed = aSpeed;
    	}

  	}

}

