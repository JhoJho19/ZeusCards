using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FillAmountAnimation : MonoBehaviour
{
    [SerializeField] Image image;
    [SerializeField] float duration = 1f;

    void Start()
    {
        StartCoroutine(ChangeFillAmount(0f, 1f, duration));
    }

    IEnumerator ChangeFillAmount(float startValue, float endValue, float animationDuration)
    {
        float elapsedTime = 0f;
        while (elapsedTime < animationDuration)
        {
            float fillAmount = Mathf.Lerp(startValue, endValue, elapsedTime / animationDuration);
            image.fillAmount = fillAmount;
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        image.fillAmount = endValue;
    }
}
