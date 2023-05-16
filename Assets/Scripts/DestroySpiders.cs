using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySpiders : MonoBehaviour
{
    public float topBoundPos;

    void Update()
    {
        if (transform.position.x < topBoundPos)
        {
            Destroy(gameObject);
        }
    }
}
