using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class BlinkLight : MonoBehaviour
{
    [SerializeField] Light2D myLight;
    [SerializeField] float interval = 1f;
    [SerializeField] LayerMask targetLayer;
    private ArrayList hitObjects1 = new ArrayList();
    private float timer = 0f;

    void Update()
    {
        
        timer += Time.deltaTime;

        if (timer >= interval)
        {
            Area();
            myLight.enabled = !myLight.enabled; // Işığı aç/kapat
            timer = 0f; // Sayaç sıfırla
        }
    }
        public void Area()
    {
        Collider2D[] currentObjects = Physics2D.OverlapCircleAll(transform.position, myLight.pointLightOuterRadius, targetLayer);
        ArrayList newObjects = new ArrayList(currentObjects);
        ChangeColor color;
        TrapDetection spike1 ;
        laser lasercol;
        ButtonLightControl button;
        DoorController door;
        foreach ( Collider2D  obj in newObjects){
            if(!hitObjects1.Contains(obj)){
                hitObjects1.Add(obj);
            }
            Vector2 start = myLight.transform.position;
            Vector2 target = obj.GetComponent<Collider2D>().bounds.center; // Collider'ın merkezini al
            Vector2 direction = (target - start).normalized;
            RaycastHit2D ray = Physics2D.Raycast(myLight.transform.position, (target-start).normalized, 50f, targetLayer);
            
            if (ray.collider != null){
                Debug.DrawLine(myLight.transform.position, target, Color.green);
                if (ray.collider.gameObject == obj.gameObject)
                {        
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
                        spike1.setLight(true);
                    }
                    if (lasercol != null)
                    {
                        lasercol.isLight(true);
                    }
                    if(button != null){
                        Debug.Log("button tespit edildi");
                        button.ButtonAccess(true);
                    }
                    if(door != null){
                        door.DoorPos(true);
                    }
                }
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
                    Debug.Log("button tespit edildi");
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
        Gizmos.DrawWireSphere(transform.position, myLight.pointLightOuterRadius);
    }
}
