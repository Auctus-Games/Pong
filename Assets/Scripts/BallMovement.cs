using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float ballSpeed;
    public float bounceAngle;
    public float acceleration;

    private float ballX;
    private float ballY;
    
    private float cameraHeight;
    private float cameraPos;

    private float ballHeight;

    public float checkCooldown = 0.1f;
    private float nextCheck;
    // Start is called before the first frame update
    void Start()
    {
        ballX = ballSpeed;
        cameraHeight = Camera.main.orthographicSize;
        cameraPos = Camera.main.transform.position.y;
        ballHeight = (gameObject.transform.GetChild(0).transform.position.y - gameObject.transform.GetChild(1).transform.position.y) / 2;
        nextCheck = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        ballSpeed = ballSpeed + acceleration * Time.deltaTime;
        if (Time.time>=nextCheck && (gameObject.transform.position.y >= cameraPos + cameraHeight - ballHeight || gameObject.transform.position.y <= cameraPos - cameraHeight + ballHeight)) {
            ballY *= -1;
            nextCheck = Time.time + checkCooldown;
        }
        gameObject.transform.position = new Vector2(gameObject.transform.position.x + ballX*Time.deltaTime, gameObject.transform.position.y + ballY*Time.deltaTime);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        float moveDir = 0;
        if (other.gameObject.name.Equals("Player One")) {
            moveDir = 1;
        }
        else {
            moveDir = -1;
        }
        float paddleHeight = other.gameObject.transform.GetChild(0).transform.position.y -
                             other.gameObject.transform.GetChild(1).transform.position.y;
        paddleHeight /= 2;
        float paddlePos = other.gameObject.transform.position.y;
        float intersectY = gameObject.transform.position.y;
        float normal = (paddlePos - intersectY) / paddleHeight;
        if (normal > 1) {
            normal = 1;
        }
        else if (normal < -1) {
            normal = -1;
        }

        normal *= -1;
        float angle = normal * (bounceAngle*Mathf.PI/180);
        //Debug.Log(angle);
        ballX = ballSpeed * Mathf.Cos(angle) * moveDir;
        //Debug.Log(ballX);
        ballY = ballSpeed * Mathf.Sin(angle);
    }
}
