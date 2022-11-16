using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{

    [SerializeField] private TMP_Text scoreText;

    [SerializeField] private TMP_Text kingText;

    [SerializeField] private float scoreMultiplier = 1f;

    private bool isScoring = true;

    private float score = 0;

    private void Start()
    {
        kingText.text = $"King: {PlayerPrefs.GetString("username")} - {PlayerPrefs.GetInt("highestScore")}";
    }

    void Update()
    {
        if (!isScoring)
            return;

        score += Time.deltaTime * scoreMultiplier;

        scoreText.text = Mathf.FloorToInt(score).ToString();
    }

    public void StopScoring()
    {
        scoreText.text = string.Empty;

        isScoring = false;
    }

    public int Score()
    {
        return Mathf.FloorToInt(score);
    }
}
