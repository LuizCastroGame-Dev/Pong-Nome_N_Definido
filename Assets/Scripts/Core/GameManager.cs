using UnityEngine;

public class GameManager : MonoBehaviour
{

    public Transform PaddlePlayer;
    public Transform PaddleEnemy;

    public BallMovement ballMovement;

    void Start()
    {
        Resetgame();
    }

    private void Resetgame()
    {
        PaddlePlayer.position = new Vector3(-7.5f, 0f, 0f);
        PaddleEnemy.position = new Vector3(7.5f, 0f, 0f);

        ballMovement.ResetBall();
    }

}
