using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    public GameObject player;    
    private PlayerController playerController;
    private float detectionDistance = 0.6f; 
    public bool isPlayerClose;
    public bool isObjectPicked;
    public float playerHeadYPosition = 3;
    public float playerHeadZPosition = 0.5f;


    void Start()
    {
        playerController = player.GetComponent<PlayerController>();       
    }

    void Update()
    {
        Vector3 playerPosition = player.transform.position;
        Vector3 objectPosition = transform.position;
        // y-coordinates are ignored when calculating the distance between player and object
        float distance = Mathf.Pow(playerPosition.x - objectPosition.x, 2) + Mathf.Pow(playerPosition.z - objectPosition.z, 2);
        distance = Mathf.Sqrt(distance);
        if (distance < detectionDistance && !isObjectPicked) {                      
            isPlayerClose = true;   
            playerController.focusObject(gameObject);
        } else {
            isPlayerClose = false;
            playerController.unfocusObject(gameObject);
        } 
        if (isObjectPicked) {
            followPlayer();
        }        
    }

    public void attachedToPlayer() {
        isObjectPicked = true;
    } 

    public void detachedFromPlayer() {
        isObjectPicked = false;
    }

    public void followPlayer() {  
        Vector3 headPosition = new Vector3(0, playerHeadYPosition, playerHeadZPosition);
        Vector3 targetPosition = player.transform.TransformPoint(headPosition);
        gameObject.transform.position = Vector3.MoveTowards(transform.position, targetPosition, detectionDistance);
    }

    public void destroyObject() {
        Destroy(gameObject);
    }
  
}
