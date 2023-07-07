using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject obstacle;
    public float maxTime=3f;
    float timer;
    float minY = -0.75f;
    float maxY = 2f;
    

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.gameOver == false && GameManager.gameStarted)
        {
            timer += Time.deltaTime;
            if (timer > maxTime)
            {
                InstantiateObject();
                timer = 0f;
            }
        }
    }

    public void InstantiateObject()
    {
        float randYrange = Random.Range(minY, maxY);
        GameObject newObstacle=Instantiate(obstacle);
        newObstacle.transform.position = new Vector2(transform.position.x, randYrange);
    }

}
