using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class couldown : MonoBehaviour
{
    public Image filledImage;
    public float fillDuration = 2.0f;

    private bool isFilling = false;

    private void Update()
    {
        // Space tu�una bas�ld���nda i�lemi ba�lat
        if (Input.GetKeyDown(KeyCode.Space) && !isFilling)
        {
            StartCoroutine(FillImage());
        }
    }

    private IEnumerator FillImage()
    {
        isFilling = true;

        // FillAmount'u 1'den 0'a do�ru azalt
        float elapsedTime = 0f;
        while (filledImage.fillAmount > 0f)
        {
            elapsedTime += Time.deltaTime;
            filledImage.fillAmount = Mathf.Lerp(1f, 0f, elapsedTime / fillDuration);
            yield return null;
        }

        // FillAmount'u 0'dan 1'e do�ru art�r
        elapsedTime = 0f;
        while (filledImage.fillAmount < 1f)
        {
            elapsedTime += Time.deltaTime;
            filledImage.fillAmount = Mathf.Lerp(0f, 1f, elapsedTime / fillDuration);
            yield return null;
        }

        isFilling = false;
    }

}
