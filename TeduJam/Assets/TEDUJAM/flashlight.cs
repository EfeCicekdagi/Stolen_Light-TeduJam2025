using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class flashlight : MonoBehaviour
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
        Area();
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
        foreach ( Collider2D  obj in newObjects){
            if(!hitObjects1.Contains(obj)){
                hitObjects1.Add(obj);
            }
            color = obj.GetComponent<ChangeColor>();
            if(color != null){
                color.changetoBlue();
            }
        }
        for(int i= hitObjects1.Count -1 ;i>=0 ; i--){
            Collider2D obj = (Collider2D)hitObjects1[i];
            if(!newObjects.Contains(obj)){
                color = obj.GetComponent<ChangeColor>();
                if(color!= null){
                    color.ChangeRed();
                }
                hitObjects1.Remove(obj);
            }
        }
    } 

}
