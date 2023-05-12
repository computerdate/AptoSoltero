using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 1;
    public float angularSpeed = 1;
    private float horizontalInput;
    private float verticalInput;
    public Camera mainCamera;
    public Camera auxCamera;
    // The player has a task list to complete
    public ToDo toDo;

    // Camera is switched when player passes from one room to another
    void switchCamera() {
        if (transform.position.x < 3.70f) {
            mainCamera.enabled = true;
            auxCamera.enabled = false;
        } else {
            mainCamera.enabled = false;
            auxCamera.enabled = true;            
        }
    }

    // Enables main camera at start and instantiate the task list
    void Start()
    {
        mainCamera.enabled = true;
        auxCamera.enabled = false;
        toDo = new ToDo();
    }

    // Player only can walk forward or backward, or rotate 90 degrees
    void Update()
    {
        // Player rotates exactly 90 degrees
        if(Input.GetKeyDown(KeyCode.RightArrow)) {
            transform.Rotate(0, 90, 0);  
        } else if(Input.GetKeyDown(KeyCode.LeftArrow)) {
            transform.Rotate(0, -90, 0);  
        }
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
        switchCamera();          
    }

}
