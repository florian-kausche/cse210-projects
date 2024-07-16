public class SimpleGoal : Goal
{
    public SimpleGoal(string name, int value) : base(name, value) { }

    public override int RecordEvent()
    {
        if (!IsCompleted)
        {
            IsCompleted = true;
            return Value;
        }
        return 0;
    }

    public override string GetDetailsString()
    {
        return $"[{(IsCompleted ? "X" : " ")}] {Name}";
    }
}