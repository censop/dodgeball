using Godot;
using System;

public partial class SignalHub : Node
{
    public static SignalHub Instance {private set; get;}
    [Signal] public delegate void OnGameOverEventHandler();
    public override void _Ready()
    {
        Instance = this;
    }

    public static void EmitGameOver()
    {
        Instance.EmitSignal(SignalName.OnGameOver);
    }

}
