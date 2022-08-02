using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walls : MonoBehaviour
{
    public float speed = 1;

    /*
     * Move the walls down.
     */
    void Update()
    {
        transform.position += (Vector3.down * speed) * Time.deltaTime;
    }
}
