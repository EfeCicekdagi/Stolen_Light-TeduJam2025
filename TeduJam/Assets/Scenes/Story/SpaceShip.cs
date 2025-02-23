using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpaceShip : MonoBehaviour
{

    public RectTransform movingUIElement; // UI Image objesi
    public float moveSpeed = 10000000000000f; // Hareket hızı (UI için daha büyük bir değer)
    public string sceneToLoad; // Yüklenecek sahne adı

    public void StartSceneTransition()
    {
        StartCoroutine(MoveUIAndLoadScene());
    }

    IEnumerator MoveUIAndLoadScene()
    {
        float timer = 0f;
        Vector2 startPos = movingUIElement.anchoredPosition;
        Vector2 targetPos = startPos + new Vector2(10000f, 0); // Sağa doğru hareket

        while (timer < 0.4f) // Belirtilen saniye boyunca hareket edecek
        {
            movingUIElement.anchoredPosition = Vector2.Lerp(startPos, targetPos, timer / 2f);
            timer += Time.deltaTime;
            yield return null;
        }

        SceneManager.LoadScene(sceneToLoad); // Yeni sahneyi yükle
    }
}
