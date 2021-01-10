using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static int score;
    public Text gameOverText;
    public Text youWonText;
    public int winningScore;

    Text text;

    // Start is called before the first frame update
    void Start()
    {
        gameOverText.enabled = false;
        youWonText.enabled = false;

        text = GetComponent<Text>();
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        PreventNegativeScore();
        
        text.text = score.ToString();

        if (score >= winningScore)
            WinningEndGame();        
    }

    public static void AddPoints(int pointsToAdd) => score += pointsToAdd;
    public static void Reset() => score = 0;

    void PreventNegativeScore() => score = score < 0 ? 0 : score;
    void WinningEndGame()
    {
        youWonText.enabled = true;
        Debug.Log("You win!!!");
        PauseGame();
    }
    void PauseGame()
    {
        Time.timeScale = 0;
    }
}
