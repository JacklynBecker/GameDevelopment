using System.Security.Cryptography;
using UnityEngine;

public enum Player{
    Player1,
    Player2
}

public class GameManager : MonoBehaviour
{
    //Single reference static variables
    public static GameManager Instance {get; private set;}

    //Score variables
    private int player1Score=0;
    private int player2Score=0;

    //Ball variables
    public Rigidbody2D ballRigidBody;
    public float ballSpeed = 5f;
    private Vector2 currentVelocity;

    //Win Score Condition 
    public int winScore = 5;


    //unity function
    private void Awake()
    {
        //Ensure that there is only one instance of gameManager
        if (Instance == null)
        {
            Instance = this;
            //Intermediate Unity tip and trick 
            DontDestroyOnLoad(this.gameObject);
        }
        else{
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        resetBall();
    }


    public void addScore(Player player)
    {
        if(player == Player.Player1)
        {
            player1Score++;
            UiManager.Instance.UpdateScore(Player.Player1, player1Score);
            if(player1Score >= winScore)
            {
                //Player 1 Wins
                //Display win message
                UiManager.Instance.DisplayWinMessage(Player.Player1);
                StopGame();
            }
        }
        else if (player == Player.Player2)
        {
            player2Score++;
            UiManager.Instance.UpdateScore(Player.Player2, player2Score);
            if(player2Score >= winScore)
            {
                //Player 2 Wins
                //Display win message
                UiManager.Instance.DisplayWinMessage(Player.Player2);
                StopGame();
            }
        }

        DisplayScores();
        resetBall();
    }

    private void DisplayScores(){
        Debug.Log($"Player 1: {player1Score} - Player 2: {player2Score}");
    }

    void resetBall(){
        ballRigidBody.transform.position = Vector2.zero;
        //randomly choose direction for ball to move horizontally
        //generate random number 0 or 1. if 0 return -1 if not 0 return 1
        float randX = Random.Range(0,2) == 0? -1 : 1;
        //add slight vertical variation
        float randY = Random.Range(-0.5f,0.5f);

        //set the balls velocity
        Vector2 direction = new Vector2(randX,randY).normalized;

        ballRigidBody.linearVelocity = direction * ballSpeed;

        SetCurrentVelocity(ballRigidBody.linearVelocity);
        
    }


    public Vector2 GetCurrentVelocity()
    {
        return currentVelocity;
    }

    public void SetCurrentVelocity(Vector2 velocity)
    {
        currentVelocity = velocity;
        ballRigidBody.linearVelocity=currentVelocity;
    }

    private void StopGame()
    {
        Time.timeScale = 0;
    }


}

/*
    // what is the purpose of the gameManager?
    //keep track of the game state
    //keep track of items that affect the game as a whole

    //TO-DO:
    //control the launching of the ball after each goal
    //scoring logic
    //win condition 
    */

    //Design pattern: Singleton - Ensure only ONE instance of an object is active.
