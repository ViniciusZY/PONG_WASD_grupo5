using UnityEngine;
using TMPro;  // Importante para usar TextMeshPro

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI player1ScoreText;  // Atualizado para TextMeshPro
    public TextMeshProUGUI player2ScoreText;

    public GameObject ball;

    private int player1Score = 0;
    private int player2Score = 0;

    void Start()
    {
        UpdateScoreUI();
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
