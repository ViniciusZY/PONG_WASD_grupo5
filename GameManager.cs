using UnityEngine;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI player1ScoreText; 
    public TextMeshProUGUI player2ScoreText;

    public GameObject ball;

    private int player1Score = 0;
    private int player2Score = 0;

    public GameObject[] rackets1; // raquetes do jogador 1
    public GameObject[] rackets2; // raquetes do jogador 2

    void Start()
    {
        SetRackets();
        UpdateScoreUI();
    }

    private void SetRackets()
    {
        int selectedRacket1 = PlayerSelection.selectedOption1 - 1;
        int selectedRacket2 = PlayerSelection.selectedOption2 - 1;
        for (int i = 0; i < rackets1.Length; i++)
        {
            rackets1[i].SetActive(i == selectedRacket1);
        }
        for (int i = 0; i < rackets2.Length; i++)
        {
            rackets2[i].SetActive(i == selectedRacket2);
        }
    }

    public void AddPointPlayer1()
    {
        player1Score++;
        UpdateScoreUI();
    }

    public void AddPointPlayer2()
    {
        player2Score++;
        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        player1ScoreText.text = player1Score.ToString();
        player2ScoreText.text = player2Score.ToString();
    }

    public void ResetBall()
    {
        ball.transform.position = Vector3.zero;
        ball.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;

        Invoke(nameof(LaunchBall), 0);
    }

    void LaunchBall()
    {
        ball.GetComponent<ScriptBall>().LaunchBall();
    }
}
