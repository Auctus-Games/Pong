using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Start : MonoBehaviour
{
    // Start is called before the first frame update
    public Image image;

    // Update is called once per frame
    void Update()
    {
        if (image.enabled && (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))) {
            image.enabled = false;
        }
    }
}
