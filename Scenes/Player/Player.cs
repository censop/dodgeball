using Godot;
using System;

public partial class Player : CharacterBody2D
{
	[Export] private float _walkSpeed = 80.0f;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Vector2 inputDir = Input.GetVector("walk_left", "walk_right", "walk_up", "walk_down");
		Velocity = inputDir * _walkSpeed;
		MoveAndSlide();
	}

}
