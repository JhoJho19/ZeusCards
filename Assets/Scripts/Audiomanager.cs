using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioSource thunderSource;

    public AudioClip mainTheme;
    public AudioClip thunderSound;

    private void Start()
    {
        if (GameData.GetMusic())
        {
            if (!musicSource.isPlaying)
            {
                PlayMainTheme();
            }
        }
        else
        {
            musicSource.Stop();
        }
    }

    void PlayMainTheme()
    {
        musicSource.clip = mainTheme;
        musicSource.loop = true;
        musicSource.Play();
    }

    public void PlayThunderSound()
    {
        if (GameData.GetSound())
        {
            thunderSource.clip = thunderSound;
            thunderSource.Play();
        }
    }
}
