using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingChoose : MonoBehaviour
{
    public void PlayKillCutscene()
    {
        SceneManager.LoadSceneAsync("KILL CANUTE 1");

    }

    public void PlaySpareCutscene()
    {
        SceneManager.LoadSceneAsync("SPARE CANUTE SCENE 1");

    }

    public void PlayTalkCutscene()
    {
        SceneManager.LoadSceneAsync("TALK ENDING");

    }
}
