using System;
using System.Runtime.InteropServices.Marshalling;

class Goal 
{
    protected string _type;
    protected string _name;
    protected string _description;
    protected int _points;
    protected bool _isComplete;

    public Goal(string name = "", string description = "", int points = 0, bool isComplete = false)
    {
        _type = "Goal";
        if (name == "") {
            Console.Write("What is the name of your goal? ");
            _name = Console.ReadLine();
        }
        else {
            _name = name;
        }
        if (description == "") {
            Console.Write("What is a short description of it? ");
            _description = Console.ReadLine();
        }
        else {
            _description = description;
        }
        if (points == 0) {
            Console.Write("What is the amount of points associated with this goal? ");
            _points = int.Parse(Console.ReadLine());
        }
        else {
            _points = points;
        }
        _isComplete = isComplete;
    }

    public virtual string GetGoal()
    {
        string output = "";
        if (_isComplete)
        {
            output = "[X] " + _name + " (" + _description + ")";
        }
        else
        {
            output = "[ ] " + _name + " (" + _description + ")";
        }
        return output;
    }

    public virtual int Complete()
    {
        Console.WriteLine($"Congratulations! You have earned {_points} points!");
        return _points;
    }

    public virtual string GetStringRepresentation()
    {
        string output = $"{_type},{_name},{_description},{_points},{_isComplete}";
        return output;
    }
    
}