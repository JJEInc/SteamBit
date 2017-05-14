// TODO: Figure out what packages to import

namespace Items {

  class Item {

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
  class Potions : Item {

    enum type {health, mana};
  }


}
