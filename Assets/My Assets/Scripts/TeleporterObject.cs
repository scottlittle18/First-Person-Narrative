using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///     This script will be attached to any objects that will be used to teleport the
/// player to another location. *This script is a sub-class of the 
/// InteractionBasedTeleporter class.
/// </summary>

public class TeleporterObject : InteractionBasedTeleporter
{
    [SerializeField]
    [Tooltip("The Game Object that will act as the teleportation target.")]
    private GameObject playerTeleportationTarget;

    private GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        //SetTeleportationTarget(playerTeleportationTarget.transform);
    }

    public void Teleport()
    {
        player = GameObject.Find("RigidBodyFPSController");
        player.transform.position = playerTeleportationTarget.transform.position;
        if(this.tag == "TeleportationObject")
            Destroy(this.gameObject, GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + 0.1f);
        //TODO: Else if (PlayerPicksUpKey){...}
    }
}
