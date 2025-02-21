using UnityEngine;

public class Goals : MonoBehaviour
{
    public GameManager gameManager;  // Referência ao GameManager

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ball"))
        {
            if (gameObject.name == "LeftGoal")
            {
                gameManager.AddPoint(2);  // Ponto para o Jogador 2
            }
            else if (gameObject.name == "RightGoal")
            {
                gameManager.AddPoint(1);  // Ponto para o Jogador 1
            }

            gameManager.ResetBall();  // Reseta a bolinha após o ponto
        }
    }
}
