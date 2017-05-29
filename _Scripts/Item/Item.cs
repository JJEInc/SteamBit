// TODO: Figure out what packages to import

namespace Items {

  public class Item {

    public string name {get; set;}
    public double value {get; set;}
    public double weight {get; set;}

    public Item (string aName, double aValue, double aWeight) {
        name = aName;
        value = aValue;
        weight = aWeight;
    }
  }
  public class Clothing : Item {

    public string color {get; set;}

    public Clothing (string aColor, string aName, double aValue,
                       double aWeight) : base (aName, aValue, aWeight) {
        color = aColor;
    }
  }
  public class Potions : Item {

    public enum PotionType {health, mana};

    public PotionType potionType {get; set;}
    public int potency {get; set;}  // How many points the potion restores by

    public Potions (string aName, double aValue, double aWeight,
                      PotionType type, int aPotency) : base (aName,
                      aValue, aWeight) {
        potionType = type;
        potency = aPotency;
    }
  }
  public class Weapons : Item {

    public double damage {get; set;}  //  Between 1.0 - 100.0
    public double range {get; set;}   //  Between 1.0 - 25.0
    public double speed {get; set;}   //  Betweem 1.0 - 100.0
        // Are these three stats suitable to be choices for upgrades?

    public Weapons (string aName, double aWeight, double aDamage, double aRange,
                      double aSpeed) : base (aName, aWeight) {
        damage = aDamage;
        range = aRange;
        speed = aSpeed;
    }
  }
  public class PrimaryWeapon : Weapons {

    public enum Abilities {none, }; //  TODO: figure out how to organize abilities tree/list/thingy
    public Abilities abilities {get; set;}
    public enum Effects {none, poison, slow, freeze}  //  TODO: decide on effects
    public Effects effect {get; set;}
    public PrimaryWeapon Gauntlets;
    public PrimaryWeapon Axe;
    public PrimaryWeapon Flail;

    public PrimaryWeapon (string aName, double aWeight, double aDamage,
                            double aRange, double aSpeed,
                            Abilities someAbilities, Effects anEffect)
                            : base (aName, aWeight, aDamage, aRange, aSpeed) {
        someAbilities = abilities;
        anEffect = effect;
    }

    PrimaryWeapon Gauntlets = new PrimaryWeapon("Gauntlets", 5.0, 5.0,
                                                  1.0, 75.0, none, none);
    PrimaryWeapon Axe = new PrimaryWeapon("Axe", 20.0, 15.0, 5.0, 40.0, none,
                                            none);
    PrimaryWeapon Flail = new PrimaryWeapon("Flail", 45.0, 30.0, 20.0, none,
                                            none);
  }
}
