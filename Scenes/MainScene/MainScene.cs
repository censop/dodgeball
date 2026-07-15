using Godot;
using System;

public partial class MainScene : Node2D
{
	[Export] Timer _speedTimer;
	[Export] Timer _spawnTimer;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_speedTimer.Timeout += OnSpeedTimerTimeout;
		_spawnTimer.Timeout += OnSpawnBall;

		_speedTimer.Start();
		_spawnTimer.Start();
	}

    private void OnSpeedTimerTimeout()
    {
		float newSpeed = GlobalVariables.Speed * 1.5f;
        GlobalVariables.Speed = newSpeed;
		_speedTimer.Start();
		GD.Print("Speed increased");

    }


    private void OnSpawnBall()
    {
        
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
	{
	}
}
