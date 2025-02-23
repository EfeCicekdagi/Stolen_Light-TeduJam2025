using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SpaceScroller : MonoBehaviour
{
    [SerializeField] private float scrollSpeed = 0.5f;

    private float offset;
    private Material backgroundMaterial;

    void Start()
    {
        backgroundMaterial = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        offset += (scrollSpeed + Time.deltaTime)/10f;
        backgroundMaterial.SetTextureOffset("_MainTex", new Vector2(offset,0));
    }
}
