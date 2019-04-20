using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///     Will be attached to the trigger volume that the player will walk through at the bottom of the entry slope.
/// Once triggered, this script will then turn on the fire particle effects attached to the torches.
/// </summary>

public class TorchTriggerVolume : MonoBehaviour
{
    private List<ParticleSystem> torchFires;

    // Start is called before the first frame update
    private void Awake()
    {
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("TorchFire"))
        {
            torchFires.Add(go.GetComponent<ParticleSystem>());
        }

        foreach (ParticleSystem pS in torchFires)
        {
            pS.Stop();
            //pS.emission.SetBurst(new ParticleSystem.Burst(0.5f, 100);
        }
    }
}
