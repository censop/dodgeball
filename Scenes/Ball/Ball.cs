using Godot;
using System;

public partial class Ball : RigidBody2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		float randY = (float)GD.RandRange(-1.0, 1.0);
		LinearVelocity = new Vector2(1, randY).Normalized() * GlobalVariables.Speed;
	}

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _PhysicsProcess(double delta)
	{
		LinearVelocity = LinearVelocity.Normalized() * GlobalVariables.Speed;
	}
}
