using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySpiders : MonoBehaviour
{
    public float topBoundPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < topBoundPos)
        {
            Destroy(gameObject);
        }
    }
}
