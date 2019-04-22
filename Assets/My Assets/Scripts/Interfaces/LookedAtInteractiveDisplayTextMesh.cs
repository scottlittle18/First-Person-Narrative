using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
///     This UI TextMeshPro object displays info about the currently looked at interactive IInteractive.
/// This text should be hidden if the player is not curently looking at an interactive element.
/// </summary>

public class LookedAtInteractiveDisplayTextMesh : MonoBehaviour
{
    private IInteractive lookedAtInteractive;
    private TextMeshPro displayText;

    private void Awake()
    {
        displayText = GetComponent<TextMeshPro>();
    }

    private void UpdateDisplayText()
    {
        if (lookedAtInteractive != null)
        {
            displayText.text = lookedAtInteractive.DisplayText;
        }
        else
            displayText.text = string.Empty;
    }
}