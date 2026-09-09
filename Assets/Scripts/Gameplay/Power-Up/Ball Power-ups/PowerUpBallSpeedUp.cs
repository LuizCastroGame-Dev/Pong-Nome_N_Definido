using UnityEngine;

public class PowerUpBallSpeedUp : PowerUpBase
{
    public GameObject ball;
    private BallPowerUps ballPowerUps;
    protected override void ApplyEffect(GameObject target)
    {
        ballPowerUps = ball.GetComponent<BallPowerUps>();

        if (ballPowerUps != null)
        {
            ballPowerUps.ApplySpeedBoost();
        }
    }
}
