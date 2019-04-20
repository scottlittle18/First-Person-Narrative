using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///     This is the parent class of any objects that teleport the player based on
/// the user's input.
/// </summary>

public class InteractionBasedTeleporter : MonoBehaviour
{
    private Transform currentPlayerPosition;
    private Transform teleportationTarget;
    //private AudioClip activationSFX; <-- For later use

    protected virtual void SetTeleportationTarget(Transform target)
    {
        //Use the script that will be attached to the teleporter objects to set this on Start or Awake
        teleportationTarget = target;
    }
}
