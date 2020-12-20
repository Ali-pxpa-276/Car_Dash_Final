using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] traffic;
    public GameObject coins;

    private float zTrafficSpawn = 28f;
    private float xSpawnRange = 21f;
    private float zcoinSpawnRange = 13f;
    private float ySpawn = 0f;
    private PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
          
       
            InvokeRepeating("trafficSpawn", 1.0f, 2.0f);
            InvokeRepeating("coinSpawn", 1.0f, 6.0f);
        
    }




    // Update is called once per frame
    void Update()
    {
        
    }

    void trafficSpawn()
    {

        float randomX = Random.Range(-xSpawnRange, xSpawnRange);
        int randomIndex = Random.Range(0, traffic.Length);

        Vector3 spawnPos = new Vector3(randomX, ySpawn, zTrafficSpawn);
        if (playerController.isGameActive)
        {
            Instantiate(traffic[randomIndex], spawnPos, traffic[randomIndex].gameObject.transform.rotation);
        }
    }

    void coinSpawn()
    {
        float randomX = Random.Range(-xSpawnRange, xSpawnRange);
        float randomZ = Random.Range(4, zcoinSpawnRange);

        Vector3 spawnPos = new Vector3(randomX, ySpawn, randomZ);

        if (playerController.isGameActive)
        {
            Instantiate(coins, spawnPos, coins.gameObject.transform.rotation);
        }
    }
}
