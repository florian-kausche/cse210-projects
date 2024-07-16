public class ChecklistGoal : Goal
{
    public int TargetCount { get; private set; }
    public int CurrentCount { get; private set; }
    public int BonusValue { get; private set; }

    public ChecklistGoal(string name, int value, int targetCount, int bonusValue) : base(name, value)
    {
        TargetCount = targetCount;
        CurrentCount = 0;
        BonusValue = bonusValue;
    }

    public override int RecordEvent()
    {
        CurrentCount++;
        if (CurrentCount == TargetCount)
        {
            IsCompleted = true;
            return Value + BonusValue;
        }
        return Value;
    }

    public override string GetDetailsString()
    {
        return $"[{(IsCompleted ? "X" : " ")}] {Name} -- Currently completed: {CurrentCount}/{TargetCount}";
    }
}