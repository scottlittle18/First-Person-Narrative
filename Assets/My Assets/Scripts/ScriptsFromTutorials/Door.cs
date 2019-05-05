using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Used to control the logic and animation for doors.
/// </summary>
[RequireComponent(typeof(Animator))]
public class Door : InteractiveObject
{
    [SerializeField]
    [Tooltip("Assigning a key here will lock the door. If the player has the key in their inventory, they can open the locked door.")]
    private InventoryObject key;

    [SerializeField]
    [Tooltip("If this is checked, the associated key will be removed from the player's inventory when the door is unlocked.")]
    private bool consumesKey;

    [SerializeField]
    [Tooltip("The text that is displayed when the player looks at the door while it's locked.")]
    private string lockedDisplayText = "Locked";

    [SerializeField]
    [Tooltip("Play this audio clip when the player interacts with a locked door without having the key.")]
    private AudioClip lockedAudioClip;

    [SerializeField]
    [Tooltip("Play this audio clip when the player opens the door.")]
    private AudioClip openAudioClip;

    public override string DisplayText
    {
        get
        {
            string toReturn;

            if (isLocked)
                toReturn = HasKey ? $"Use {key.ObjectName}" : lockedDisplayText;
            else
                toReturn = base.DisplayText;

            return toReturn;
        }
    }

    private bool HasKey => PlayerInventory.InventoryObjects.Contains(key);
    private Animator doorAnimator;
    private bool isOpen = false;
    private bool isLocked;
    //Used to quickly access the animator parameter that opens the door
    private int doorOpenAnimParameter = Animator.StringToHash("beingOpenedByPlayer");

    /// <summary>
    /// Using a ----Constructor---- here to initialize displayText in the editor.
    /// </summary>
    public Door()
    {
        displayText = nameof(Door);
    }

    protected override void Awake()
    {
        base.Awake();
        doorAnimator = GetComponent<Animator>();
        InitializeIsLocked();
    }

    private void InitializeIsLocked()
    {
        if (key != null)
            isLocked = true;
    }

    public override void InteractWithObject()
    {
        if (!isOpen)
        {
            if(isLocked && !HasKey)
            {
                interactionSFX.clip = lockedAudioClip;
            }
            else //if it's not locked, or if it's locked and we have the key...
            {
                interactionSFX.clip = openAudioClip;
                doorAnimator.SetBool(doorOpenAnimParameter, true);
                displayText = string.Empty;
                isOpen = true;
                UnlockDoor();
            }
        }
        
    }

    private void UnlockDoor()
    {
        isLocked = false;
        if (key != null && consumesKey)
        {
            PlayerInventory.InventoryObjects.Remove(key);
        }
    }
}
