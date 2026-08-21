using NUnit.Framework.Internal;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [Header("Managers")]
    public BallData ballData;
    public GameManager gameManager;

    [Header("Player - Enemy")]
    public GameObject playerPaddle;
    public GameObject enemyPaddle;

    [Header("Parry and waiting seconds for parry")]
    public Vector2 parryVelocityIntence = new Vector2(2f, 2f);
    public float parryWaitSeconds = 4f;

    private Rigidbody2D rb;

    public void ResetBall()
    {
        StopAllCoroutines();

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

    void OnCollisionExit2D(Collision2D collision)
    {
        #region Parry
        if (collision.gameObject.CompareTag("Parry"))
        {
            StartCoroutine(Parry());
        }
        #endregion
    }

    #region Parry - Coroutine - logic
    IEnumerator Parry()
    {
        if (rb.linearVelocity.x < 0)
        {
            rb.linearVelocity += -parryVelocityIntence;
            yield return new WaitForSeconds(parryWaitSeconds);
            if (rb.linearVelocity.x < 0)
            {
                rb.linearVelocity += parryVelocityIntence;
            }
            else
            {
                rb.linearVelocity += -parryVelocityIntence;
            }
        }
        else
        {
            rb.linearVelocity += parryVelocityIntence;
            yield return new WaitForSeconds(parryWaitSeconds);
            if (rb.linearVelocity.x < 0)
            {
                rb.linearVelocity += parryVelocityIntence;
            }
            else
            {
                rb.linearVelocity += -parryVelocityIntence;
            }
        }
    }
    #endregion
}
