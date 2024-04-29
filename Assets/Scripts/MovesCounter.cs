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
        RefreshMovesCoiunter();
    }

    private void RefreshMovesCoiunter()
    {
        textMeshProUGUI.text = moves.ToString();
    }
}
