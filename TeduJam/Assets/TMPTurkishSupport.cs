using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class TMPTurkishSupport : MonoBehaviour
{
    public TMP_Text textMeshPro; // TextMeshPro bileşeni
    public TMP_FontAsset fallbackFont; // Fallback font (isteğe bağlı)

    // Türkçe karakterleri içeren test metni
    private string sampleText = "Türkçe Karakter Testi: Ç,Ğ,Ş,İ,Ö,Ü,ç,ğ,ş,ı,ö,ü";

    void Start()
    {
        if (textMeshPro == null)
        {
            textMeshPro = GetComponent<TMP_Text>(); // Eğer atanmadıysa otomatik olarak al
        }

        if (textMeshPro != null)
        {
            textMeshPro.text = sampleText; // Türkçe karakterleri test için yazdır

            // Eğer font Türkçe karakterleri desteklemiyorsa fallback ekle
            if (fallbackFont != null && !textMeshPro.font.HasCharacter('ğ')) // 'ğ' desteklenmiyorsa
            {
                if (!textMeshPro.font.fallbackFontAssetTable.Contains(fallbackFont))
                {
                    textMeshPro.font.fallbackFontAssetTable.Add(fallbackFont);
                    Debug.LogWarning("Ana font Türkçe karakterleri desteklemiyor, fallback font eklendi!");
                }
            }
            else if (!textMeshPro.font.HasCharacter('ğ'))
            {
                Debug.LogError("Ana font Türkçe karakterleri desteklemiyor ve fallback font atanmadı!");
            }
        }
        else
        {
            Debug.LogError("TextMeshPro bileşeni atanmadı!");
        }
    }
}
