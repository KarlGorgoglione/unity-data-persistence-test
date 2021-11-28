using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
using Newtonsoft.Json;

public class DataManager : MonoBehaviour
{
    [System.Serializable]
    class SaveData
    {
        public string Username;
    }

    [System.Serializable]
    public class Score
    {
        public int score;
        public string username;
    }

    public static DataManager Instance;

    public string Username;

    public List<Score> scores;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }


        DontDestroyOnLoad(gameObject);
    }

    public void setUsername(string username)
    {
        Username = username;
    }

    public void saveUsername()
    {
        SaveData data = new SaveData();
        data.Username = Username;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/username.json", json);
    }

    public void loadUsername()
    {
        string path = Application.persistentDataPath + "/username.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            Username = data.Username;
        }
    }

    public void FetchScores()
    {
        string path = Application.persistentDataPath + "/scores.json";
        Debug.Log(path);
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            Debug.Log(json);
            scores = JsonConvert.DeserializeObject<List<Score>>(json);
        }
        else
        {
            scores = new List<Score>();
        }
    }

    public void saveScore(int score)
    {
        Score data = new Score();
        data.score = score;
        data.username = Username;

        scores.Add(data);

        string json = JsonConvert.SerializeObject(scores);
        Debug.Log(json);
        File.WriteAllText(Application.persistentDataPath + "/scores.json", json);
    }


}
