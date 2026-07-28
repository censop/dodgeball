using Godot;
using System;

public partial class CollisionArea : Area2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		BodyEntered += OnBodyEntered;
	}

    private void OnBodyEntered(Node2D body)
    {
        if (body is Ball)
		{
			SignalHub.EmitGameOver();
			GD.Print("Game over");
			GetTree().Paused = true;
		}
    }
}
