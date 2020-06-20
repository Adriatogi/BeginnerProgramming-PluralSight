using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInventory : MonoBehaviour
{
    #region Variable Declerations

    public static CharacterInventory instance;

    #endregion

    #region Initializations

    private void Start()
    {
        instance = this;  
    }
    #endregion
}
