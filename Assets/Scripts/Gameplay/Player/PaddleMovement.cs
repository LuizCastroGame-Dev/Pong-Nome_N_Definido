using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    [Header("Screen Limits")]
    public Vector2 screenLimit = new Vector2(-4.5f, 4.5f);

    public PaddleInput paddleInput;

    public PaddleData paddleData;

    void Update()
    {
        //Recebe o input do paddle
        float input = paddleInput.InputReader();

        //Calculo da nova posição
        Vector3 newPosition = transform.position + Vector3.up * input * paddleData.Speed * Time.deltaTime;

        //Limita que o paddle não saia da tela
        newPosition.y = Mathf.Clamp(newPosition.y, screenLimit.x, screenLimit.y);

        //Atualiza a posição da raquete
        transform.position = newPosition;
    }
}
