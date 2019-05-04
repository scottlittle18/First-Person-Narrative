using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryMenu : MonoBehaviour
{
    private static InventoryMenu instance;

    public static InventoryMenu Instance
    {
        get
        {
            return instance;
        }
        private set { instance = value; }
    }

    private void Awake()
    {
        instance = this;
    }
}
