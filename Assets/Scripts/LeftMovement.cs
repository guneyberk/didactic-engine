using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class LeftMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 4f;
    BoxCollider2D boxCollider;
    float groundWidth;
    float obstacleWidth;
    void Start()
    {
        if (gameObject.CompareTag("Ground"))
        {
            boxCollider = GetComponent<BoxCollider2D>();
            groundWidth = boxCollider.size.x;
        }
        else if (gameObject.CompareTag("Obstacles"))
        {
            obstacleWidth = GameObject.FindGameObjectWithTag("Column").GetComponent<BoxCollider2D>().size.x;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (GameManager.gameOver == false)
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        }

        if (gameObject.CompareTag("Ground"))
        {
            if (transform.position.x <= -groundWidth)
            {
                transform.position = new Vector2(transform.position.x + 2 * groundWidth, transform.position.y);
            }
        }
        else if (gameObject.CompareTag("Obstacles"))
        {
            if(transform.position.x < GameManager.bottomLeft.x - obstacleWidth)
            {
                Destroy(gameObject);
                
            }
        }
       
    }
}
