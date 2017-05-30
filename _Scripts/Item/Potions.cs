using System;

namespace Items
{
	public class Potions : Item {

    	public enum PotionType {health, mana};

   		public PotionType potionType {get; set;}
    	public int potency {get; set;}  // How many points the potion restores by

    	public Potions (string aName, double aValue, double aWeight, PotionType type, int aPotency) : base (aName,
                      aValue, aWeight) 
       	{
        	potionType = type;
        	potency = aPotency;
    	}
  	}
}

