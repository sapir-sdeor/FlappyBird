using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public Rigidbody2D rigidB;
    
    /*
     * Move the enemies down
     */
    void Update()
    {
        rigidB.velocity = Vector2.down * GameManager.EnemySpeed;
    }

    /*
     * When the enemies out of the screen the score increase by 1.
     */
    private void OnBecameInvisible()
    {
        GameManager.TotalScore += 1;
    }
}
