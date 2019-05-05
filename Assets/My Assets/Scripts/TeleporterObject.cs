using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Used to teleport the player from one location to another.
/// </summary>
public class TeleporterObject : InteractiveObject
{
    [SerializeField]
    [Tooltip("The Game Object that will act as the teleportation target.")]
    private GameObject playerTeleportationTarget;

    private Animator teleporterAnimator;

    private Transform playerTransform;
    private bool IsKey => GetComponent<InventoryObject>();

    private void Start()
    {
        if(!IsKey)
            displayText = nameof(TeleporterObject);

        teleporterAnimator = GetComponent<Animator>();
    }

    public override void InteractWithObject()
    {
        teleporterAnimator.SetTrigger("Teleport");

        if (!IsKey)
        {
            base.InteractWithObject();
        }
    }

    public void TeleportPlayer()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        playerTransform.position = playerTeleportationTarget.transform.position;
        Destroy(playerTeleportationTarget);
    }

    //private IEnumerator 
}
