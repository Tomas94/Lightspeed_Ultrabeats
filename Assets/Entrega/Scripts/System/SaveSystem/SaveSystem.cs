using System.IO;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    public static SaveData _saveData = new SaveData();
    string path;

    void Start() { path = Application.dataPath + "/SaveData.save"; }

    /*void Update()
     {
         if (Input.GetKeyDown(KeyCode.M)) SaveData();
         if (Input.GetKeyDown(KeyCode.N)) LoadData();
     }
    */

    public void SaveData()
    {
        string json = JsonUtility.ToJson(_saveData, true);
        Debug.Log(json);
        File.WriteAllText(path, json);
    }
    public void LoadData()
    {
        string json = File.ReadAllText(path);
        Debug.Log(json);
        JsonUtility.FromJsonOverwrite(json, _saveData);
    }
}
