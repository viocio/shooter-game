using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float zInput;
    [SerializeField] private float rotation_xInput;
    [SerializeField] private float speed;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Vector2 turn;
    [SerializeField] private float jumpForce;

    private Rigidbody playerRb;
    private Vector3 playerForward;
    private GameObject cameraPosition;
    private Vector3 firingPointPos;
    private int gun = 1 ;
    private bool isGrounded = true;
    private Vector3 playerHorizontal;




    // Start is called before the first frame update
    void Start()
    {
        playerRb= GetComponent<Rigidbody>();
        cameraPosition = GameObject.Find("Main Camera");
        //UnityEngine.Cursor.lockState = CursorLockMode.Locked;
       // UnityEngine.Cursor.visible = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        // The position where bullets appear
        firingPointPos = GameObject.Find("FiringPoint").transform.position;

        //Camera follow mouse
        turn.y = Input.GetAxis("Mouse Y");
        turn.x += Input.GetAxis("Mouse X");
        transform.localRotation = Quaternion.Euler(0, turn.y, 0);

        // Player Actions
        PlayerMovement();
        
        ChooseWeapon();

        

    }

    private void PlayerMovement()
    {
        // Parameters used for player movement
        playerForward = transform.forward;
        playerHorizontal = transform.right;
        zInput = Input.GetAxis("Vertical");
        rotation_xInput = Input.GetAxis("Horizontal");

        // Player movement
        transform.Rotate(Vector3.up * turn.x);
        playerRb.AddRelativeForce(playerForward * zInput * speed, ForceMode.Impulse);
        playerRb.AddRelativeForce(playerHorizontal * rotation_xInput * speed, ForceMode.Impulse);

        // Player jump
        if (Input.GetKeyDown(KeyCode.Space)/* && isGrounded*/)
        {
            Debug.Log("Space Key was Pressed");
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }
   
  

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Floor"))
        {
            isGrounded = true;
        }
    }
    private void ChooseWeapon()
    {
        
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            gun = 1;
        }

       /* if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            gun = 2;
        }*/
           
    }

   
}
