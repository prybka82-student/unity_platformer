using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static int score;    //liczba punktów
    public Text gameOverText;   //etykieta do wykorzystania w razie przegranej
    public Text youWonText;     //etykieta w przypadku wygranej
    public int winningScore;    //warunek wygrania

    Text text;                  //etykieta z liczbą punktów

    void Start()
    {
        gameOverText.enabled = false;   //początkowo obie plansze
        youWonText.enabled = false;     //są wyłączone

        text = GetComponent<Text>();    //utworzenie referencji do etykiety z punktami
        Reset();                        //wyzerowanie punktów
    }

    void Update()
    {
        text.text = score.ToString();   //zaktualizowanie planszy z punktami

        if (score >= winningScore)      //sprawdzenie, czy gracz wygrał
            WinningEndGame();        
    }

    public static void AddPoints(int pointsToAdd) 
        => score += pointsToAdd;        //dodawanie punktów
    public static void Reset() 
        => score = 0;                   //wyzerowanie punktów

    void WinningEndGame()
    {
        youWonText.enabled = true;      //włączenie planszy wygranej
        Debug.Log("You win!!!");        //logowanie (do testów)
        PauseGame();                    //wymuszona pauza
    }
    void PauseGame()
        => Time.timeScale = 0;          //pauza to zatrzymanie czasu
}
