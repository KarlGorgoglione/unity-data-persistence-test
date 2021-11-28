using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DataManager;
using TMPro;

public class Leaderboard : MonoBehaviour
{
    
    Canvas canvas;

    [SerializeField]
    TextMeshProUGUI scorePrefab;

    // Start is called before the first frame update
    void Start()
    {
        canvas = GetComponent<Canvas>();
        List<Score> scores = DataManager.Instance.scores;
        scores.Sort((elem1, elem2) => elem1.score.CompareTo(elem2.score));
        Debug.Log(scores[0].username);
        int i = 1;
        foreach (Score score in scores)
        {
            Instantiate(scorePrefab, scorePrefab.rectTransform.position, scorePrefab.rectTransform.rotation);
            scorePrefab.transform.parent = canvas.transform;
            scorePrefab.text = $"{i}- {score.username} : {score.score}";
            i++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
