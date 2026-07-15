using Godot;
using System;

public partial class SignalHub : Node
{
    public static SignalHub Instance {private set; get;}
    public override void _Ready()
    {
        Instance = this;
    }

}
