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

    public void IsWeWin()
    {
        if(goldCards1 == null && goldCards2 == null && goldCards3 == null && goldCards4 == null)
        {
            canvasWin.gameObject.SetActive(true);
        }
        else if (FindObjectOfType<MovesCounter>().moves <= 0 && (goldCards1 != null || goldCards2 != null || goldCards3 != null || goldCards4 != null) )
        {
            canvasLose.gameObject.SetActive(true);
        }
    }

    //private void Update()
    //{
    //    IsWeWin();
    //}
}
