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
        scores.Sort((elem1, elem2) => elem2.score.CompareTo(elem1.score));
        Debug.Log(scores[0].username);
        int i = 1;
        foreach (Score score in scores.GetRange(0, scores.Count > 8 ? 8 : scores.Count))
        {
            TextMeshProUGUI scoreText = Instantiate(scorePrefab, new Vector3(-225 , 125 - (i * 40), 0), scorePrefab.rectTransform.rotation);
            scoreText.transform.SetParent(canvas.transform, false);
            scoreText.text = $"{i}- {score.username} : {score.score}";
            i++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
