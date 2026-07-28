using Godot;
using System;

public partial class GameUi : Control
{
	[Export] private Label _timePassedLabel;
	double _timeElapsed = 0;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		_timeElapsed += delta;

		int minutes = (int)(_timeElapsed / 60);

		int seconds = (int)(_timeElapsed % 60);

		string timeString = $"{minutes:00}:{seconds:00}";

		_timePassedLabel.Text = timeString;
	}
}
