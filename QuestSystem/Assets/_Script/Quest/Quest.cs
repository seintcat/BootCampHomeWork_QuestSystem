using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public enum QuestState
{
    Inactive,
    Running,
    Complete,
    Cancel,
    OnComplete
}

[CreateAssetMenu(menuName = "Quest/Quest", fileName = "Quest")]
public class Quest : ScriptableObject
{
    public delegate void OnCompleted(Quest quest, Task task, int currentSuccess, int preSuccess);
    public delegate void CompletedHandler(Quest quest);
    public delegate void CancelHandler(Quest quest);
    public delegate void TaskGroupHandler(Quest quest, TaskGroup currentTaskGroup, TaskGroup preTaskGroup);

    public event OnCompleted oncompleted;
    public event CompletedHandler completedHandler;
    public event CancelHandler cancelHandler;
    public event TaskGroupHandler taskGroupHandler;

    [Header("Category")]
    [SerializeField]
    private Category category;
    [SerializeField]
    private Sprite icon;
    [Header("ID")]
    [SerializeField]
    private string id;
    [SerializeField]
    private string ingameID;
    [SerializeField, TextArea]
    private string description;
    [Header("Settings")]
    [SerializeField]
    private bool autoComplete;
    [Header("Task")]
    [SerializeField]
    private TaskGroup[] taskGroups;
    
    private int idx;

    public Category Category => category;
    public Sprite Icon => icon;
    public string ID => id;
    public string InGameID => ingameID;
    public string Description => description;

    public QuestState State { get; private set; }
    public TaskGroup CurrentGoup => taskGroups[idx];
    public IReadOnlyList<TaskGroup> TaskGroups => taskGroups;

    public bool InActive => State != QuestState.Inactive;
    public bool Running => State != QuestState.Running;
    public bool Complete => State != QuestState.Complete;
    public bool Cancel => State != QuestState.Cancel;
    public bool OnComplete => State != QuestState.OnComplete;
}
