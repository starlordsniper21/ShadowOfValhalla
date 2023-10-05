using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // This function will be called when the "Chapter 1" button is clicked.
    public void PlayChapter1()
    {
        SceneManager.LoadSceneAsync("CHAPTER 1");
    }

    // This function will be called when the "Chapter 2" button is clicked.
    public void PlayChapter2()
    {
        SceneManager.LoadSceneAsync("CHAPTER 2");
    }

    // This function will be called when the "Chapter 3" button is clicked.
    public void PlayChapter3()
    {
        SceneManager.LoadSceneAsync("CHAPTER 3");
    }

    // This function will be called when the "Chapter 4" button is clicked.
    public void PlayChapter4()
    {
        SceneManager.LoadSceneAsync("CHAPTER 4");
    }

    // This function will be called when the "Chapter 5" button is clicked.
    public void PlayChapter5()
    {
        SceneManager.LoadSceneAsync("CHAPTER 5");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
