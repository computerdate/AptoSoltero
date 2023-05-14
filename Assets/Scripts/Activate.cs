using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activate : MonoBehaviour
{
    public GameObject player;
    public bool isPlayerClose;
    // the object detects the player's presence only if he is close enough
    private float detectionDistance = 0.4f;
    public bool isObjectPicked = false;
    private PlayerController playerControllerScript;
    // The object is moving up and down until the player picks. 
    private float speed = 5;
    private float amount = 0.0012f;

    public AudioClip pickupSound;
    public AudioClip putDownSound;

    private AudioSource objectAudio;

    public float playerHeadYPosition = 3;
    public float playerHeadZPosition = 0.5f;

    void Awake() {
        playerControllerScript = player.GetComponent<PlayerController>();
        objectAudio = GetComponent<AudioSource>();
    } 
    void Start()
    {
        isPlayerClose = false;
        playerControllerScript.hasAnObject = false;
    }


    void Update()
    {
        shake();
        //checkPlayerDistance();
        // If the player is close to the object and key "M" is pressed, the player picks the object
        if (Input.GetKeyDown(KeyCode.M) && isPlayerClose && !playerControllerScript.hasAnObject) {
            isObjectPicked = true;
            //playerControllerScript.hasAnObject = true;
            playerControllerScript.pickObject(gameObject);
            objectAudio.PlayOneShot(pickupSound, 1.0f);
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
/*     private void checkPlayerDistance() {
        Vector3 playerPosition = player.transform.position;
        Vector3 objectPosition = transform.position;
        // y-coordinates are ignored when calculating the distance between player and object
        float distance = Mathf.Pow(playerPosition.x - objectPosition.x, 2) + Mathf.Pow(playerPosition.z - objectPosition.z, 2);
        distance = Mathf.Sqrt(distance);
        if (distance < detectionDistance && !isObjectPicked) {          
            isPlayerClose = true;   
            List<Task> taskList = playerControllerScript.toDo.toDoList;
            // Print the list of tasks to be done by the player
            for (int k = 0; k < taskList.Count; k++) {
                //Debug.Log(taskList[k].name + " - " + taskList[k].started);
            }
        } else {
            isPlayerClose = false;
        }
    } */

    // The object is attached to the player
    public void moveWithPlayer() {  
        Vector3 headPosition = new Vector3(0, playerHeadYPosition, playerHeadZPosition);
        Vector3 targetPosition = player.transform.TransformPoint(headPosition);
        gameObject.transform.position = Vector3.MoveTowards(transform.position, targetPosition, detectionDistance);
    }

    // The object is moving up and down until the player picks it. 
    private void shake() {
        transform.position += new Vector3(0, Mathf.Sin(Time.time * speed) * amount, 0);
    }
}
