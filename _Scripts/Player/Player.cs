// TODO Figure out what packages to import
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player {
        public string name {get; set;}
        public int health {get; set;}
        public int mana {get; set;}
        public Weapon equippedWeapon {get; set;}
        public Item equippedItem {get; set;}
        public Inventory inventory {get; set;}

        public Player(string Name, int Health, int Mana, Weapon EquippedWeapon, Item EquippedItem, Inventory Inventory) {
                name = Name;
                health = Health;
                mana = Mana;
                equippedWeapon = EquippedWeapon;
                equippedItem = EquippedItem;
                inventory = Inventory;
        }

}
