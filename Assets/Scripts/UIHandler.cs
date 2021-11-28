using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        DataManager.Instance.FetchScores();
        SceneManager.LoadScene(1);
    }

    public void ShowLeaderboard()
    {
        DataManager.Instance.FetchScores();
        SceneManager.LoadScene(2);
    }
}
