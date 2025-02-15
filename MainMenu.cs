using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void PlayGame()
    {
        print("Bot�o Play pressionado!"); // Mensagem de depura��o
        SceneManager.LoadScene("PlayerSelection");  // Carrega a cena do jogo
    }

    public void QuitGame()
    {
        Application.Quit();  // Fecha o jogo 
    }
}
