using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseWinLogic : MonoBehaviour
{
    [SerializeField] GameObject goldCards1;
    [SerializeField] GameObject goldCards2;
    [SerializeField] GameObject goldCards3;
    [SerializeField] GameObject goldCards4;
    [SerializeField] Canvas canvasWin;
    [SerializeField] Canvas canvasLose;

    public void IsWeWinWithZero()
    {
        if(goldCards1 == null && goldCards2 == null && goldCards3 == null && goldCards4 == null)
        {
            canvasWin.gameObject.SetActive(true);
        }
        else
        {
            Invoke("Lose", 0.5f);
        }
    }

    private void Lose()
    {
        canvasLose.gameObject.SetActive(true);
    }

    private void FixedUpdate()
    {
        IsWeWinWithZOutero();
    }

    public void IsWeWinWithZOutero()
    {
        if (goldCards1 == null && goldCards2 == null && goldCards3 == null && goldCards4 == null)
        {
            canvasWin.gameObject.SetActive(true);
        }
        else
        {
            return;
        }
    }
}
