using UnityEngine;

public class ScriptBall : MonoBehaviour
{
    public float speed;
    public float maxYSpeed;
    public float minXSpeed;
    private Vector2 currentVelocity;
    private bool velocityChanged;

    private Rigidbody2D rig;

    void Start()
    {
        Random.InitState(System.DateTime.Now.Millisecond);  // Garante que a aleatoriedade seja diferente a cada execução
        rig = GetComponent<Rigidbody2D>();
        LaunchBall();  // Lan�a a bolinha em uma dire��o aleat�ria ao iniciar
    }

    private void Update()
    {
        LimitSpeed();
    }

    public void LaunchBall()
    {
        float randomX = Random.Range(0.5f, 1f) * (Random.value > 0.5f ? 1 : -1);  // Garante que não seja muito próximo de 0
        float randomY = Random.Range(0.5f, 1f) * (Random.value > 0.5f ? 1 : -1);  // Mesmo para o Y

        Vector2 randomDirection = new Vector2(randomX, randomY).normalized;

        rig.linearVelocity = randomDirection * speed;
    }



    // Limita a velocidade da bolinha para não ultrapassar o máximo nem ser menor que o mínimo
    void LimitSpeed()
    {
        currentVelocity = rig.linearVelocity;
        velocityChanged = false;

        // Se a velocidade vertical for maior que o máximo, limita
        if (Mathf.Abs(currentVelocity.y) > maxYSpeed)
        {
            currentVelocity.y = Mathf.Sign(currentVelocity.y) * maxYSpeed;
            velocityChanged = true;
        }

        // Se a velocidade horizontal for menor que o mínimo, aumenta
        if (Mathf.Abs(currentVelocity.x) < minXSpeed)
        {
            currentVelocity.x = Mathf.Sign(currentVelocity.x) * minXSpeed;
            velocityChanged = true;
        }

        if (velocityChanged) {
            rig.linearVelocity = currentVelocity;
        }
    }


    // Reflex�o ao colidir com outros objetos
    void OnCollisionEnter2D(Collision2D collision)
    {
        SoundManager.instance.PlaySoundEffect(SoundManager.instance.ballHitSound);
    }


}
