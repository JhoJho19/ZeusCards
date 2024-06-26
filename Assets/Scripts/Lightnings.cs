using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightnings : MonoBehaviour
{
    [SerializeField] GameObject [] lighnings;
    public void RandomizeLightning()
    {
        if (lighnings != null)
        {
            StartCoroutine(RandomizeLightnings());
        }
    }

    IEnumerator RandomizeLightnings()
    {
        for (int i = 0; i < 2; i++) 
        {
            int randomIndex = Random.Range(0, lighnings.Length);
            lighnings[randomIndex].SetActive(true);
            yield return new WaitForSeconds(0.1f);
            lighnings[randomIndex].SetActive(false);
            yield return new WaitForSeconds(0.1f);
            FindObjectOfType<LoseWinLogic>().IsWeWin();
            yield return new WaitForSeconds(0.5f);
        }
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }
}
