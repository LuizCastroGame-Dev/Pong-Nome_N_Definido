using UnityEngine;

public class BallMovement : MonoBehaviour
{

    public BallData ballData;

    public GameManager gameManager;

    private Rigidbody2D rb;

    public void ResetBall()
    {
        transform.position = Vector3.zero;

        if (rb == null) rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = ballData.speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //Se colidir com a parede, ele inverte o sentido Y da bola
        if (collision.gameObject.CompareTag("Wall"))
        {
            Vector2 newVelocity = rb.linearVelocity;

            newVelocity.y = -newVelocity.y;
            rb.linearVelocity = newVelocity;
        }

        //Se colidir com os Paddle, ele inverte o sentido X da bola
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Enemy"))
        {
            rb.linearVelocity = new Vector2(-rb.linearVelocity.x, rb.linearVelocity.y);
        }

        //Se colidir com a parede de pontuacao, ele soma 1 ponto
        if (collision.gameObject.CompareTag("Wall Player"))
        {
            gameManager.EnemyScore();
            ResetBall();
        }

        if (collision.gameObject.CompareTag("Wall Enemy"))
        {
            gameManager.PlayerScore();
            ResetBall();
        }
    }


}
