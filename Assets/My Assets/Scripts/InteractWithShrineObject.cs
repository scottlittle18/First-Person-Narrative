using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractWithShrineObject : InteractiveObject
{
    public InteractWithShrineObject()
    {
        displayText = nameof(InteractWithShrineObject);
    }

    // Update is called once per frame
    public override void InteractWithObject()
    {
        base.InteractWithObject();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
