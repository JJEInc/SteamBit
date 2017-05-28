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

    public Clothing (string aColor, string aName, double aValue, double aWeight) : base (aName, aValue, aWeight)) {
        color = aColor;
    }
  }
  public class Potions : Item {

    public enum PotionType {health, mana};

    public PotionType potionType {get; set;}
    public int potency {get; set;}  // How many points the potion restores by

    public Potions (string aName, double aValue, double aWeight, PotionType type, int aPotency) : base (aName, aValue, aWeight) {
        potionType = type;
        potency = aPotency;
    }
  }
  public class Weapons : Item {

    public double damage {get; set;}
    public double range {get; set;}     // Are these three stats suitable to be choices for upgrades?
    public double speed {get; set;}

    public Weapons (string aName, double aValue, double aWeight, double aDamage, double aRange, double aSpeed) : base (aName, aValue, aWeight) {
        damage = aDamage;
        range = aRange;
        speed = aSpeed;
    }
  }
  public class PrimaryWeapon : Weapons {

    public enum Abilities {}; //  TODO: figure out how to organize abilities tree/list/thingy
    public Abilities abilities {get; set;}
  }
}
