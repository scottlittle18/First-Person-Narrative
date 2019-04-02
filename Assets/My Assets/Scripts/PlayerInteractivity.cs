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

    private RaycastHit hitInfo;

    private bool objectWasDetected;

    //TODO: Hard Coded For Testing
    private GameObject brokenCarText;

    IEnumerator TextDisplayTimer()
    {
        Debug.Log("Enumerator Entered");

        //Make Text Visible
        brokenCarText.GetComponent<MeshRenderer>().enabled = true;
        
        yield return new WaitForSecondsRealtime(textDisplayTimer);

        //Make Text Invisible
        brokenCarText.GetComponent<MeshRenderer>().enabled = false;
    }

    private void Awake()
    {
        brokenCarText = GameObject.Find("BrokenCar_TextMesh");
        brokenCarText.GetComponent<MeshRenderer>().enabled = false;
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
        Debug.Log("Click!");
        Debug.Log($"{hitInfo.collider.name} was the object hit");

        switch (hitInfo.collider.gameObject.name)
        {
            case "CarBody":
                //Display Text for a set period of time
                StartCoroutine(TextDisplayTimer());
                break;

            default:
                Debug.Log("No Object Not Detected");
                break;
        }
    }
}
