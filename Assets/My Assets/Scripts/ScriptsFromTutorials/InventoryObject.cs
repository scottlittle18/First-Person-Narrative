using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryObject : InteractiveObject
{
    [SerializeField]
    [Tooltip("Name of the object as it will appear in the inventory menu.")]
    private string objectName = nameof(InventoryObject);

    // TODO: Add field for a long description
    // TODO: Add icon field

    private Renderer inventoryObjectRenderer;
    private Collider inventroyObjectCollider;

    private void Start()
    {
        inventoryObjectRenderer = GetComponent<Renderer>();
        inventroyObjectCollider = GetComponent<Collider>();
    }

    public InventoryObject()
    {
        displayText = $"Take {objectName}";
    }

    /// <summary>
    /// When the player interacts with an inventory object, we need to do 2 things:
    /// 1. Add the inventory object to the PlayerInventory list
    /// 2. Remove the object from the game world / scene
    ///     Can't use Destory, because I need to keep the gameObject in the inventory list.
    ///     so we just disable the collider and renderer.
    /// </summary>
    public override void InteractWithObject()
    {
        base.InteractWithObject();
        PlayerInventory.InventoryObjects.Add(this);
        inventoryObjectRenderer.enabled = false;
        inventroyObjectCollider.enabled = false;
    }
}
