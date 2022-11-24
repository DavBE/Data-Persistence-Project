using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{

    public static DataManager Instance;

    public System.String LastPlayerName = "";
    public System.String BestPlayerName = "";
    public int BestPlayerScore = 0;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadDataFromFile();
    }

    [System.Serializable]
    class SaveData
    {
        public System.String LastPlayerName;
        public System.String BestPlayerName;
        public int BestPlayerScore;
    }

    public void SaveDataToFile()
    {
        SaveData data = new SaveData();
        data.LastPlayerName = LastPlayerName;
        data.BestPlayerName = BestPlayerName;
        data.BestPlayerScore = BestPlayerScore;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadDataFromFile()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            LastPlayerName = data.LastPlayerName;
            BestPlayerName = data.BestPlayerName;
            BestPlayerScore = data.BestPlayerScore;
        }
    }
}
