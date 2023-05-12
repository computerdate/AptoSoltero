using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
/*     private float angle = 0;
    public float angularSpeed = 10;
    public float amplitude = 0.50f;
    private float yPosition;
    private float speed; */
    public bool isOnGround = true;
    public float jumpForce = 1;
    public Rigidbody rb;
    private float startY;

    void Start()
    {
/*         yPosition = transform.position.y; */
	    rb = GetComponent<Rigidbody>();
        startY = transform.position.y;
    }

    void Update()
    {
        //Oscillate();
    }

    private void Oscillate() {
		if (isOnGround) {
			rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
			isOnGround = false;
	    }

/*         angle += angularSpeed * Time.deltaTime;      
        if (angle > 360) {
            angle = 0;
        }        
        speed = 45 * (1 - (transform.position.y - yPosition)/0.6f);         
        transform.Translate(Vector3.up * speed * Time.deltaTime); */
        //Debug.Log(transform.position.y);
        if (transform.position.y < startY) {
            isOnGround = true;
        }
    }

    private void OnCollisionEnter(Collision collision) {
	    isOnGround = true;
    }
}
