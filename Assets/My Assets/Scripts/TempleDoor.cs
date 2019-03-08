using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TempleDoor : MonoBehaviour
{
    private Animator templeDoor_Anim;
    private BoxCollider templeDoor_Col;

    private void Start()
    {
        templeDoor_Anim = GetComponent<Animator>();
        templeDoor_Col = GetComponent<BoxCollider>();
    }
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.tag == "Player")
        {
            Debug.Log("The Door's Collider sees you.");
            templeDoor_Anim.SetBool("Opened", true);
        }
    }
}
