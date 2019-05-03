using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Door : InteractiveObject
{
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
        if (!isOpen)
        {
            base.InteractWithObject();
            doorAnimator.SetBool(doorOpenAnimParameter, true);
            displayText = string.Empty;
            isOpen = true;
        }
    }
}
