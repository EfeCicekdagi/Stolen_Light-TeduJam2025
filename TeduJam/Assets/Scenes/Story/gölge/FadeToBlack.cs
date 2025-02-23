using UnityEngine;
using System.Collections;

public class FadeToBlack : MonoBehaviour
{
    public Renderer planeRenderer; // Plane'in Renderer bileşeni
    public float fadeDuration = 2f; // Siyahlaşma süresi
    private Material mat;

    void Start()
    {
        mat = planeRenderer.material;

        // **Material'ı Multiply Blend Mode ve Render Queue 3000 yap**
        mat.SetOverrideTag("RenderType", "Opaque");
        mat.renderQueue = 3000; // **Şeffaflık sıralaması için 3000**
        
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        Color originalColor = mat.color;
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / fadeDuration;
            mat.color = Color.Lerp(originalColor, Color.black, t); // **Siyahlaşma efekti**
            yield return null;
        }

        mat.color = Color.black; // **Tamamen siyah yap**
    }
}
