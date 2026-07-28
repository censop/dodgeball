using Godot;
using System;

public partial class GameUi : Control
{
	[Export] private Label _timePassedLabel;
	double _timeElapsed = 0;
	int _minutes;
	int _seconds;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		SignalHub.Instance.OnGameOver += OnGameOver;
	}

    public override void _ExitTree()
    {
        SignalHub.Instance.OnGameOver -= OnGameOver;
    }


    private void OnGameOver()
    {
        SaveManager.SaveGame(_minutes, _seconds);
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
	{
		_timeElapsed += delta;

		_minutes = (int)(_timeElapsed / 60);

		_seconds = (int)(_timeElapsed % 60);

		string timeString = $"{_minutes:00}:{_seconds:00}";

		_timePassedLabel.Text = timeString;
	}
}
