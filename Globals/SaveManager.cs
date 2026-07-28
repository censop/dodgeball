using Godot;
using System;
using System.Text.Json;

public partial class SaveManager : Node
{
    public static SaveManager Instance {get; private set;}
    private static String _savePath = "user://savegame.json";


    public override void _Ready()
    {
        Instance = this;
    }

    public static void SaveGame(int highestMin, int highestSec)
    {
        if(GlobalVariables.HighestMin > highestMin || 
        (GlobalVariables.HighestMin < highestMin && GlobalVariables.HighestSec > highestSec)) return;

        SaveData data = new SaveData
        {
            HighScoreMinutes = highestMin,
            HighScoreSeconds = highestSec,
        };

        string jsonString = JsonSerializer.Serialize(data);
        try
        {
            using var file = FileAccess.Open(_savePath, FileAccess.ModeFlags.Write); //using keyword automatically closes the file after its done with it
            file.StoreString(jsonString);
            GD.Print($"Save info:{highestMin}, {highestSec}, Game Saved to: " + ProjectSettings.GlobalizePath(_savePath));
        }catch
        {
            GD.Print("Game couldn't be saved");
        }
    }

    public static SaveData LoadGame()
    {
        if (!FileAccess.FileExists(_savePath))
        {
            GD.Print("Save file doesn't exist");
            return null;
        }

        try
        {
            using var file = FileAccess.Open(_savePath, FileAccess.ModeFlags.Read);
            string jsonString = file.GetAsText();
            SaveData data = JsonSerializer.Deserialize<SaveData>(jsonString);
            GD.Print("Game loaded");
            return data;
        } catch
        {
            GD.Print("Game couldn't be loaded");
            return null;
        }
    }

}
