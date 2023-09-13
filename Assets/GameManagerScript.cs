using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverUi;




    public void gameOver()
    {
        gameOverUi.SetActive(true);
    }

}
