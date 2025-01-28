using System;
using UnityEngine;

public class PaddleMovement : MonoBehaviour
{

    public float moveSpeed = 5f;
    public string paddleInputString = "PaddleLeft";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Option 1: fallback option for input handling
        /*if (Input.GetKey(KeyCode.W))
        {
            Debug.Log("I am pressing the W key");
        }*/


        
        //Option 2: using unity input manager
        float verticalInput = Input.GetAxis(paddleInputString);
        transform.Translate(Vector2.up * verticalInput * moveSpeed * Time.deltaTime);
            
        //Move on y axis based on the verticalInput value
    

    }
}
