using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveManager : MonoBehaviour
{
    public static SaveFile saveFile;

    // Start is called before the first frame update
    void Start()
    {
        saveFile = Load();    
    }

    IEnumerator Loading()
    {
        SaveFile file = Load();
        yield return new WaitForSeconds(1);
        Debug.Log(file.pos1);   
    }


    public static void Save()
    {
        string path = Path.Combine(Application.dataPath, "Save.json");
        string JSONasString = JsonUtility.ToJson(saveFile, true);
        File.WriteAllText(path, JSONasString);
    }

    public SaveFile Load()
    {   
        // Read the JSON File
        string path = Path.Combine(Application.dataPath, "Save.json");
        if (!File.Exists(path))
        {
            CreateSaveData();
            return null;
        }
        string JSONasString = File.ReadAllText(path);
        SaveFile data = JsonUtility.FromJson<SaveFile>(JSONasString);    
        return data;
    }

    public SaveFile CreateSaveData()
    {
        SaveFile saveFile= new SaveFile();
        string path = Path.Combine(Application.dataPath, "Save.json");
        string JSONasString = JsonUtility.ToJson(saveFile, true);
        File.WriteAllText(path, JSONasString);
        return saveFile;
    }

    public void Load2()
    {   
        string JSONasString = Resources.Load<TextAsset>("rTest").text;
        SaveFile data = JsonUtility.FromJson<SaveFile>(JSONasString);  
    }

}
