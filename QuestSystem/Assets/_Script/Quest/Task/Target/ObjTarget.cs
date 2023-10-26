using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Quest/ObjTarget", fileName = "ObjTarget")]
public class ObjTarget : Target
{
    [SerializeField]
    private GameObject value;
    public override object Value => value;

    public override bool IsTarget(object target)
    {
        GameObject tartetObj = target as GameObject;
        if (tartetObj != null)
        {
            return value.name.Contains(value.name);
        }
        return false;
    }
}
