using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public enum State
{
    Inactive, 
    Running, 
    Complete
}

[CreateAssetMenu(menuName = "Quest/Task/Task", fileName = "task")]
public class Task : ScriptableObject
{
    [Header("ID")]
    [SerializeField]
    private string id;
    [SerializeField]
    private string description;

    [Header("Settings")]
    [SerializeField]
    private int successCount;
    [SerializeField]
    private InitialSuccessValue initialSuccessValue;
    [SerializeField]
    private bool RecieveValue;

    [Header("Action")]
    [SerializeField]
    private TaskAction action;

    [Header("Target")]
    [SerializeField]
    private Target[] targets;

    [Header("Category")]
    [SerializeField]
    private Category category;

    private State state;
    private int currentSuccess;

    #region delegate
    public delegate void OnStateChanged(Task task, State nowState, State oldState);
    public delegate void OnCompleted(Task task, int success, int oldSuccess);
    #endregion

    public OnStateChanged onStateChanged;
    public OnCompleted onCompleted;

    #region property
    public int Success { get; private set; }
    public string Description => description;
    public string ID => id;
    public int SuccessCount => successCount;
    public Category Category => category;
    public Quest Owner { get; private set; }
    public State State
    {
        get => state;
        set
        {
            var preState = state;
            state = value;
            onStateChanged?.Invoke(this, preState, value);
        }
    }
    
    public bool IsComplete => State == State.Complete;

    public int CurrentSuccess
    {
        get => currentSuccess;
        set
        {
            int preSuccess = currentSuccess;
            currentSuccess = Mathf.Clamp(value, 0, successCount);
            if(currentSuccess != preSuccess)
            {
                State = currentSuccess == successCount ? State.Complete : State.Running;
            }
        }
    }
    #endregion

    /// <summary>
    /// Throw Success value
    /// </summary>
    /// <param name="_successCount">Success Count</param>
    public void Receive(int _successCount)
    {
        Success = action.Run(this, Success, _successCount);
    }

    public bool IsTarget(string category, object target) => Category == category && targets.Any(x => x.IsTarget(target)) && !IsComplete;

    public void Start()
    {
        State = State.Running;
        if (initialSuccessValue)
            currentSuccess = initialSuccessValue.GetValue(this);
    }

    public void End()
    {
        onStateChanged = null;
        onCompleted = null;
    }

    public void Complete()
    {
        CurrentSuccess = SuccessCount;
    }

    internal void Setup(Quest owner)
    {
        Owner = owner;
    }
}
