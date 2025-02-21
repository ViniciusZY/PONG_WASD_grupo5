using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void PlayGame()
    {
        SceneManager.LoadScene("PlayerSelection");  // Carrega a cena do jogo
    }

    public void QuitGame()
    {
        Application.Quit();  // Fecha o jogo 
    }
}
