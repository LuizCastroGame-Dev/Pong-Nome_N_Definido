using System.Collections;
using UnityEngine;

public class BallPowerUps : MonoBehaviour
{
    private Rigidbody2D rb;

    [Header("Power-ups config")]

    [Header("Ball Speed-Up")]
    public float ballSpeedUp = 2f;

    [Header("Ball Speed-Down")]
    public float ballSpeedDown = 2f;
    public float timerSpeedDown = 2f;

    [Header("Stop ball")]
    public float timerStopBall = 2f;

    private void Start()
    {
        if (rb == null) rb = GetComponent<Rigidbody2D>();
    }

    public void ApplySpeedBoost()
    {
        if (rb.linearVelocityX < 0)
        {
            rb.linearVelocityX += -ballSpeedUp;
        }
        else
        {
            rb.linearVelocityX += ballSpeedUp;
        }
    }

    public void ApplySpeedDown()
    {
        StartCoroutine(SpeedDown());
    }

    IEnumerator SpeedDown()
    {
        var currentSpeedX = rb.linearVelocityX;

        if (rb.linearVelocityX > 0)
        {
            rb.linearVelocityX -= ballSpeedDown;
        }
        else
        {
            rb.linearVelocityX += ballSpeedDown;
        }

        yield return new WaitForSeconds(timerSpeedDown);

        rb.linearVelocityX = currentSpeedX;
    }

    public void ApplyStopBall()
    {
        StartCoroutine(StopBall());
    }

    IEnumerator StopBall()
    {
        var currentSpeed = rb.linearVelocity;
        rb.linearVelocity = new Vector2(0f, 0f);

        yield return new WaitForSeconds(timerStopBall);

        rb.linearVelocity = currentSpeed;
    }

    public void ApplyChangeBballTrajectory()
    {
        rb.linearVelocityY = -rb.linearVelocity.y;
    }
}
