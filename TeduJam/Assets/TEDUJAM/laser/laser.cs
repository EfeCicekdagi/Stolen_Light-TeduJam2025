using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class laser : MonoBehaviour
{
    // Start is called before the first frame update
    private float distanceX;
    public GameObject laserBeam;
    private Collider2D laserCol;
    private laser_detect_area isPlayer;
    private bool areaLight;
    private Animator anim;
    private bool laserActive;
    void Start()
    {
        
        if (laserBeam != null)
        {
            anim = laserBeam.GetComponent<Animator>();
            laserCol = laserBeam.GetComponent<Collider2D>();
            laserCol.enabled = false;
        }
        isPlayer = GetComponentInChildren<laser_detect_area>();
    }

    // Update is called once per frame
    void Update()
    {
        ControlCollieder(areaLight);
    }
    public void ControlCollieder(bool light)
    {
        if(light && isPlayer.getIsPlayer())
        {
            if(laserActive!=true)
            {
                laserActive = true;
                anim.SetTrigger("active");
            }
            
            laserCol.enabled = true;
        }
        else
        {
            if (laserActive != false)
            {
                laserActive = false;
                anim.SetTrigger("deActive");
            }

            laserCol.enabled = false;
        }
    }
     public void isLight(bool light)
    {
        this.areaLight = light;
    }

    
}
