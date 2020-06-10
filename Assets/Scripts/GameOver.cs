using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    private Camera camera;
    private float cameraWidth;
    private float cameraPos;

    public GameObject ball;
    private float ballWidth;
    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
        cameraWidth = camera.orthographicSize * camera.aspect;
        cameraPos = camera.transform.position.x;
        ballWidth = (ball.transform.GetChild(0).transform.position.y - ball.transform.GetChild(1).transform.position.y)/2;
    }

    // Update is called once per frame
    void Update()
    {
        if (ball.transform.position.x <= cameraPos - cameraWidth - ballWidth || ball.transform.position.x >= cameraPos + cameraWidth + ballWidth) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
