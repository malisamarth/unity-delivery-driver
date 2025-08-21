using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Collision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("ouch!!");
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("congratss on this feat!!");
    }
}

