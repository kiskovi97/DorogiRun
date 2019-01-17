﻿using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class FileManager
{
    static private string fileName = "RunGameData";

    public static void Save()
    {
        PlayerData.topScore = PlayerData.actualGameScore;
        string deviceFileLocation = Application.persistentDataPath + "/" + fileName;

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(deviceFileLocation, FileMode.Open);
        Data data = (Data)bf.Deserialize(file);
        file.Close();

        data.topScore = PlayerData.topScore;

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

            PlayerData.topScore = psData.topScore;
        }
        else
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(deviceFileLocation, FileMode.Create);
            Data data = new Data();
            data.topScore = 0;

            bf.Serialize(file, data);
            file.Close();
        }
    }
}
