using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class FileManager
{
    private static readonly string fileName = "RunGameData";

    public static void Save()
    {
        PlayerData.allCoin += PlayerData.actualCoin;
        PlayerData.actualCoin = 0;
        if (PlayerData.actualGameScore > PlayerData.topScore)
        {
            PlayerData.topScore = PlayerData.actualGameScore;
        }
        string deviceFileLocation = Application.persistentDataPath + "/" + fileName;

        BinaryFormatter bf = new BinaryFormatter();
        Data data = PlayerData.GetData();
        FileStream fileForSave = File.Create(deviceFileLocation);
        bf.Serialize(fileForSave, data);
        fileForSave.Close();
    }

    public static void Load()
    {
        string deviceFileLocation = Application.persistentDataPath + "/" + fileName;

        if (File.Exists(deviceFileLocation))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(deviceFileLocation, FileMode.Open);
            Data psData = (Data)bf.Deserialize(file);
            file.Close();
            PlayerData.SetFromData(psData);
        }
        else
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(deviceFileLocation, FileMode.Create);
            PlayerData.ResetAll();
            Data data = PlayerData.GetData();
            bf.Serialize(file, data);
            file.Close();
        }
    }
}
