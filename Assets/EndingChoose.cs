using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingChoose : MonoBehaviour
{
    public void PlayKillCutscene()
    {
        SceneManager.LoadSceneAsync("KILL ENDING");

    }

    public void PlaySpareCutscene()
    {
        SceneManager.LoadSceneAsync("SPARE ENDING");

    }

    public void PlayTalkCutscene()
    {
        SceneManager.LoadSceneAsync("TALK ENDING");

    }
}
