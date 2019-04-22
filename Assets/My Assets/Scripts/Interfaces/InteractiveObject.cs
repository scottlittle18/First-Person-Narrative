using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Allows an object to be interacted with.
/// </summary>

public class InteractiveObject : MonoBehaviour, IInteractive
{
    [SerializeField]
    private string displayText = nameof(InteractiveObject);

    public string DisplayText => displayText;

    public void InteractWithObject()
    {
        //TODO: Interact w/ Object Debug.Log
        Debug.Log($"Player just interacted with {gameObject.name}.");
    }
}
