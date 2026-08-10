using UnityEngine;

public class EnemyPaddleController : MonoBehaviour
{
    private Rigidbody2D rb;
    private GameObject ball;

    public EnemyPaddleData enemyPaddleData;

    public Vector2 screenLimit = new Vector2(-4.5f, 4.5f);

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ball = GameObject.Find("Ball");
    }

    private void Update()
    {
        if (ball != null)
        {
            //Limite da posicao Y
            float targetY = Mathf.Clamp(ball.transform.position.y, screenLimit.x, screenLimit.y);

            Vector2 targetPosition = new Vector2(transform.position.x, targetY);

            transform.position = Vector2.MoveTowards(transform.position, targetPosition, Time.deltaTime * enemyPaddleData.Speed);
        }
    }
}
