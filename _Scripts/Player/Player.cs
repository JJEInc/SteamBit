// TODO Figure out what packages to import
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Items;

public class Player {
        public string name {get; set;}
        public int health {get; set;}
        public int mana {get; set;}
        public PrimaryWeapon equippedPrimaryWeapon {get; set;}
        public SecondaryWeapon equippedSecondaryWeapon { get; set; }
        public Item equippedItem {get; set;}
        public Inventory inventory {get; set;}

        public Player(string Name, int Health, int Mana, PrimaryWeapon EquippedWeapon, 
        				SecondaryWeapon equippedSecondaryWeapon, Item EquippedItem, Inventory Inventory) 
        {
                name = Name;
                health = Health;
                mana = Mana;
                equippedPrimaryWeapon = EquippedWeapon;
                equippedItem = EquippedItem;
                inventory = Inventory;
        }

}
