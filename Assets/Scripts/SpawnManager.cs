using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] obstaclePrefab;
    private Vector3 spawnPosition = new Vector3(25, 0.1f, 0);
    private float timePast = 0.1f;
    private PlayerController playerControllerScript;

    void Start()
    {
        playerControllerScript = GameObject.Find("Nastya").GetComponent<PlayerController>();
    }

    void Update()
    {
        timePast += Time.deltaTime;
        float randomTime = Random.Range(2.0f, 4.0f);
        if (timePast >= randomTime)
        {
            if (playerControllerScript.onPosition == true)
            {
                SpawnObstacle();
            }
            }

    void SpawnObstacle()
    {
        if (playerControllerScript.gameOver == false)
            {
                int obstacleIndex = Random.Range(0, obstaclePrefab.Length);
                Instantiate(obstaclePrefab[obstacleIndex], spawnPosition, obstaclePrefab[obstacleIndex].transform.rotation);
                timePast = 0.1f;
            }
            
        }
    }
}
