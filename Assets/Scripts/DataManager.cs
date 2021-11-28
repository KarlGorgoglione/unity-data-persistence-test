using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    public string Username;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [System.Serializable]
    class SaveData
    {
        public string Username;
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

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
