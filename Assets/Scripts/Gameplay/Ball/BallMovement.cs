using NUnit.Framework.Internal;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [Header("Managers")]
    public BallData ballData;
    public GameManager gameManager;
    public BallParry ballParry;


    [Header("Player - Enemy")]
    public GameObject playerPaddle;
    public GameObject enemyPaddle;

    private Rigidbody2D rb;

    public void ResetBall()
    {
        stopAddVelocity();

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
            rb.linearVelocityY = -rb.linearVelocity.y;
        }
        #endregion

        #region Colision with player - enemy
        //Se colidir com o player, ele inverte o sentido X da bola e altera o angulo da bola
        if (collision.gameObject.CompareTag("Player"))
        {
            rb.linearVelocityX = -rb.linearVelocity.x;
            rb.linearVelocityY = rb.linearVelocity.y + playerPaddle.transform.position.y;
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            rb.linearVelocityX = -rb.linearVelocity.x;
            rb.linearVelocityY = rb.linearVelocity.y + enemyPaddle.transform.position.y;
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

    private void stopAddVelocity()
    {
        //Adicionar power-ups que agrega velocidade aqui e parry
        ballParry.StopParry();
    }
}
