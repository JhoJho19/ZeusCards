using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MovesCounter : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textMeshProUGUI;
    [SerializeField] int moves;

    private void Start()
    {
        textMeshProUGUI.text = moves.ToString();
    }

    public void MovesCounterMinus()
    {
        moves--;
        textMeshProUGUI.text = moves.ToString();
    }
}
