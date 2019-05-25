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
    }

    private void Start()
    {
        displayText = nameof(TeleporterObject);
        InventoryObjectRenderer = GetComponent<Renderer>();
        InventoryObjectCollider = GetComponent<Collider>();
        teleporterAnimator = GetComponent<Animator>();
    }

    public override void InteractWithObject()
    {
        teleporterAnimator.SetTrigger("Teleport");

        try
        {
            interactionSFX.PlayOneShot(interactionSFX.clip);
        }
        catch (System.Exception)
        {

            throw new System.Exception("Missing AudioSource component or Audio Clip: InteractiveObject requires an AudioSource with an assigned AudioClip.");
        }

        PlayerInventory.InventoryObjects.Add(this);
        InventoryMenu.Instance.AddItemToMenu(this);
        InventoryObjectRenderer.enabled = false;
        InventoryObjectCollider.enabled = false;
        //base.InteractWithObject();
        //PlayerInventory.InventoryObjects.Add(this);
        //InventoryMenu.Instance.AddItemToMenu(this);

        //TODO: Debug for InventoryMenu Script
        Debug.Log($"Inventory menu game object name: {InventoryMenu.Instance.name}");
    }

    public void TeleportPlayerOnKeyPickup()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        playerTransform.position = playerTeleportationTarget.transform.position;
        //InventoryObjectRenderer.enabled = false;
        //InventoryObjectCollider.enabled = false;
    }
}
