using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public bool dashActive = false;
    private float speed;
    private PlayerController playerControllerScript;

    void Start()
    {
        playerControllerScript = GameObject.Find("Nastya").GetComponent<PlayerController>();
    }

    void Update()
    {
        if (playerControllerScript.onPosition == true)
        {
            MovementAndDash();
        }

        //destroy out off bounds
        if (transform.position.x < -20)
        {
            Destroy(gameObject);
        }
    }

    void MovementAndDash()
    {
        if (playerControllerScript.gameOver == false && Input.GetKey(KeyCode.RightArrow))
        {
            speed = 30;
            transform.Translate(Vector3.left * Time.deltaTime * speed);
            dashActive = true;
        }
        else if (playerControllerScript.gameOver == false)
        {
            speed = 10;
            transform.Translate(Vector3.left * Time.deltaTime * speed);
            dashActive = false;
        }
    }
}
