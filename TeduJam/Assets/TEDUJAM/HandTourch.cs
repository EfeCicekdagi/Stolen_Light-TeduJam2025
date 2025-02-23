using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class HandTourch : MonoBehaviour
{
    [SerializeField] float growthSpeed;
    [SerializeField] float reduceSpeed;
    [SerializeField] float brightnessSpeed;
    [SerializeField] float reducebrightnessSpeed;
    [SerializeField] LayerMask targetLayer;
    [SerializeField] float maxRadius;
    private Light2D light1;
    private Transform areaTransform;
    private float growthScale;
    private float brightnessCount;
    private ArrayList hitObjects1 = new ArrayList();
    void Start()
    {
        light1 = GetComponent<Light2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (light1.pointLightOuterRadius != 0)
        {
            Area();
        }

        
        if(Input.GetMouseButton(0) && light1.pointLightOuterRadius<maxRadius && light1.intensity<maxRadius){
            
            growthScale = Time.deltaTime * growthSpeed;
            brightnessCount = Time.deltaTime * brightnessSpeed;
            
            light1.pointLightOuterRadius += growthScale;
            light1.intensity += brightnessCount;

        }
        else{
            if(light1.pointLightOuterRadius > 0){
                light1.pointLightOuterRadius -= Time.deltaTime * reduceSpeed;
            }
            if(light1.intensity> 0){
                light1.intensity -= Time.deltaTime * reducebrightnessSpeed;
            }
        }
        if (light1.pointLightOuterRadius <= 0)
        {
            light1.intensity = 0;
            light1.pointLightOuterRadius = 0;
            
        }

    }
    /**
    public void Area()
    {
        Collider2D[] hitObjects = Physics2D.OverlapCircleAll(transform.position, light1.pointLightOuterRadius, targetLayer);
        foreach ( Collider2D  obj in hitObjects){
            ChangeColor color = obj.GetComponent<ChangeColor>();
            
            if(color != null){
                color.changetoBlue();
            }
        }
    }**/
    public void Area()
    {
        Collider2D[] currentObjects = Physics2D.OverlapCircleAll(transform.position, light1.pointLightOuterRadius, targetLayer);
        ArrayList newObjects = new ArrayList(currentObjects);
        ChangeColor color;
        TrapDetection spike1 ;
        laser lasercol;
        ButtonLightControl button;
        DoorController door;
        foreach (Collider2D obj in newObjects) {
            if (!hitObjects1.Contains(obj)) {
                hitObjects1.Add(obj);
            }


            Debug.Log("----------------");

            spike1 = obj.GetComponent<TrapDetection>();
            color = obj.GetComponent<ChangeColor>();
            lasercol = obj.GetComponent<laser>();
            button = obj.GetComponent<ButtonLightControl>();
            door = obj.GetComponent<DoorController>();

            if (color != null)
            {
                color.changetoBlue();
            }
            if (spike1 != null)
            {
                Debug.Log("efe yanlış");

                spike1.setLight(true);
            }
            if (lasercol != null)
            {
                lasercol.isLight(true);
            }
            if (button != null) {
                Debug.Log("efe yanlış");
                button.ButtonAccess(true);
            }
            if (door != null) {
                door.DoorPos(true);
            }
        

        }
        for(int i= hitObjects1.Count -1 ;i>=0 ; i--){
            Collider2D obj = (Collider2D)hitObjects1[i];
            if(!newObjects.Contains(obj)){
                color = obj.GetComponent<ChangeColor>();
                spike1 = obj.GetComponent<TrapDetection>();
                lasercol = obj.GetComponent<laser>();
                button = obj.GetComponent<ButtonLightControl>();
                door = GetComponent<DoorController>();
                if (color!= null){
                    color.ChangeRed();
                }
                if(spike1 != null){
                    spike1.setLight(false);
                }
                if (lasercol != null)
                {
                    lasercol.isLight(false);
                }
                if(button != null){
                    Debug.Log("efe yanlış");
                    button.ButtonAccess(false);
                }
                if(door != null){
                    door.DoorPos(false);
                }
                hitObjects1.Remove(obj);
            }
        }
    } 
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, light1.pointLightOuterRadius);
    }
}