using UnityEngine;

public class PowerUpPaddleSpeedUp : PowerUpBase
{
    public GameObject paddle;
    private PaddlePowerUps paddlePowerUps;
    protected override void ApplyEffect(GameObject target)
    {
        paddlePowerUps = paddle.GetComponent<PaddlePowerUps>();

        if (paddlePowerUps != null)
        {
            paddlePowerUps.ApplySpeedUp();
        }
    }
}
