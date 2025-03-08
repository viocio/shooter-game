using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private int spawnRate;
    [SerializeField] private float radius;

    private Vector3 playerPos;
    private Vector3 spawnPos;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("EnemySpawn", 3, spawnRate);
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = GameObject.Find("Player").transform.position;
       

    }

    void EnemySpawn()
    {
       
        spawnPos = playerPos + Random.onUnitSphere * radius;
        spawnPos = spawnPos - new Vector3(0, playerPos.y, 0);
        Instantiate(enemyPrefab, spawnPos, enemyPrefab.transform.rotation);



    }

    

   

   

}
