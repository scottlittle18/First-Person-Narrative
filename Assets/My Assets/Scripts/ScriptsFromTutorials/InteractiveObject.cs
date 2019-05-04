﻿using System.Collections;
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
    protected AudioSource interactionSFX;

    public virtual string DisplayText => displayText;

    protected virtual void Awake()
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

            throw new System.Exception("Missing AudioSource component or Audio Clip: InteractiveObject requires an AudioSource with an assigned AudioClip.");
        }
        //TODO: Interact w/ Object Debug.Log
        Debug.Log($"Player just interacted with {gameObject.name}.");
    }
}
