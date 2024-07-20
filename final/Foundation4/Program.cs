using System;


//Exercise tracking polymorphism program
public abstract class Activity
{
    public DateTime Date { get; set; }
    public int Duration { get; set; } // Duration in minutes

    public Activity(DateTime date, int duration)
    {
        Date = date;
        Duration = duration;
    }

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    public virtual string GetSummary()
    {
        return $"{Date.ToShortDateString()} {this.GetType().Name} ({Duration} min) - Distance: {GetDistance():0.0} miles, Speed: {GetSpeed():0.0} mph, Pace: {GetPace():0.0} min per mile";
    }
}

public class Running : Activity
{
    public double Distance { get; set; } // Distance in miles

    public Running(DateTime date, int duration, double distance)
        : base(date, duration)
    {
        Distance = distance;
    }

    public override double GetDistance()
    {
        return Distance;
    }

    public override double GetSpeed()
    {
        return (Distance / Duration) * 60;
    }

    public override double GetPace()
    {
        return Duration / Distance;
    }
}

public class Cycling : Activity
{
    public double Speed { get; set; } // Speed in mph

    public Cycling(DateTime date, int duration, double speed)
        : base(date, duration)
    {
        Speed = speed;
    }

    public override double GetDistance()
    {
        return (Speed * Duration) / 60;
    }

    public override double GetSpeed()
    {
        return Speed;
    }

    public override double GetPace()
    {
        return 60 / Speed;
    }
}

public class Swimming : Activity
{
    public int Laps { get; set; } // Number of laps
    private const double LapLength = 50 / 1000.0 * 0.62; // Length of lap in miles

    public Swimming(DateTime date, int duration, int laps)
        : base(date, duration)
    {
        Laps = laps;
    }

    public override double GetDistance()
    {
        return Laps * LapLength;
    }

    public override double GetSpeed()
    {
        return (GetDistance() / Duration) * 60;
    }

    public override double GetPace()
    {
        return Duration / GetDistance();
    }
}

public class Program
{
    public static void Main()
    {
        var activities = new Activity[]
        {
            new Running(new DateTime(2024, 7, 20), 30, 3),
            new Cycling(new DateTime(2024, 7, 21), 45, 15),
            new Swimming(new DateTime(2024, 7, 22), 20, 30)
        };

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
