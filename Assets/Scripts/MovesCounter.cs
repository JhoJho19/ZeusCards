using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MovesCounter : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textMeshProUGUI;
    public int moves;
    Lightnings lightnings;
    LoseWinLogic loseWinLogic;

    private void Start()
    {
        if (textMeshProUGUI != null)
        textMeshProUGUI.text = moves.ToString();
    }

    public void MovesCounterMinus()
    {
        moves--;

        if (moves < 0)
            moves = 0;

        textMeshProUGUI.text = moves.ToString();

        if (lightnings == null)
            lightnings = FindObjectOfType<Lightnings>();
        lightnings.RandomizeLightning();

        Invoke("CheckWin", 0.5f);
    }

    public void MovesCounterPlus()
    {
        moves++;
        textMeshProUGUI.text = moves.ToString();
        if (lightnings == null)
            lightnings = FindObjectOfType<Lightnings>();
        lightnings.RandomizeLightning();

        Invoke("CheckWin", 0.5f);
    }
    
    private void CheckWin()
    {
        if (loseWinLogic == null)
            loseWinLogic = FindObjectOfType<LoseWinLogic>();
        loseWinLogic.WinChecker();
    }
}
