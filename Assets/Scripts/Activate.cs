using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activate : MonoBehaviour
{
    public GameObject player;
    public bool isPlayerClose;
    // the object detects the player's presence only if he is close enough
    private float detectionDistance = 0.6f;
    private bool isObjectPicked = false;
    private PlayerController playerControllerScript;
    // The object is moving up and down until the player picks. 
    private float speed = 5f;
    private float amount = 0.0012f;

    void Start()
    {
        isPlayerClose = false;
        playerControllerScript = player.GetComponent<PlayerController>();
    }


    void Update()
    {
        shake();
        checkPlayerDistance();
        // If the player is close ti the object and key "M" is pressed, the player picks the object
        if (Input.GetKeyDown(KeyCode.M) && isPlayerClose) {
            isObjectPicked = true;
        }
        if (isObjectPicked) {
            moveWithPlayer();
        }
        /*  
        if (isPlayerClose && !isObjectPicked) {
            shake();
        }
        */
    }

    // Check if the player is within a predefined distance
    private void checkPlayerDistance() {
        Vector3 playerPosition = player.transform.position;
        Vector3 objectPosition = transform.position;
        // y-coordinates are ignored when calculating the distance between player and object
        float distance = Mathf.Pow(playerPosition.x - objectPosition.x, 2) + Mathf.Pow(playerPosition.z - objectPosition.z, 2);
        distance = Mathf.Sqrt(distance);
        if (distance < detectionDistance && !isObjectPicked) {
            Debug.Log("Distancia a " + gameObject.name + ": " + distance);            
            isPlayerClose = true;
            Debug.Log("El Jugador está cerca");        
            List<Task> taskList = playerControllerScript.toDo.toDoList;
            // Print the list of tasks to be done by the player
            for (int k = 0; k < taskList.Count; k++) {
                Debug.Log(taskList[k].name);
            }
        } else {
            isPlayerClose = false;
        }
    }

    // The object is attached to the player
    private void moveWithPlayer() {      
        Vector3 targetPosition = player.transform.TransformPoint(Vector3.forward * 0.5f);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, 0.4f);
    }

    // The object is moving up and down until the player picks. 
    private void shake() {
        transform.position += new Vector3(0, Mathf.Sin(Time.time * speed) * amount, 0);
    }
}
