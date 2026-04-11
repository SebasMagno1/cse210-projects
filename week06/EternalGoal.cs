public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points)
    {
    }

    public override int RecordEvent()
    {
        return _points; // always gives points
    }

    public override bool IsComplete()
    {
        return false; // never complete
    }

    public override string GetStatusString()
    {
        return "[∞]";
    }

    public override string GetSaveString()
    {
        return $"Eternal|{_name}|{_description}|{_points}";
    }
}