using UnityEngine;
using UnityEngine.SceneManagement; 

public class ButtonInteraction : MonoBehaviour
{
    private bool isPlayerNear = false; 

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            isPlayerNear = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            isPlayerNear = false;
        }
    }

    void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E)) 
        {
            SceneManager.LoadScene("Ended Successfully"); 
        }
    }
}
