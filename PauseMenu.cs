using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // Tecla ESC para pausar
        {
            if (isPaused) ResumeGame();
            else PauseGame();
        }
    }

    public void PauseGame()
    {
        isPaused = true;
        pauseMenu.SetActive(true);  // Exibe o menu
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
        Time.timeScale = 1f; // Reseta o tempo antes de mudar de cena
        SceneManager.LoadScene("MainMenu"); 
    }

    public void QuitGame()
    {
        Application.Quit(); // Fecha o jogo
    }
}
