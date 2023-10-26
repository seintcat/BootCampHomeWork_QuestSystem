using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// init succes data
/// </summary>
public abstract class InitialSuccessValue : ScriptableObject
{
    public abstract int GetValue(Task task);
}
