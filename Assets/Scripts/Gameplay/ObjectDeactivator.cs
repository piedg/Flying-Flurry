using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDeactivator : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Obstacle"))
        {
            collision.gameObject.SetActive(false);
        }
    }
}
