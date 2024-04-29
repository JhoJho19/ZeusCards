using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseWinLogic : MonoBehaviour
{
    [SerializeField] GameObject [] goldCards;
    [SerializeField] Canvas canvasWin;
    [SerializeField] Canvas canvasLose;

    public void WinChecker()
    {
        bool allNull = System.Array.TrueForAll(goldCards, card => card == null);

        if (allNull)
        {
            canvasWin.gameObject.SetActive(true);
        }
        else if(FindObjectOfType<MovesCounter>().moves <= 0)
        {
            canvasWin.gameObject.SetActive(true);
        }
        else
        {
            return;
        }
    }
}
