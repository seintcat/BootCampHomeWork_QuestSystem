using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(menuName = "Quest/Task/OneCountAction", fileName = "one count action")]
internal class OneCountAction : TaskAction
{
    /// <summary>
    /// Add now + success
    /// </summary>
    /// <param name="task">task</param>
    /// <param name="success">now success</param>
    /// <param name="successCount">new success</param>
    /// <returns></returns>
    public override int Run(Task task, int success, int successCount)
    {
        return success + successCount;
    }
}