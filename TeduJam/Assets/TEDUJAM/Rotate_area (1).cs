using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Rotate_area : MonoBehaviour
{
    private Collider2D col;
    private GameObject box = null;
    private bool isFurniture = false;
    public float rotationAngle = 45f;
    void Start()
    {
        col = GetComponent<Collider2D>();
    }

    
    void Update()
    {
        if ( Input.GetKeyDown(KeyCode.R) && isFurniture && box!=null)
        {
            box.transform.Rotate(0f, 0f, rotationAngle);
            Debug.Log(box);
        }
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("furniture"))
        {
            box = collision.gameObject;

            if (box != null)
            {
                isFurniture = true;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("furniture"))
        {
            isFurniture = false;
            box = null; 
        }
    }
}
