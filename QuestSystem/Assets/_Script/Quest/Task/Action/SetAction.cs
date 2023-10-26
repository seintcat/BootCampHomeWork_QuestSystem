using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Quest/Task/SetAction", fileName = "set action")]
public class SetAction : TaskAction
{
    public override int Run(Task task, int success, int successCount)
    {
        return successCount;
    }
}
