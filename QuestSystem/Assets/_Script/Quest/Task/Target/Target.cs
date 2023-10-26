using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Target : ScriptableObject
{
    public abstract object Value { get; }

    public abstract bool IsTarget(object target);
}
