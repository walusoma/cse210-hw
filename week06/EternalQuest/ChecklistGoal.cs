public class ChecklistGoal : Goal
{
    private int _target;
    private int _count;
    private int _bonus;

    public ChecklistGoal(string name, string desc, int points, int target, int bonus)
        : base(name, desc, points)
    {
        _target = target;
        _bonus = bonus;
        _count = 0;
    }

    public override int RecordEvent()
{
    if (_count < _target)
    {
        _count++;

        if (_count == _target)
        {
            return _points + _bonus;
        }

        return _points;
    }

    return 0;
}

    public override bool IsComplete()
    {
        return _count >= _target;
    }

    public override string GetDetailsString()
    {
        return $"[{(_count >= _target ? "X" : " ")}] {_name} ({_description}) -- Completed {_count}/{_target}";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal:{_name},{_description},{_points},{_bonus},{_target},{_count}";
    }
}