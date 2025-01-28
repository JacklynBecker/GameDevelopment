using UnityEngine;

public class BallMovement : MonoBehaviour
{

    private Rigidbody2D rBody;
    public float ballSpeed = 5f;

    private Vector2 currentVelocity;

    private int leftScore =0;
    private int rightScore=0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        resetBall();
    }

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            //colliding with paddle (or player)
            currentVelocity = new Vector2(currentVelocity.x * -1, currentVelocity.y );
        }
        else if(other.gameObject.CompareTag("Goals"))
        {
            //score a point for correct side
            if(currentVelocity.x < 0)
            {
                rightScore++;
            }
            else{
                leftScore++;
            }
            //reset ball to the middle
            resetBall();
            
        }
        else{
            currentVelocity = new Vector2(currentVelocity.x, currentVelocity.y * -1);
        }
        rBody.linearVelocity = currentVelocity;
        Debug.Log("Left Score: " + leftScore + " Right Score: " + rightScore);
    }

    void resetBall(){
        transform.position = Vector2.zero;
        float randX = Random.Range(-1,1);
        float randY = Random.Range(-1,1);
        rBody.linearVelocity = new Vector2(1,1) * ballSpeed;
        currentVelocity = rBody.linearVelocity;
    }
}
