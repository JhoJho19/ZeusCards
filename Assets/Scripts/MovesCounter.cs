using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MovesCounter : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textMeshProUGUI;
    public int moves;

    private void Start()
    {
        textMeshProUGUI.text = moves.ToString();
    }

    public void MovesCounterMinus()
    {
        moves--;
        textMeshProUGUI.text = moves.ToString();
    }

    public void MovesCounterPlus()
    {
        moves++;
        textMeshProUGUI.text = moves.ToString();
    }
}
