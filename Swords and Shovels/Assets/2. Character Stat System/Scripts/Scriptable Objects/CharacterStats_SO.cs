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
