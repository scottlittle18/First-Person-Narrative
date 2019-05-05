﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

/// <summary>
/// Used to control all of the logic for what the menu does and how it behaves.
/// </summary>
public class InventoryMenu : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The InventoryMenuItem prefab to be instantiated when an item is added to the player's inventory.")]
    private GameObject inventoryMenuItemTogglePrefab;

    [SerializeField]
    [Tooltip("This is the Content object that will contain the player's inventory.")]
    private Transform inventoryListContentArea;

    [SerializeField]
    [Tooltip("Place in the UI for displaying the name of the selected inventory item.")]
    private TextMeshProUGUI itemLabelText;

    [SerializeField]
    [Tooltip("Place in the UI for displaying info about the selected inventory item.")]
    private TextMeshProUGUI itemDescriptionText;

    private static InventoryMenu instance;
    private RigidbodyFirstPersonController rigidbodyFirstPersonController;
    private CanvasGroup canvasGroup;
    private AudioSource audioSource;

    public static InventoryMenu Instance
    {
        get
        {
            if (instance == null)
                throw new System.Exception("There is currently no InventoryMenu instance, " +
                    "but you are trying to access it! Make sure the InventoryMenu script is applied to a GameObject in the scene.");

            return instance;
        }
        private set { instance = value; }
    }

    public bool IsVisible => canvasGroup.alpha > 0;

    public void ExitMenuButtonClicked()
    {
        HideMenu();
    }

    /// <summary>
    /// Instantiates a new InventoryMenuItemToggle prefab and adds it to the menu.
    /// </summary>
    /// <param name="inventoryObjectToAdd"></param>
    public void AddItemToMenu(InventoryObject inventoryObjectToAdd)
    {
        GameObject clone = Instantiate(inventoryMenuItemTogglePrefab, inventoryListContentArea);
        InventoryMenuItemToggle toggle = clone.GetComponent<InventoryMenuItemToggle>();
        toggle.AssociatedInventoryObject = inventoryObjectToAdd;
    }

    private void ShowMenu()
    {
        canvasGroup.alpha = 1;
        canvasGroup.interactable = true;
        rigidbodyFirstPersonController.enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    private void HideMenu()
    {
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        rigidbodyFirstPersonController.enabled = true;
    }

    /// <summary>
    /// This is the event handler for InventoryMenuItemSelected
    /// </summary>
    private void OnInventoryMenuItemSelected(InventoryObject inventoryObjectThatWasSelected)
    {
        itemLabelText.text = inventoryObjectThatWasSelected.ObjectName;
        itemDescriptionText.text = inventoryObjectThatWasSelected.Description;
    }

    #region Event Subscription / Unsubscription
    private void OnEnable()
    {
        InventoryMenuItemToggle.InventoryMenuItemSelected += OnInventoryMenuItemSelected;
    }

    private void OnDisable()
    {
        InventoryMenuItemToggle.InventoryMenuItemSelected -= OnInventoryMenuItemSelected;
    }
    #endregion

    private void Update()
    {
        HandleInventoryDisplayToggleInput();
    }

    private void HandleInventoryDisplayToggleInput()
    {
        if (Input.GetButtonDown("ToggleInventoryMenu"))
        {
            if (IsVisible)
                HideMenu();
            else
                ShowMenu();

            audioSource.Play();
        }
    }

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            throw new System.Exception("There is already an instance of InventoryMenu and there can only be one.");

        canvasGroup = GetComponent<CanvasGroup>();
        rigidbodyFirstPersonController = FindObjectOfType<RigidbodyFirstPersonController>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        HideMenu();
    }
}