using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkipScene : MonoBehaviour
{
    public void SkipButton()
    {
        SceneManager.LoadSceneAsync("CHATPER 1 CUTSCENE");
    }
}
