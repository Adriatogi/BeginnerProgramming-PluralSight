using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public enum ItemTypeDefinitions { HEALTH, WEALTH, MANA, WEAPON, ARMOR, BUFF, EMPTY}
public enum ItemArmorSubType { None, Head, Chest, Hand, Legs, Boots}

[CreateAssetMenu(fileName = "New Item", menuName = "Spawnable Item/New Pickup", order = 1)]
public class ItemPickup_SO : ScriptableObject
{
    public ItemTypeDefinitions itemType = ItemTypeDefinitions.HEALTH;
    public ItemArmorSubType itemArmorSubType = ItemArmorSubType.None;
    public int itemAmount = 0;
}
