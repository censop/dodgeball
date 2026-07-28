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
		LoadGame();

		GD.Randomize();

		_speedTimer.Timeout += OnSpeedTimerTimeout;
		_spawnTimer.Timeout += OnSpawnBall;

		_speedTimer.Start();
		_spawnTimer.Start();
	}

    private void LoadGame()
    {
        SaveData data = SaveManager.LoadGame();

		if (data != null)
		{
			GD.Print("data not null");
			GlobalVariables.HighestMin = data.HighScoreMinutes;
			GlobalVariables.HighestSec = data.HighScoreSeconds;
		}

		GD.Print($"Highest score: {GlobalVariables.HighestMin:00}:{GlobalVariables.HighestSec:00}");
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
}
