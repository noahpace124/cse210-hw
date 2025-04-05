using System;

class EternalGoal : Goal
{
    public EternalGoal(string name = "", string description = "", int points = 0, bool isComplete = false) : base(name, description, points, isComplete)
    {
        _type = "EternalGoal";
    }

    public override string GetGoal()
    {
        return base.GetGoal();
    }

    public override int Complete()
    {
        base._isComplete = true;
        return base.Complete();
    }
}