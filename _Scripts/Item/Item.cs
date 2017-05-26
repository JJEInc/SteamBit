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
  /*class Clothing : Item {

    public string color {get; set;}

    public Clothing (string aColor) {
        color = aColor;
    }
  }*/
  public class Potions : Item {

    public enum PotionType {health, mana};

    public PotionType potionType;

    public Potions(string aName, double aVal, double aWei, PotionType type) : base(aName, aVal, aWei)
    {
    	potionType = type;
    }

  }
}
