using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class PaddleMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    private int moveDir;
    private float cameraHeight;
    private float cameraPos;
    private GameObject head;
    private GameObject feet;
    void Start()
    {
        moveDir = 0;
        cameraHeight = Camera.main.orthographicSize;
        cameraPos = Camera.main.transform.position.y;
        head = gameObject.transform.GetChild(0).gameObject;
        feet = gameObject.transform.GetChild(1).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A) && gameObject.transform.position.y <= cameraPos + cameraHeight - ((head.transform.position.y-feet.transform.position.y)/2) - cameraHeight/20) {
            moveDir = 1;
        }
        else if (Input.GetKey(KeyCode.D) && gameObject.transform.position.y >= cameraPos - cameraHeight + ((head.transform.position.y-feet.transform.position.y)/2) + cameraHeight/20) {
            moveDir = -1;
        }
        else {
            moveDir = 0;
        }
        gameObject.transform.position = new Vector2(gameObject.transform.position.x,
            gameObject.transform.position.y + moveDir * speed * Time.deltaTime);
    }
    
}
