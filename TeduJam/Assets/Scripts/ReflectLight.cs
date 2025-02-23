using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectLight : MonoBehaviour
{
    public LayerMask layerMask; //Reflekt�r objelerin layer'�
    public GameObject[] lightSource; // Reflekt�r objelerin ���k kayna��
    public GameObject[] reflectors; //Reflekt�r objeler
    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < reflectors.Length; i++) // Reflekt�r objelerin say�s� kadar d�ng�
        {
            GameObject reflector = reflectors[i]; // Reflekt�r objesini al
            Vector2 lightToObj = (reflector.transform.position - transform.position).normalized; // I��k kayna�� ile reflekt�r aras�ndaki vekt�r
            float angle = Vector2.Angle(transform.up, lightToObj); // I��k kayna�� ile reflekt�r aras�ndaki a��

            if (angle < GetComponent<UnityEngine.Rendering.Universal.Light2D>().pointLightInnerAngle / 2f) // I��k kayna��n�n a��s�na g�re reflekt�r objesini aktif et
            {
                lightSource[i].gameObject.SetActive(true); // I��k kayna��n� aktif et
                RaycastHit2D hit2D = Physics2D.Raycast(transform.position, (reflector.transform.position - transform.position).normalized, 20f, layerMask); // I��k kayna�� ile reflekt�r aras�nda bir ���n �iz

                if (hit2D.collider != null)// E�er ���n bir objeye �arparsa
                {
                    Debug.DrawLine(transform.position, hit2D.point, Color.yellow, 0.1f);// I��k kayna�� ile �arp��an obje aras�nda bir �izgi �iz
                    Vector2 incomingDirection = (reflector.transform.position - transform.position).normalized; // I��k kayna�� ile �arp��an obje aras�ndaki vekt�r
                    Vector2 reflectedDirection = Vector2.Reflect(incomingDirection, hit2D.normal); // I��k kayna��n�n yans�yan y�n�
                    Debug.DrawRay(hit2D.point, reflectedDirection * 5f, Color.green, 1f); // Yans�yan y�n� �iz

                    // I��k kayna��n� yans�yan y�n�ne d�nd�r
                    lightSource[i].transform.up = reflectedDirection;

                }
            }
            else
            {
                lightSource[i].gameObject.SetActive(false);
            }
            Debug.Log(angle);
        }




    }
}
