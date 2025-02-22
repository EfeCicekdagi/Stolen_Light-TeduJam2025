using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interact_Box : MonoBehaviour
{
    public GameObject interactArea;
    private Collider2D col;
    private interact_Area script;
    private bool isCarrying = false;
    private int counter = 0;
    private float timer = 0;

    void Start()
    {
        col = interactArea.GetComponent<Collider2D>();
        col.enabled = false;
        script = interactArea.GetComponent<interact_Area>();
        

    }

    void Update()
    {
        if (isCarrying)
        {
            timer += Time.deltaTime;
            Debug.Log(timer);
        }
        
        if (Input.GetKeyDown(KeyCode.E) && !script.isFurniture)
        {
            isCarrying = true;
            col.enabled = true;
            Debug.Log(isCarrying);
            timer = 0;
            
            
            
        }
        if (Input.GetKeyDown(KeyCode.E) && script.isFurniture)
        {

            col.enabled = false;
            Debug.Log("disable 2");
            timer = 0;
        }
        if (timer > 1)
        {
            Debug.Log("disable 0");
            if (!script.isFurniture)
            {
                DisableCollider();

                Debug.Log("disable 1");
            }
            timer = 0;
        }

    }
    void DisableCollider()
    {
        col.enabled = false;
    }
    
}


/*void InteractStart()
{
    col.enabled = true;

    //Invoke("DisableCollider", 1f);
}
*/



