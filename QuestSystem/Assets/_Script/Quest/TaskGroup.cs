using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static Task;
using static UnityEngine.UI.GridLayoutGroup;

public enum TaskGroupState
{
    Inactive,
    Running,
    Complete,
}

[Serializable]
public class TaskGroup 
{
    #region
    [SerializeField]
    private Task[] taskGroup;

    public IReadOnlyList<Task> Tasks => taskGroup;

    public Quest Owner { get; private set; }

    public bool AutoComplete => taskGroup.All(x => x.IsComplete);

    public TaskGroupState State { get; private set; }
    public bool IsComplete => State == TaskGroupState.Complete;
    #endregion

    public void Setup(Quest owner)
    {
        Owner = owner;
        foreach (var task in taskGroup)
        {
            task.Setup(owner);
        }
    }
    public void Start()
    {
        State = TaskGroupState.Running;
        foreach (var task in taskGroup)
        {
            task.Start();
        }
    }

    public void End()
    {
        State = TaskGroupState.Complete;
        foreach (var task in taskGroup)
        {
            task.End();
        }
    }

    public void Complete()
    {
        if (IsComplete)
            return;

        State = TaskGroupState.Complete;
        foreach (var task in taskGroup)
        {
            if(!task.IsComplete)
                task.Complete();
        }
    }

    public void Receive(string category, object target, int successCount)
    {
        foreach (var task in taskGroup)
        {
            if (task.IsTarget(category, target))
            {
                task.Receive(successCount);
            }
        }
    }
}
