using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempleMainDoors : MonoBehaviour
{
    private Animator leftTempleDoor_Anim, rightTempleDoor_Anim;
    private Animator[] templeDoor_Anim;
    private BoxCollider templeDoor_Col;

    private void Start()
    {
        templeDoor_Anim = GetComponentsInChildren<Animator>();
        //rightTempleDoor_Anim = GetComponent<Animator>();
        //templeDoor_Col = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("The Door's Collider sees you.");
            foreach (Animator anim in templeDoor_Anim)
            {
                anim.SetBool("Open", true);
            }
        }
    }
}
