using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{

    #region

    public CharacterStats_SO characterDefinition;
    public CharacterInventory charInv;
    public GameObject characterWeaponSlot; 

    #endregion

    #region Initializations

    private void Awake()
    {
        charInv = CharacterInventory.instance;
    }

    private void Start()
    {
        if (!characterDefinition.setManually)
        {
            characterDefinition.maxHealth = 100;
            characterDefinition.currentHealth = 50;

            characterDefinition.maxMana = 25;
            characterDefinition.currentMana = 10;

            characterDefinition.maxHealth = 500;
            characterDefinition.currentWealth = 0;

            characterDefinition.baseResistance = 0f;
            characterDefinition.currentResistance = 0f;

            characterDefinition.maxEncumbrance = 0f;
            characterDefinition.currentEncumbrance = 0f;

            characterDefinition.charExperience = 0;
            characterDefinition.charLevel = 1;
        }
    }
    #endregion


    #region Updates
    private void Update()
    {
        if (Input.GetMouseButtonDown(2))
        {
            characterDefinition.saveCharacterData();
        }
    }
    #endregion

    #region Stat Increasers

    public void applyHealth(int healthAmount)
    {
        characterDefinition.applyHealth(healthAmount);
    }

    public void applyMana(int manaAmount)
    {
        characterDefinition.applyMana(manaAmount);
    }

    public void giveWealth(int wealthAmount)
    {
        characterDefinition.giveWealth(wealthAmount);
    }

    #endregion

    #region Stat Reducers

    public void takeDamage(int amount)
    {
        characterDefinition.TakeDamage(amount);
    }

    public void takeMana(int amount)
    {
        characterDefinition.takeMana(amount);
    }

    #endregion

    #region Weapon/Armor Change
    public void changeWeapon(ItemPickup weaponPickup)
    {
        if (!characterDefinition.unEquipWeapon(weaponPickup, charInv, characterWeaponSlot))
        {
            characterDefinition.equipWeapon(weaponPickup, charInv, characterWeaponSlot);
        }
    }

    public void weaponChange(ItemPickup armorPickup)
    {
        if (!characterDefinition.unEquipArmor(armorPickup, charInv))
        {
            characterDefinition.equipArmor(armorPickup, charInv);
        }
    }
    #endregion

    #region Reporters
    public int getHealth()
    {
        return characterDefinition.currentHealth;
    }

    public ItemPickup getCurrentWeapon()
    {
        return characterDefinition.weapon;
    }
    #endregion
}
