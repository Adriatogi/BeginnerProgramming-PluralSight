using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="NewStats", menuName ="Character/Stats", order = 1)]

public class CharacterStats_SO : ScriptableObject
{
    #region Fields

    public bool setManually = false;
    public bool saveDataOnClose = false;

    public int maxHealth = 0;
    public int currentHealth = 0;

    public int baseDamage = 0;
    public int currentDamage = 0;

    public float baseResistance = 0f;
    public float currentResistance = 0f;

    public float currentEmcumbrance = 0f;

    public int charExperience = 0;
    public int charLevel = 0;


    #endregion
}
