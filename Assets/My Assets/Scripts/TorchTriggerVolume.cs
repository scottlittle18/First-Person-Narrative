using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
