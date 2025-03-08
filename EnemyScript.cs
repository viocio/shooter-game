using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private float speed;

    private Vector3 playerPos;
    private Rigidbody enemyRb;
    private Vector3 routeToPlayer;
    
    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveToPlayer();
        transform.LookAt(GameObject.Find("Player").transform);

        DestroyWhenLow();
    }

    void MoveToPlayer()
    {
        
        playerPos = GameObject.Find("Player").transform.position;
        routeToPlayer = (playerPos - transform.position).normalized;
        routeToPlayer.y = 0;    

        enemyRb.AddForce(routeToPlayer * speed, ForceMode.Impulse);

    }

    void DestroyWhenLow()
    {
        if (transform.position.y < -2)
            Destroy(gameObject);
    }
}
