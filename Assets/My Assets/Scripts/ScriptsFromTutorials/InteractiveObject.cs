using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Allows an object to be interacted with.
/// </summary>
[RequireComponent(typeof(AudioSource))]
public class InteractiveObject : MonoBehaviour, IInteractive
{
    [SerializeField]
    protected string displayText = nameof(InteractiveObject);
    private AudioSource interactionSFX;

    public string DisplayText => displayText;

    private void Awake()
    {
        interactionSFX = GetComponent<AudioSource>();
    }

    public virtual void InteractWithObject()
    {
        try
        {
            interactionSFX.PlayOneShot(interactionSFX.clip);
        }
        catch (System.Exception)
        {

            throw new System.Exception("Game Object is Missing Audio Source Component.");
        }
        //TODO: Interact w/ Object Debug.Log
        Debug.Log($"Player just interacted with {gameObject.name}.");
    }
}
