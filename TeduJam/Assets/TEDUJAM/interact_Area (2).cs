using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class interact_Area : MonoBehaviour
{
    public bool isFurniture = false;
    private Rigidbody2D boxRb;
    private Collider2D col;
    void Start()
    {
        col = GetComponent<Collider2D>();
    }
    void Update()
    {
        if(col == null)
        {
            col = GetComponent<Collider2D>();
        }
        if (isFurniture && boxRb != null)
        {
            boxRb.isKinematic = false; // Fizik motorundan etkilenmeyi kapat
            
            boxRb.velocity = Vector2.zero; // Anlýk hareketi durdur
            boxRb.transform.position = transform.position;
        }
        if(col.enabled == false)
        {
            isFurniture = false;

            if (boxRb != null)
            {
                boxRb.isKinematic = true; // Fizik motorunu tekrar aç
                boxRb = null;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("furniture"))
        {
            boxRb = collision.GetComponent<Rigidbody2D>();

            if (boxRb != null)
            {
                isFurniture = true;
            }
        }
    }

    /*private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("furniture"))
        {
            isFurniture = false;

            if (boxRb != null)
            {
                boxRb.isKinematic = false; // Fizik motorunu tekrar aç
                boxRb = null;
            }
        }
    }*/
}

