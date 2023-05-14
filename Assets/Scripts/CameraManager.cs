using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Camera mainCamera;
    public Camera auxCamera;
    public GameObject player;  
    private PlayerController playerController;

    void Awake() {
        playerController = player.GetComponent<PlayerController>();          
    }    
    void Start()
    {
        mainCamera.enabled = true;
        auxCamera.enabled = false;        
    }

    void Update()
    {
        switchCamera();        
    }

    void switchCamera() {
        if (playerController.transform.position.x < 3.70f) {
            mainCamera.enabled = true;
            auxCamera.enabled = false;
        } else {
            mainCamera.enabled = false;
            auxCamera.enabled = true;            
        }
    }    
}
