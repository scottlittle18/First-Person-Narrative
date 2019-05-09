using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempleKeyTeleportOnInteraction : InventoryObject
{
    [SerializeField]
    [Tooltip("The Game Object that will act as the teleportation target.")]
    private GameObject playerTeleportationTarget;

    private Animator teleporterAnimator;
    private Transform playerTransform;

    public TempleKeyTeleportOnInteraction()
    {
        displayText = $"Take {ObjectName}";
        InventoryObjectRenderer = GetComponent<Renderer>();
        InventoryObjectCollider = GetComponent<Collider>();
    }

    private void Start()
    {
        displayText = nameof(TeleporterObject);

        teleporterAnimator = GetComponent<Animator>();
    }

    public override void InteractWithObject()
    {
        teleporterAnimator.SetTrigger("Teleport");
        base.InteractWithObject();
        PlayerInventory.InventoryObjects.Add(this);
        InventoryMenu.Instance.AddItemToMenu(this);
        InventoryObjectRenderer.enabled = false;
        InventoryObjectCollider.enabled = false;
        //TODO: Debug for InventoryMenu Script
        Debug.Log($"Inventory menu game object name: {InventoryMenu.Instance.name}");
    }

    public void TeleportPlayer()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        playerTransform.position = playerTeleportationTarget.transform.position;
        Destroy(playerTeleportationTarget);
    }
}
