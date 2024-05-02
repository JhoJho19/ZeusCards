using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    public void PlayButtonPushed()
    {
       StartCoroutine(LoadSceneAsync());
    }

    IEnumerator LoadSceneAsync()
    {
        int sceneindex = GameData.GetLevel();
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneindex);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.85f);
            yield return null;
        }
    }
}
