using System;

class ChecklistGoal : Goal
{
    private int _bonusCount;
    private int _bonusPoints;
    private int _currentCount;

    public ChecklistGoal(string name = "", string description = "", int points = 0, bool isComplete = false, int bonusCount = 0, int bonusPoints = 0, int currentCount = 0) : base(name, description, points, isComplete)
    {
        _type = "ChecklistGoal";
        if (bonusCount == 0)
        {
            Console.Write("How many times does this goal need to be accomplished for a bonus? ");
            _bonusCount = int.Parse(Console.ReadLine());
        }
        else
        {
            _bonusCount = bonusCount;
        }
        if (bonusPoints == 0)
        {
            Console.Write("What is the bonus for accomplishing it that many times? ");
            _bonusPoints = int.Parse(Console.ReadLine());
        }
        else
        {
            _bonusPoints = bonusPoints;
        }
        _currentCount = currentCount;
    }

    public override string GetGoal()
    {
        string str = base.GetGoal();
        str += $" -- Currently completed: {_currentCount}/{_bonusCount}";
        return str;
    }

    public override int Complete()
    {
        _currentCount++;
        if (_currentCount == _bonusCount)
        {
            base._isComplete = true;
            return base.Complete() + _bonusPoints;
        }
        else
        {
            return base.Complete();
        }
    }

    public override string GetStringRepresentation()
    {
        string output = base.GetStringRepresentation();
        output += $",{_bonusCount},{_bonusPoints},{_currentCount}";
        return output;
    }
}