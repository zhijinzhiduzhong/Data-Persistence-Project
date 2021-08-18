using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MainManagerX : MonoBehaviour
{
    [System.Serializable]
    class SaveData
    {
        public string hPlayer;
        public int hScore;
    }
    public static MainManagerX Instance;
    public string playerName;
    public string playerNameHigh;
    public int highScore;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadHighData();
    }

    public void SaveHighData()
    {
        SaveData data = new SaveData();
        data.hPlayer = playerNameHigh;
        data.hScore = highScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadHighData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            playerNameHigh = data.hPlayer;
            highScore = data.hScore;
        }
    }
}
