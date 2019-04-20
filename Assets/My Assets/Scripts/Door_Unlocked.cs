using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///     This handles the doors that are already open and don't need a key to be unlocked. 
/// *This uses the IOpenable Interface.
/// </summary>

public class Door_Unlocked : MonoBehaviour, IOpenable
{
    private Animator doorAnim;

    // Start is called before the first frame update
    void Start()
    {
        doorAnim = GetComponent<Animator>();
    }

    public void OpenDoor()
    {
        doorAnim.SetBool("Open", true);
    }
}
