using System;

namespace Items
{
	public class SecondaryWeapon : Weapons {

		public double manaCost { get; set; }

    	public SecondaryWeapon (string aName, double aValue, double aWeight, double aDamage, double aRange, double aSpeed, 
    		double aCost) : base (aName, aValue, aWeight, aDamage, aRange, aSpeed) 
		{
        	manaCost = aCost;
    	}
  	}
}

