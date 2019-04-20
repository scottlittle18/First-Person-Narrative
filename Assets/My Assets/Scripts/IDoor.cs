using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///     This is the Interface that is used for doors that are unlockable.
/// </summary>

public interface IUnlockable
{
    void UnlockDoor();
}

public interface IOpenable
{
    void OpenDoor();
}
