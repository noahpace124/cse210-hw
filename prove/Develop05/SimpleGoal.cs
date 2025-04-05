using System;

class SimpleGoal : Goal
{
    public SimpleGoal(string name = "", string description = "", int points = 0, bool isComplete = false) : base(name, description, points, isComplete)
    {
        _type = "SimpleGoal";
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