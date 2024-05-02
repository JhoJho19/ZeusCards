using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalkaChecker : MonoBehaviour
{
    [SerializeField] GameObject galkaMusic;
    [SerializeField] GameObject galkaSound;

    private void OnEnable()
    {
        GalkasCheck();
    }

    private void GalkasCheck() 
    { 
        if(GameData.GetMusic())
        {
            galkaMusic.gameObject.SetActive(true);
        }
        else { galkaMusic.gameObject.SetActive(false); }

        if (GameData.GetSound())
        {
            galkaSound.gameObject.SetActive(true);
        }
        else { galkaSound.gameObject.SetActive(false); }
    }

    public void SwitchMusicButton()
    {
        GameData.SwitchMusic();
        GalkasCheck();
    }

    public void SwitchSoundButton() 
    {
        GameData.SwitchSounds();
        GalkasCheck();
    }
}
