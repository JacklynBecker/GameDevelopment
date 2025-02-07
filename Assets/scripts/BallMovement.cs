using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AdaptivePerformance.VisualScripting;

public class BallMovement : MonoBehaviour
{
    //Ball movement script will trigger scoring functions as it hits a goal 
    //Const Strings
    private const string PlayerTag="Player";
    private const string player1GoalTag="Player1Goal";
    private const string player2GoalTag="Player2Goal";

    //Private variables
    private Rigidbody2D rBody;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag(PlayerTag))
        {
            //bounce off player paddle
            HandlePlayerCollision(other);
        }
        else if(other.gameObject.CompareTag(player1GoalTag))
        {
            //Player 2 scored
            HandlePlayer1GoalCollision();
        }
        else if(other.gameObject.CompareTag(player2GoalTag))
        {
            //player 1 scored
            HandlePlayer2GoalCollision();

        }
        else{
            HandleCeilingFloorCollision();
        }
    }

    private void HandlePlayerCollision(Collision2D other)
    {
        Vector2 currentVelocity = GameManager.Instance.GetCurrentVelocity();
        //currentVelocity = new Vector2(currentVelocity.x * -1, currentVelocity.y);
        float y = CalculateBounceAngle(transform.position, other.transform.position, other.collider.bounds.size.y);
        currentVelocity = new Vector2(currentVelocity.x * -1, y).normalized * GameManager.Instance.ballSpeed;
        GameManager.Instance.SetCurrentVelocity(currentVelocity);
    }

    private void HandlePlayer1GoalCollision()
    {
        //We have no scoring logic! who handles scoring logic?
        // Ans: GameManager!
        GameManager.Instance.addScore(Player.Player2);

    }
    private void HandlePlayer2GoalCollision()
    {
        GameManager.Instance.addScore(Player.Player1);
    }

    private void HandleCeilingFloorCollision()
    {
        Vector2 currentVelocity = GameManager.Instance.GetCurrentVelocity();
        currentVelocity = new Vector2(currentVelocity.x , currentVelocity.y * -1);
        GameManager.Instance.SetCurrentVelocity(currentVelocity);
    }

    private float CalculateBounceAngle(Vector2 ballpos, Vector2 paddlepos, float paddleHeight)
    {
        return (ballpos.y - paddlepos.y) / paddleHeight * 3f;
    }

    
}
