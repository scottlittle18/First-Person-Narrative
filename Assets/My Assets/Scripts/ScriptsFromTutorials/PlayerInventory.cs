using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///     This script manages the player's inventory.
/// </summary>
public static class PlayerInventory
{
    public static List<InventoryObject> InventoryObjects { get; } = new List<InventoryObject>();
}
