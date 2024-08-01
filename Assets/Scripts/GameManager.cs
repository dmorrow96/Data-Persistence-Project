using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    

    
    

    private string filepath;
    public static int bestScore = 0;
    public static string hiscName ;
    public static string username;


    private void Awake()
    {
        // start of new code
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // end of new code

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadName();

    }
    [System.Serializable]
    class SaveData
    {
        public int points;
        public string name;
    }

    public void SaveName()
    {
        SaveData data = new SaveData();
        data.name = hiscName;
        data.points = bestScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);

    }

    public void LoadName()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            hiscName = data.name;
            bestScore = data.points;
        }
    }




}
