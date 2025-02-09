using UnityEngine;

public class Goals : MonoBehaviour
{
    public GameManager gameManager;  // Refer�ncia ao GameManager

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ball"))
        {
            if (gameObject.name == "LeftGoal")
            {
                gameManager.AddPointPlayer2();  // Ponto para o Jogador 2
            }
            else if (gameObject.name == "RightGoal")
            {
                gameManager.AddPointPlayer1();  // Ponto para o Jogador 1
            }

            gameManager.ResetBall();  // Reseta a bolinha ap�s o ponto
        }
    }
}
