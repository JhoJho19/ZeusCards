using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    private static int lvlNumber = 1;
    private static bool isMusicOn = true;
    private static bool isSoundOn = true;

    private void Awake()
    {
        LoadData();
    }


    private void OnDestroy()
    {
        SaveData();
    }

    public static void LvlPlus()
    {
        lvlNumber++;
    }

    public static int GetLevel() 
    { 
        int value = lvlNumber;
        return value;
    }

    public static bool GetMusic()
    { 
        return isMusicOn; 
    }

    public static bool GetSound() 
    {
        return isSoundOn;     
    } 

    public static void SwitchMusic()
    {
        if (isMusicOn)
        {
            isMusicOn = false;
        }
        else
        {
            isMusicOn = true;
        }
    }

    public static void SwitchSounds()
    {
        if (isSoundOn)
        {
            isSoundOn = false;
        }
        else
        {
            isSoundOn = true;
        }
    }

    public static void SaveData()
    {
        PlayerPrefs.SetInt("LevelNumber", lvlNumber);
        PlayerPrefs.SetInt("IsMusicOn", isMusicOn ? 1 : 0);
        PlayerPrefs.SetInt("IsSoundOn", isSoundOn ? 1 : 0);
        PlayerPrefs.Save();
    }

    public static void LoadData()
    {
        lvlNumber = PlayerPrefs.GetInt("LevelNumber", 1);
        isMusicOn = PlayerPrefs.GetInt("IsMusicOn", 1) == 1 ? true : false;
        isSoundOn = PlayerPrefs.GetInt("IsSoundOn", 1) == 1 ? true : false;
    }
}
