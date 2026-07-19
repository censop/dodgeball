using Godot;
using System;

public partial class MainScene : Node2D
{
	[Export] Timer _speedTimer;
	[Export] Timer _spawnTimer;
	[Export] PackedScene _ballScene;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GD.Randomize();

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
		Node2D ballInstance = _ballScene.Instantiate<Node2D>();
		ballInstance.GlobalPosition = new Vector2(25f, 160f);
		AddChild(ballInstance);
        
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
	{
	}
}
