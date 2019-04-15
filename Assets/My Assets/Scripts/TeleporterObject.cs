using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }
}
