using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI player1ScoreText; 
    public TextMeshProUGUI player2ScoreText;

    public GameObject ball;
    public GameObject pauseMenuManager;

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

    public void AddPoint(int playerID)
    {
        if (playerID == 1)
        {
            player1Score++;
            player1ScoreText.text = player1Score.ToString();
        }
        else {
            player2Score++;
            player2ScoreText.text = player2Score.ToString();
        }
        SoundManager.instance.PlaySoundEffect(SoundManager.instance.scoreSound);
        if(player1Score >= 10 ||  player2Score >= 10)
        {
            pauseMenuManager.GetComponent<PauseMenu>().SetWinner(playerID);
            SoundManager.instance.PlayWinSound();
        }
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
