using System;
using System.IO;
using UnityEngine;

public class CodeSnippets : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    void SaveData()
    {
        // Create Empty Json Data Object
        JsonData js = new JsonData();

        // Write the Json Data Object into the Json File
        string path = Path.Combine(Application.persistentDataPath, "PlayerData.json");
        string JSONasString = JsonUtility.ToJson(js, true);
        File.WriteAllText(path, JSONasString);
    }

    void ReadData()
    {
        // Read the JSON File
        string path = Path.Combine(Application.persistentDataPath, "PlayerData.json");
        if (!File.Exists(path))
        {
            return;
        }
        string JSONasString = File.ReadAllText(path);
        JsonData js = JsonUtility.FromJson<JsonData>(JSONasString);    
        Debug.Log(js.name);
    }
    
    public static void LoadLocal()
    {
        string jsonString = Resources.Load<TextAsset>("Data").text;
        JsonData source = JsonUtility.FromJson<JsonData>(jsonString);

        // Also for a local Save
        // Application.dataPath
    }

}

[Serializable]
public class JsonData
{
    public string name = "Hello World";
}

