using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Used to identify the object the player is looking at.
/// </summary>
public class DetectLookedAtInteractive : MonoBehaviour
{
    #region Serialized Fields
    [Tooltip("The starting point of the raycast used to detect interactive objects.")]
    [SerializeField]
    private Transform raycastOrigin;

    [Tooltip("Determines how far from the raycastOrigin we will search for interactive elements.\n {Initial Value == 5}")]
    [SerializeField]
    private float maxRange = 5.0f;
    #endregion

    /// <summary>
    /// Event raised when the player looks at a different IInteractive
    /// </summary>
    public static event Action<IInteractive> LookedAtInteractiveChanged;

    #region Non-Serialized Private Fields
    private RaycastHit hitInfo;
    private bool objectWasDetected;
    private IInteractive lookedAtInteractive;
    #endregion

    public IInteractive LookedAtInteractive
    {
        get { return lookedAtInteractive; }
        private set
        {
            bool isInteractiveChanged = value != lookedAtInteractive;
            if (isInteractiveChanged)
            {
                lookedAtInteractive = value;
                LookedAtInteractiveChanged?.Invoke(lookedAtInteractive);
            }
        }
    }

    private void FixedUpdate()
    {
        LookedAtInteractive = GetLookedAtInteractive();
    }

    private IInteractive GetLookedAtInteractive()
    {
        //Used to create a line that represents the length of the actual raycast
        Debug.DrawRay(raycastOrigin.position, raycastOrigin.forward * maxRange, Color.red);

        objectWasDetected = Physics.Raycast(raycastOrigin.position, raycastOrigin.forward, out hitInfo, maxRange);

        IInteractive interactive = null;

        if (objectWasDetected)
        {
            interactive = hitInfo.collider.gameObject.GetComponent<IInteractive>();
        }

        return interactive;
    }
}
