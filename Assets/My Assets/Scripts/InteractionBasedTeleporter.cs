using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
