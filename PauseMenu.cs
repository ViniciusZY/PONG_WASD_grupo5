using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    private bool isPaused = false;
    private bool firstPause = true;


    public GameObject winMenu;
    public TextMeshProUGUI winnerText;
    private bool isWin = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isWin) // Tecla ESC para pausar
        {
            if (isPaused) ResumeGame();
            else PauseGame();
        }
    }

    public void SetWinner(int ID)
    {
        isWin = true;
        winnerText.SetText("Player " + ID.ToString() + " win");
        winMenu.SetActive(true);  // Exibe o menu
        SoundManager.instance.UpdateMenu();
        Time.timeScale = 0f; // Congela o jogo
    }

    public void PauseGame()
    {
        isPaused = true;
        pauseMenu.SetActive(true);  // Exibe o menu
        if (firstPause)
        {
            SoundManager.instance.UpdateMenu();
            firstPause = false;
        }
        Time.timeScale = 0f; // Congela o jogo
    }

    public void ResumeGame()
    {
        isPaused = false;
        pauseMenu.SetActive(false);  // Esconde o menu
        Time.timeScale = 1f; // Retoma o jogo
    }

    public void LoadMainMenu()
    {
        Reset();
        Time.timeScale = 1f; // Reseta o tempo antes de mudar de cena
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit(); // Fecha o jogo
    }

    private void Reset()
    {
        isPaused = false;
        firstPause = true;
        isWin = false;
    }
}
