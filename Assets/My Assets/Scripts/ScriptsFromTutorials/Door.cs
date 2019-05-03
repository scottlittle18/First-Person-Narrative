using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Door : InteractiveObject
{
    private Animator doorAnimator;

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
        base.InteractWithObject();
        doorAnimator.SetBool("beingOpenedByPlayer", true);
    }
}
