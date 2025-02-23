using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser_beam : MonoBehaviour
{
    private Collider2D col;
    private bool isPlayer;
    private Health character;
    public float damage = 5f;
    public float damageCd = 1f;
    private float timer = 1;
    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (col.enabled )
        {
            timer += Time.deltaTime;
            if ( timer > damageCd && isPlayer)
            {
                character.TakeDamage(damage);
                timer = 0;
            }
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.CompareTag("Player"))
        {
            isPlayer = true;
            character = col.GetComponent<Health>();
        }

    }
    void OnTriggerExit2D(Collider2D col)
    {

        if (col.CompareTag("Player"))
        {
            isPlayer = false;
            character = col.GetComponent<Health>();
        }

    }
    public bool getIsPlayer()
    {
        return isPlayer;
    }
}
