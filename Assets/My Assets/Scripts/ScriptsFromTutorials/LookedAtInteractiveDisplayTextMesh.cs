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
    private TextMeshProUGUI displayText;

    private void Awake()
    {
        displayText = GetComponent<TextMeshProUGUI>();
        UpdateDisplayText();
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

    /// <summary>
    /// Event Handler for DetectLookedAtInteractive.LookedAtInteractiveChanged
    /// </summary>
    /// <param name="newLookedAtInteractive">Reference to the new IInteractive the Player is looking at.</param>
    private void OnLookedAtInteractiveChanged(IInteractive newLookedAtInteractive)
    {
        lookedAtInteractive = newLookedAtInteractive;
        UpdateDisplayText();
    }

    #region Event Subscription / Unsubscription
    private void OnEnable()
    {
        DetectLookedAtInteractive.LookedAtInteractiveChanged += OnLookedAtInteractiveChanged;
    }

    private void OnDisable()
    {
        DetectLookedAtInteractive.LookedAtInteractiveChanged -= OnLookedAtInteractiveChanged;
    }
    #endregion
}