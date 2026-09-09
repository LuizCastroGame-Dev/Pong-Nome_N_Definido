using UnityEngine;

public class PaddlePowerUps : MonoBehaviour
{
    [Header("Power-Ups config")]
    public PaddleData paddleData;

    [Header("Paddle Speed-up")]
    public float PaddleSpeedUp = 2f;


    public void ApplySpeedUp()
    {
        paddleData.Speed += PaddleSpeedUp;
    }
}
