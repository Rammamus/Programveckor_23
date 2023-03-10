using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

// Skapar spar fil p? datorn som g?r att ladda in en gammal "save" - casper
public static class savesystem 
{
    public static void SavePlayer (kar?ktar kr)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.fun";
        FileStream stream = new FileStream(path, FileMode.Create);
        PlayerData data = new PlayerData(kr);

        formatter.Serialize(stream, data);
        stream.Close();


        

    }

    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.fun";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

           PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close(); 

            return data;
        }
        else
        {
            Debug.LogError("Save file not found in" + path);
            return null; 
        }

    }
}
