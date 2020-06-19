using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewStats", menuName = "Character/Stats", order = 1)]

public class CharacterStats_SO : ScriptableObject
{
    [System.Serializable]
    public class CharacterLevelUps
    {
        public int maxHealth;
        public int maxMana;
        public int maxWealth;
        public int baseDamage;
        public float baseResistance;
        public float maxEmcumbrance;
    }

    #region Fields

    public bool setManually = false;
    public bool saveDataOnClose = false;

    public ItemPickup weapon { get; private set; }
    public ItemPickup headArmor { get; private set; }
    public ItemPickup chestArmor { get; private set; }
    public ItemPickup handArmor { get; private set; }
    public ItemPickup legArmor { get; private set; }
    public ItemPickup footArmor { get; private set; }
    public ItemPickup misc1 { get; private set; }
    public ItemPickup misc2 { get; private set; }

    public int maxHealth = 0;
    public int currentHealth = 0;

    public int maxMana = 0;
    public int currentMana = 0;

    public int maxWealth = 0;
    public int currentWealth = 0;

    public int baseDamage = 0;
    public int currentDamage = 0;

    public float baseResistance = 0f;
    public float currentResistance = 0f;

    public float currentEmcumbrance = 0f;

    public int charExperience = 0;
    public int charLevel = 0;

    public CharacterLevelUps[] charLevelUps;

    #endregion

    #region Stat Increasers
    public void applyHealth(int healthAmount)
    {
        currentHealth += healthAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
    }

    public void applyMana(int manaAmount)
    {
        currentMana += manaAmount;
        currentMana = Mathf.Clamp(currentMana, 0, maxMana);
    }

    public void giveWealth(int wealthAmount)
    {
        currentWealth += wealthAmount;
        currentWealth = Mathf.Clamp(currentWealth, 0, maxWealth);
    }

    public void equipWeapon(ItemPickup weaponPickup, CharacterInventory charInventory, GameObject weaponSlot)
    {
        weapon = weaponPickup;
        currentDamage = baseDamage + weapon.itemDefinition.itemAmount;
    }

    public void equipArmor(ItemPickup armorPickup, CharacterInventory charInventory)
    {
        switch (armorPickup.itemDefinition.itemArmorSubType)
        {
            case ItemArmorSubType.Head:
                headArmor = armorPickup;
                currentResistance += armorPickup.itemDefinition.itemAmount;
                break;
            case ItemArmorSubType.Chest:
                chestArmor = armorPickup;
                currentResistance += armorPickup.itemDefinition.itemAmount;
                break;
            case ItemArmorSubType.Hand:
                handArmor = armorPickup;
                currentResistance += armorPickup.itemDefinition.itemAmount;
                break;
            case ItemArmorSubType.Legs:
                legArmor = armorPickup;
                currentResistance += armorPickup.itemDefinition.itemAmount;
                break;
            case ItemArmorSubType.Boots:
                footArmor = armorPickup;
                currentResistance += armorPickup.itemDefinition.itemAmount;
                break;
        }
    }
    #endregion

    #region Stat Reducers
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if(currentHealth <= 0)
        {
            //ToDo make an event for death.
            //Death():
        }
    }

    public void takeMana(int amount)
    {
        currentMana -= amount;
        currentMana = Mathf.Clamp(currentMana, 0, maxMana);
    }

    public bool unEquipWeapon(ItemPickup weaponPickup, CharacterInventory charInventory, GameObject weaponSlot)
    {
        bool previousWeaponSame = false;
        if(weapon != null)
        {
            if(weapon == weaponPickup)
            {
                previousWeaponSame = true;
            }

            Destroy(weaponSlot.transform.GetChild(0).gameObject);
            weapon = null;
            currentDamage = baseDamage;
        }

        return previousWeaponSame;
    }

    public bool unEquipArmor(ItemPickup armorPickUp, CharacterInventory charInventory)
    {
        bool previousArmorSame = false;
        switch (armorPickUp.itemDefinition.itemArmorSubType)
        {
            case ItemArmorSubType.Head:
                if (headArmor != null)
                {
                    if(headArmor == armorPickUp)
                    {
                        previousArmorSame = true;
                    }
                    currentResistance -= armorPickUp.itemDefinition.itemAmount;
                    headArmor = null;
                }
                break;
            case ItemArmorSubType.Chest:
                if (chestArmor != null)
                {
                    if (chestArmor == armorPickUp)
                    {
                        previousArmorSame = true;
                    }
                    currentResistance -= armorPickUp.itemDefinition.itemAmount;
                    chestArmor = null;
                }
                break;
            case ItemArmorSubType.Hand:
                if (handArmor != null)
                {
                    if (handArmor == armorPickUp)
                    {
                        previousArmorSame = true;
                    }
                    currentResistance -= armorPickUp.itemDefinition.itemAmount;
                    handArmor = null;
                }
                break;
            case ItemArmorSubType.Legs:
                if (legArmor != null)
                {
                    if (legArmor == armorPickUp)
                    {
                        previousArmorSame = true;
                    }
                    currentResistance -= armorPickUp.itemDefinition.itemAmount;
                    legArmor = null;
                }
                break;
            case ItemArmorSubType.Boots:
                if (footArmor != null)
                {
                    if (footArmor == armorPickUp)
                    {
                        previousArmorSame = true;
                    }
                    currentResistance -= armorPickUp.itemDefinition.itemAmount;
                    footArmor = null;
                }
                break;
        }

        return previousArmorSame;
    }
    #endregion

    #region Character Level Up and Death
    private void Death()
    {
        Debug.Log("You're dead");
        //Call to Game Manager for Death State to Trigger Respawn
        //Display the Death Visualization
    }

    #endregion
}
