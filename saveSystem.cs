using System.IO; //Using to create cloud save files
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary; //Allows us to access binary format

public static class saveSystem
{
    public static void SavePlayer(playerData profileData)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.profile";
        FileStream stream = new FileStream(path, FileMode.Create);
        
        localdata local = new localdata(profileData);

        formatter.Serialize(stream, local);
        stream.Close();

    }

    public static localdata LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.data01";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            localdata data = formatter.Deserialize(stream) as localdata;

            stream.Close();

            return data;
            
        }
        else
        {
            Debug.Log("Player data not found in " + path);
            return null;
        }
    }


}
