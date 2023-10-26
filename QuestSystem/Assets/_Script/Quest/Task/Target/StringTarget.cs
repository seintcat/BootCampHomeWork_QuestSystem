using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Quest/StringTarget", fileName = "StringTarget")]
public class StringTarget : Target
{
    [SerializeField]
    private string value;
    public override object Value => value;

    public override bool IsTarget(object target)
    {
        string tartetString = target as string;
        if(tartetString != null)
        {
            return value == tartetString;
        }
        return false;
    }
}
