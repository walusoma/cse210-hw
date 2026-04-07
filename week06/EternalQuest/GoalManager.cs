using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    public void Start()
    {
        string choice = "";

        while (choice != "6")
        {
            Console.WriteLine($"\nYou have {_score} points.");
            Console.WriteLine($"Level: {_score / 500 + 1}"); // Creativity
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. Save Goals");
            Console.WriteLine("5. Load Goals");
            Console.WriteLine("6. Quit");
            Console.Write("Select a choice: ");

            choice = Console.ReadLine();

            if (choice == "1")
                CreateGoal();
            else if (choice == "2")
                ListGoals();
            else if (choice == "3")
                RecordEvent();
            else if (choice == "4")
                SaveGoals();
            else if (choice == "5")
                LoadGoals();
        }
    }

    private void CreateGoal()
    {
        Console.WriteLine("\nThe types of Goals are:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        string type = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();

        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();

        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        if (type == "1")
        {
            _goals.Add(new SimpleGoal(name, description, points));
        }
        else if (type == "2")
        {
            _goals.Add(new EternalGoal(name, description, points));
        }
        else if (type == "3")
        {
            Console.Write("How many times does this goal need to be accomplished? ");
            int target = int.Parse(Console.ReadLine());

            Console.Write("What is the bonus for completing it? ");
            int bonus = int.Parse(Console.ReadLine());

            _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
        }

        Console.WriteLine("Goal created successfully!");
    }

    private void ListGoals()
    {
        Console.WriteLine("\nYour Goals:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    private void RecordEvent()
    {
        Console.WriteLine("\nWhich goal did you accomplish?");
        ListGoals();

        Console.Write("Enter goal number: ");
        int index = int.Parse(Console.ReadLine()) - 1;

        if (index >= 0 && index < _goals.Count)
        {
            int earnedPoints = _goals[index].RecordEvent();
            _score += earnedPoints;

            Console.WriteLine($"Congratulations! You earned {earnedPoints} points!");
        }
        else
        {
            Console.WriteLine("Invalid selection.");
        }
    }

    private void SaveGoals()
    {
        Console.Write("Enter filename to save: ");
        string fileName = Console.ReadLine();

        using (StreamWriter output = new StreamWriter(fileName))
        {
            output.WriteLine(_score);

            foreach (Goal goal in _goals)
            {
                output.WriteLine(goal.GetStringRepresentation());
            }
        }

        Console.WriteLine("Goals saved successfully.");
    }

    private void LoadGoals()
    {
        Console.Write("Enter filename to load: ");
        string fileName = Console.ReadLine();

        if (!File.Exists(fileName))
        {
            Console.WriteLine("File not found.");
            return;
        }

        string[] lines = File.ReadAllLines(fileName);

        _goals.Clear();
        _score = int.Parse(lines[0]);

        for (int i = 1; i < lines.Length; i++)
        {
            string line = lines[i];
            string[] parts = line.Split(":");
            string type = parts[0];
            string[] details = parts[1].Split(",");

            if (type == "SimpleGoal")
            {
                SimpleGoal goal = new SimpleGoal(
                    details[0],
                    details[1],
                    int.Parse(details[2])
                );

                if (bool.Parse(details[3]))
                {
                    goal.RecordEvent();
                }

                _goals.Add(goal);
            }
            else if (type == "EternalGoal")
            {
                _goals.Add(new EternalGoal(
                    details[0],
                    details[1],
                    int.Parse(details[2])
                ));
            }
            else if (type == "ChecklistGoal")
            {
                ChecklistGoal goal = new ChecklistGoal(
                    details[0],
                    details[1],
                    int.Parse(details[2]),
                    int.Parse(details[4]),
                    int.Parse(details[3])
                );

                int completedCount = int.Parse(details[5]);

                for (int j = 0; j < completedCount; j++)
                {
                    goal.RecordEvent();
                }

                _goals.Add(goal);
            }
        }

        Console.WriteLine("Goals loaded successfully.");
    }
}