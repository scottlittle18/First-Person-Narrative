using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Door : InteractiveObject
{
    [SerializeField]
    [Tooltip("Check this box to lock this door.")]
    private bool locked;

    [SerializeField]
    [Tooltip("The text that is displayed when the player looks at the door while it's locked.")]
    private string lockedDisplayText = "Locked";

    [SerializeField]
    [Tooltip("Play this audio clip when the player interacts with a locked door without having the key.")]
    private AudioClip lockedAudioClip;

    [SerializeField]
    [Tooltip("Play this audio clip when the player opens the door.")]
    private AudioClip openAudioClip;

    public override string DisplayText => locked ? lockedDisplayText : base.DisplayText;

    private Animator doorAnimator;
    private bool isOpen = false;
    //Used to quickly access the animator parameter that opens the door
    private int doorOpenAnimParameter = Animator.StringToHash("beingOpenedByPlayer");

    /// <summary>
    /// Using a constructor here to initialize displayText in the editor.
    /// </summary>
    public Door()
    {
        displayText = nameof(Door);
    }

    protected override void Awake()
    {
        base.Awake();
        doorAnimator = GetComponent<Animator>();
    }

    public override void InteractWithObject()
    {
        if (!locked)
        {
            interactionSFX.clip = openAudioClip;
            doorAnimator.SetBool(doorOpenAnimParameter, true);
            displayText = string.Empty;
            isOpen = true;
        }
        else //if door is locked...
        {
            interactionSFX.clip = lockedAudioClip;
        }

        base.InteractWithObject();
    }
}
