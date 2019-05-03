using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleSetActive : InteractiveObject
{
    [SerializeField]
    [Tooltip("The Game Object that will be set to active or inactive upon interaction with this object.")]
    private GameObject objectToToggle;

    [SerializeField]
    [Tooltip("Can the player toggle the specified GameObject")]
    private bool toggleable = true;

    private bool hasBeenUsed = false;

    /// <summary>
    /// Toggles the objectToToggle GameObject as active or inactive upon interaction with this object.
    /// </summary>
    public override void InteractWithObject()
    {
        if (toggleable || !hasBeenUsed)
        {
            base.InteractWithObject();
            objectToToggle.SetActive(!objectToToggle.activeSelf);
            hasBeenUsed = true;
            if (!toggleable) displayText = string.Empty;
        }
    }
}
