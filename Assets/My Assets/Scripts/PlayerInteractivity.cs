using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// Detects interactive elements the player is looking at
/// </summary>
public class PlayerInteractivity : MonoBehaviour
{
    #region Serialized Fields
    [Tooltip("The starting point of the raycast used to detect interactive objects.")]
    [SerializeField]
    private Transform raycastOrigin;

    [Tooltip("Determines how far from the raycastOrigin we will search for interactive elements.\n {Initial Value == 5}")]
    [SerializeField]
    private float maxRange = 5.0f;

    [Tooltip("Controls the amount of time that a Display Text will be shown.")]
    [SerializeField]
    private float textDisplayTimer = 2.0f;
    #endregion
    #region Non-Serialized Private Fields
    private RaycastHit hitInfo;
    private bool objectWasDetected;
    //TODO: Hard Coded For Testing
    private GameObject carText;
    private GameObject lockedTempleText;
    private GameObject lockedDoorText;
    #endregion

    private GameObject[] textMeshObjects;

    IEnumerator FlexibleTextDisplayTimer(GameObject textMeshObject)
    {
        Debug.Log("Flexible Enumerator Entered");

        //Make Text Visible
        textMeshObject.GetComponent<MeshRenderer>().enabled = true;

        yield return new WaitForSecondsRealtime(textDisplayTimer);

        //Make Text Invisible
        textMeshObject.GetComponent<MeshRenderer>().enabled = false;
    }

    private void Awake()
    {
        carText = GameObject.Find("Car_TextMesh");
        carText.GetComponent<MeshRenderer>().enabled = false;

        lockedTempleText = GameObject.Find("LockedTempleMainDoor_TextMesh");
        lockedTempleText.GetComponent<MeshRenderer>().enabled = false;

        textMeshObjects = GameObject.FindGameObjectsWithTag("TextMeshObjects");
        foreach (GameObject TM in textMeshObjects)
        {
            TM.GetComponent<MeshRenderer>().enabled = false;
        }
    }

    private void FixedUpdate()
    {
        //Used to create a line that represents the length of the actual raycast
        Debug.DrawRay(raycastOrigin.position, raycastOrigin.forward * maxRange, Color.red);
        
        objectWasDetected = Physics.Raycast(raycastOrigin.position, raycastOrigin.forward, out hitInfo, maxRange);
    }
    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && objectWasDetected)
        {
            ClickHandler();
        }
    }

    private void ClickHandler()
    {
        //TODO: Keeping in place for when other interactive objects are added.
        Debug.Log($"{hitInfo.collider.name} was the object hit");

        if (hitInfo.collider.tag == "TeleportationObject")
        {
            hitInfo.collider.GetComponent<Animator>().SetTrigger("Teleport");
            //TODO: Keeping for when the final asset is added
            Debug.Log("Teleportation Anim_Trigger Activated!");
        }
        else if (hitInfo.collider.tag == "TempleKey")
        {
            hitInfo.collider.GetComponent<Animator>().SetTrigger("Teleport");
        }
        else if (hitInfo.collider.tag == "TempleDoor")
        {
            if (this.GetComponent<PlayerInventory>().hasKey == true)
            {
                hitInfo.collider.GetComponentInParent<TempleMainDoors>().OpenDoor();
            }
            else
            {
                StartCoroutine(FlexibleTextDisplayTimer(lockedTempleText));
            }
        }
        else if (hitInfo.collider.tag == "LockedDoor")
        {
            lockedDoorText = hitInfo.collider.transform.GetChild(0).gameObject;
            Debug.Log(lockedDoorText.name);
            StartCoroutine(FlexibleTextDisplayTimer(lockedDoorText));
            //hitInfo.collider.GetComponent<Door_Unlocked>().OpenDoor();
        }
        {
            switch (hitInfo.collider.gameObject.name)
            {
                case "CarBody":
                    //Display Text for a set period of time
                    StartCoroutine(FlexibleTextDisplayTimer(carText));
                    break;

                case "TempleKeyStorage_Door_Unlocked":
                    //Open Door of the first Temple Key Storage building
                    hitInfo.collider.GetComponent<Door_Unlocked>().OpenDoor();
                    break;

                default:
                    Debug.Log("No Object Not Detected");
                    break;
            }
        }
    }
}
