using Godot;
using System;

public partial class GlobalVariables : Node
{
    public static GlobalVariables Instance {private set; get;}
    public static float Speed = 200f;

    public override void _EnterTree()
    {
        Instance = this;
    }

}
