using NUnit.Framework.Internal;
using UnityEngine;

public class BallMovement : MonoBehaviour
{

    public BallData ballData;

    public GameManager gameManager;

    private Rigidbody2D rb;

    public GameObject playerPaddle;

    public GameObject enemyPaddle;

    public void ResetBall()
    {
        transform.position = Vector3.zero;

        if (rb == null) rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = ballData.speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        #region Colisao com as paredes
        //Se colidir com a parede, ele inverte o sentido Y da bola
        if (collision.gameObject.CompareTag("Wall"))
        {
            Vector2 newVelocity = rb.linearVelocity;

            newVelocity.y = -newVelocity.y;
            rb.linearVelocity = newVelocity;
        }
        #endregion

        #region Colision with player - enemy
        //Se colidir com o player, ele inverte o sentido X da bola e altera o angulo da bola
        if (collision.gameObject.CompareTag("Player"))
        {
            rb.linearVelocity = new Vector2(-rb.linearVelocity.x, (rb.linearVelocity.y + playerPaddle.transform.position.y));
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            rb.linearVelocity = new Vector2(-rb.linearVelocity.x, (rb.linearVelocity.y + enemyPaddle.transform.position.y));
        }
        #endregion

        #region Parede de pontuacao
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
        #endregion
    }

}
