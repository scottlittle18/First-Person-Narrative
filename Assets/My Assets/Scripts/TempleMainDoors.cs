using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempleMainDoors : MonoBehaviour
{
    private Animator[] templeDoor_Anim;

    private void Start()
    {
        templeDoor_Anim = GetComponentsInChildren<Animator>();
    }

    public void OpenDoor()
    {
        foreach (Animator anim in templeDoor_Anim)
        {
            anim.SetBool("Open", true);
        }
    }
}
