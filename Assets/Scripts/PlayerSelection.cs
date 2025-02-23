using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSelection : MonoBehaviour
{
    public TextMeshProUGUI playerIDtext;
    public static int selectedOption1 = 0;
    public static int selectedOption2 = 0;

    private void Start()
    {
        playerIDtext.SetText("1");
        selectedOption1 = 0;
        selectedOption2 = 0;
    }
    public void ChooseOption(int option)
    {
        if (selectedOption1 == 0)
        {
            selectedOption1 = option; // Salva a escolha
            playerIDtext.SetText("2");
        }
        else {
            selectedOption2 = option;
            SceneManager.LoadScene("Game"); // Muda para a cena do jogo
        }
    }
}
