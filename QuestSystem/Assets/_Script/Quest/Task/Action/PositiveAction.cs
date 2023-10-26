using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Quest/Task/PositiveAction", fileName = "positive action")]
public class PositiveAction : TaskAction
{
    public override int Run(Task task, int success, int successCount)
    {
        return successCount > 0 ? success + successCount : successCount;
    }
}
