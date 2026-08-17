using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public int winPoints = 5;

    [Header("Points UI")]
    public TextMeshProUGUI textPointPlayer;
    public TextMeshProUGUI textPointEnemy;

    [Header("End Screen and Interact Objects")]
    public GameObject screenEndGame;
    public GameObject interactObjects;

    void Start()
    {
        //Reset the objects positions
        Resetgame();
    }

    private void Update()
    {
        //Checking win condition
        CheckWin();
    }

    private void Resetgame()
    {
        //interact Objects Reset
        interactObjects.SetActive(true);

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
        //Sum playerPoints
        playerPoints++;
        textPointPlayer.text = playerPoints.ToString();
    }

    public void EnemyScore()
    {
        //Sum enemyPoints
        enemyPoints++;
        textPointEnemy.text = enemyPoints.ToString();
    }

    public void CheckWin()
    {
        //Win conditions
        if (playerPoints >= winPoints || enemyPoints >= winPoints) 
        {
            EndGame();
        }
    }

    public void EndGame()
    {
        //Call end game
        interactObjects.SetActive(false);
        screenEndGame.SetActive(true);
        Invoke(nameof(LoadMenu), 2f);
    }

    public void LoadMenu()
    {
        //Call the Menu scene
        SceneManager.LoadScene("Menu");
    }
}
