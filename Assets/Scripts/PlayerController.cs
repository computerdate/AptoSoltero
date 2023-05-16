using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 1;
    public float angularSpeed = 1;
    private float horizontalInput;
    private float verticalInput;
    // The player has a task list to complete
    public ToDo toDo;
    private bool isObjectFocused;
    private GameObject focusedObject = null;
    public bool hasAnObject = false;
    public GameObject pickedObject = null;
    private Activate activateScript;
    private PlayerDetector playerDetector;
    //private AudioManager audioManager;


    // Instantiate the task list
    void Start()
    {
        toDo = new ToDo();
        //audioManager = Object.FindObjectOfType("AudioManager");
    }

    // Player only can walk forward or backward, or rotate 90 degrees
    void Update()
    {
        // Player rotates exactly 90 degrees
        if(Input.GetKeyDown(KeyCode.RightArrow)) {
            transform.Rotate(0, 90, 0);  
        } else if(Input.GetKeyDown(KeyCode.LeftArrow)) {
            transform.Rotate(0, -90, 0);  
        } else if(Input.GetKeyDown(KeyCode.N) && isObjectFocused) {
            selectObject();
        }
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);  
        Debug.Log("Focused object: " + focusedObject?.name);
    }

    public void pickObject(GameObject prop) {
        hasAnObject = true;
        foreach (Task task in toDo.toDoList) {
            if (task.prop.name == prop.name) {
                task.started = true;
            }
        }
    }

    public void focusObject(GameObject element) {
        if (element != null) {
            isObjectFocused = true;
            focusedObject = element;
        } 
    }

    public void unfocusObject(GameObject element) {
        if (focusedObject == element) {
            isObjectFocused = false;
            focusedObject = null;
        }         
    }

    public void selectObject() {
        string message;

        if (focusedObject.tag == "Prop" && !hasAnObject) {
/*             AudioManager.Instance.playPickUpSound();            
            hasAnObject = true;
            pickedObject = focusedObject;
            playerDetector = pickedObject.GetComponent<PlayerDetector>();
            playerDetector.attachedToPlayer();        
            toDo.startTaskByProp(pickedObject); */
            message = "Object picked up: " + focusedObject.name;
            pickUpObject();

        } else if (focusedObject.tag == "Prop" && hasAnObject) {
            message = "Already has an object.";

        } else if (focusedObject.tag == "Appliance" && hasAnObject) {
            message = "Let's see if the task is finished";
/*             if (toDo.verifyTask(pickedObject, focusedObject)) {
                AudioManager.Instance.playPutDownSound();                
                hasAnObject = false;
                playerDetector.detachedFromPlayer();
                playerDetector.destroyObject();
                if (toDo.verifyToDoListComplete()) {
                    Debug.Log("Mission completed!");
                    AudioManager.Instance.playApplauseSound();                     
                };                
            } else {
                AudioManager.Instance.playErrorSound();                 
            } */
            completeTask();

        } else if (focusedObject.tag == "Appliance" && !hasAnObject) {            
            message = "Go for an object";

        } else {
            message = "There is no focused object";
        }
        Debug.Log(message);
    }

    public void pickUpObject() {
        AudioManager.Instance.playPickUpSound();            
        hasAnObject = true;
        pickedObject = focusedObject;
        playerDetector = pickedObject.GetComponent<PlayerDetector>();
        playerDetector.attachedToPlayer();        
        toDo.startTaskByProp(pickedObject);
    }

    public void completeTask() {
        if (toDo.verifyTask(pickedObject, focusedObject)) {
            AudioManager.Instance.playPutDownSound();                
            hasAnObject = false;
            playerDetector.detachedFromPlayer();
            playerDetector.destroyObject();
/*             if (toDo.verifyToDoListComplete()) {
                Debug.Log("Mission completed!");
                AudioManager.Instance.playApplauseSound();                     
            }; */
            ckeckMissionCompleted();
        } else {
            AudioManager.Instance.playErrorSound();                 
        }
    }

    public void ckeckMissionCompleted() {
        if (toDo.verifyToDoListComplete()) {
            Debug.Log("Mission completed!");
            AudioManager.Instance.playApplauseSound();                     
        };     
    }

}
