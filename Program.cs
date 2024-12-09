using System;

public delegate void Notify();  // delegate

public class ProcessBusinessLogic
{
    public event Notify? ProcessHalfWay; // event based on delegate
    public event Notify? ProcessCompleted;
    public void StartProcess()
    {
        Console.WriteLine("Process Started!");
        Thread.Sleep(10000);
        OnProcessHalfWay();
        Thread.Sleep(10000);
        OnProcessCompleted();

    }

    protected virtual void OnProcessHalfWay()
    {
        ProcessHalfWay?.Invoke(); // if ProcessHalfWay is not null then call delegate
    }

    protected virtual void OnProcessCompleted()
    {
        ProcessCompleted?.Invoke(); // if ProcessCompleted is not null then call delegate
    }
}

public class Program
{
    public static void Main()
    {
        ProcessBusinessLogic bl = new ProcessBusinessLogic();
        bl.ProcessCompleted += Bl_OnProcessHalfWay; // register with an event
        bl.ProcessCompleted += Bl_ProcessCompleted; // register with an event
        bl.StartProcess();
    }

    public static void Bl_OnProcessHalfWay()
    {
        Console.WriteLine("Process Completed 50%");
    }

    public static void Bl_ProcessCompleted()
    {
        Console.WriteLine("Process Completed!");
    }
}
