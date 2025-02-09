using UnityEngine;

public class ScriptPlayer : MonoBehaviour
{
    public float speed; // Velocidade da raquete
    public int playerInput; // Identificador para os controles do jogador

    private Rigidbody2D rig;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float move = 0f;

        // Controles para o Jogador 1 (W e S)
        if (playerInput == 1)
        {
            if (Input.GetKey(KeyCode.W))
            {
                move = 1f;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                move = -1f;
            }
        }

        // Controles para o Jogador 2 (Setas)
        else if (playerInput == 2)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                move = 1f;
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                move = -1f;
            }
        }

        // Aplica o movimento
        rig.linearVelocity = new Vector2(0, move * speed);
    }
}
