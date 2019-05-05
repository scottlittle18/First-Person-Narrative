using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles the input and logic related to interacting with targeted objects.
/// </summary>
public class InteractWithLookedAtObject : MonoBehaviour
{
    private IInteractive lookedAtInteractive;
    
    private bool inventoryOpen;

    // Update is called once per frame
    private void Update()
    {
        //Used to check if the player is currently in their inventory...
        inventoryOpen = InventoryMenu.Instance.IsVisible;
        //If they are, and they try to interact with anything outside of the InventoryMenu, they won't be able to.
        if (Input.GetButtonDown("Interact") && lookedAtInteractive != null && !inventoryOpen)
        {
            lookedAtInteractive.InteractWithObject();
        }
    }

    /// <summary>
    /// Event Handler for DetectLookedAtInteractive.LookedAtInteractiveChanged
    /// </summary>
    /// <param name="newLookedAtInteractive">Reference to the new IInteractive the Player is looking at.</param>
    private void OnLookedAtInteractiveChanged(IInteractive newLookedAtInteractive)
    {
        lookedAtInteractive = newLookedAtInteractive;
    }

    #region Event Subscription / Unsubscription
    private void OnEnable()
    {
        DetectLookedAtInteractive.LookedAtInteractiveChanged += OnLookedAtInteractiveChanged;
    }

    private void OnDisable()
    {
        DetectLookedAtInteractive.LookedAtInteractiveChanged -= OnLookedAtInteractiveChanged;
    }
    #endregion
}
