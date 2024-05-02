using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsChecker : MonoBehaviour
{
    [SerializeField] Button [] buttons;

    private void OnEnable()
    {
        ButtonCheck();
    }

    void ButtonCheck()
    {
        for (int i = 0; i < buttons.Length; i++) 
        { 
            if (i < GameData.GetLevel())
            {
                buttons[i].interactable = true;   
            }
            else
            {
                buttons[i].interactable = false;
            }
        }
    }
}
