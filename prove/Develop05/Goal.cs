using System;

public abstract class Goal
{
    public string Name { get; protected set; }
    public int Value { get; protected set; }
    public bool IsCompleted { get; protected set; }

    public Goal(string name, int value)
    {
        Name = name;
        Value = value;
        IsCompleted = false;
    }

    public abstract int RecordEvent();
    public abstract string GetDetailsString();
}   