using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///     Activates the Fire Particle Effects on all of the torches upon collision with the player
/// </summary>

public class TorchTriggerVolume : MonoBehaviour
{
    private GameObject[] torchFlameObjects;

    private void Awake()
    {
        if (GameObject.FindGameObjectsWithTag("TorchFlame") != null)
        {
            torchFlameObjects = GameObject.FindGameObjectsWithTag("TorchFlame");

            //Turn off torch flames when the level begins
            foreach (GameObject go in torchFlameObjects)
            {
                go.GetComponent<ParticleSystem>().Stop(true);
            }
        }
        else
            Debug.Log("No Game objects with the tag 'TorchFlame' were found"); //TODO: Debug Torch Trigger
        // ^ Debug is left in just in case the asset changes later and no longer uses a particle effect
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.tag == "Player")
        {
            //Turn on torch flames when the player collides with the TorchTriggerVolume GameObject
            foreach (GameObject go in torchFlameObjects)
            {
                go.GetComponent<ParticleSystem>().Play(true);
            }
        }
    }
}
