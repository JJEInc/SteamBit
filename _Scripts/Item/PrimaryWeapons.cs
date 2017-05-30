using System;

namespace Items
{
	public class PrimaryWeapon : Weapons {

    	public enum Abilities { none }; //  TODO: figure out how to organize abilities tree/list/thingy
		public enum Effects {none, poison, slow, freeze}  //  TODO: decide on effects

    	public Abilities abilities {get; set;}
    	public Effects effect {get; set;}

		public PrimaryWeapon Gauntlets = new PrimaryWeapon("Gauntlets", 5.0, 0, 5.0, 1.0, 75.0, Abilities.none, Effects.none);
		public PrimaryWeapon Axe = new PrimaryWeapon("Axe", 20.0, 0, 15.0, 5.0, 40.0, Abilities.none, Effects.none);
		public PrimaryWeapon Flail = new PrimaryWeapon("Flail", 30.0, 0, 45.0, 30.0, 20.0, Abilities.none, Effects.none);

    	public PrimaryWeapon (string aName, double aValue, double aWeight, double aDamage, double aRange, double aSpeed, 
    						Abilities someAbilities, Effects anEffect) : base (aName, aValue, aWeight, aDamage, aRange, aSpeed) 
		{
        	someAbilities = abilities;
        	anEffect = effect;
    	}
  	}
}

