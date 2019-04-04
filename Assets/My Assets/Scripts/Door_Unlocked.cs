using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Unlocked : MonoBehaviour
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
