using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFiring : MonoBehaviour
{
    [SerializeField] private Vector2 turn;
    [SerializeField] private GameObject bulletPrefab;

    private int gun = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Mouse movement
        
        turn.y += Input.GetAxis("Mouse Y");

        transform.localRotation = Quaternion.Euler(0, turn.y, 0);

        transform.Rotate(Vector3.right * -turn.y);

        Shoot(gun);

    }

    private void Shoot(int gun)
    {
        if (gun == 1)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(bulletPrefab, transform.position, transform.rotation);
            }
        }

        /*if(gun == 2)
         {
             while(Input.GetMouseButton(0))
             {
                 Instantiate(bulletPrefab, firingPointPos, transform.rotation);

             }
         }*/
    }
}
