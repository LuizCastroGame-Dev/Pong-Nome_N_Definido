using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Paddles")]
    public Transform PaddlePlayer;
    public Transform PaddleEnemy;

    [Header("Ball Movement")]
    public BallMovement ballMovement;

    [Header("Points")]
    public int playerPoints = 0;
    public int enemyPoints = 0;

    [Header("Points UI")]
    public TextMeshProUGUI textPointPlayer;
    public TextMeshProUGUI textPointEnemy;

    void Start()
    {
        Resetgame();
    }

    private void Resetgame()
    {
        //Paddle Reset
        PaddlePlayer.position = new Vector3(-7.5f, 0f, 0f);
        PaddleEnemy.position = new Vector3(7.5f, 0f, 0f);

        //Ball Reset
        ballMovement.ResetBall();

        //Points Reset
        playerPoints = 0;
        enemyPoints = 0;

        textPointPlayer.text = playerPoints.ToString();
        textPointEnemy.text = enemyPoints.ToString();
    }

    public void PlayerScore()
    {
        playerPoints++;
        textPointPlayer.text = playerPoints.ToString();
    }

    public void EnemyScore()
    {
        enemyPoints++;
        textPointEnemy.text = enemyPoints.ToString();
    }

}
