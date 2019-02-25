using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    string verticalAxis = "Vertical";
    string horizontalAxis = "Horizontal";
    public float moveSpeed = 5;
    public float turnSpeed = 5;
    private CharacterController controller;
    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    // Update is called once per frame
    void Update () {

        Move(Input.GetAxis(verticalAxis));
        Turn(Input.GetAxis(horizontalAxis));
        //RotateCamera
	}

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log(other.gameObject.name);
    }

    private void OnTriggerEnter(Collider other)
    {
        if( other.CompareTag("Zone"))
        {
            Debug.Log("Entered the zone!");
        }
          
    else
        {
            Debug.Log("Entered something else!");
        }
        
    }

    void Move(float input)
    {
    float horizontalInput = Input.GetAxis(horizontalAxis) * moveSpeed * Time.deltaTime;
    float verticalInput = Input.GetAxis(verticalAxis) * moveSpeed * Time.deltaTime;
    Vector3 forward = transform.TransformDirection(Vector3.forward) * verticalInput;
    Vector3 right = transform.TransformDirection(Vector3.right) * horizontalInput;

    controller.SimpleMove(forward + right);

    //transform.Translate(input * transform.forward * Time.deltaTime * moveSpeed);
    }

    /*
    void RotateCamera()
    {
        if (camera == null) return;
        //camera.transform.Rotate( new Cursor)
    }
    */
    
    void Turn(float input)
    {
        transform.Rotate(input * Vector3.up * Time.deltaTime * turnSpeed);
    }
    

}
