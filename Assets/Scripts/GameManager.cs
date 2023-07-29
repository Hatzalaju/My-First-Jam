using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void ChangeScene()
    {
        SceneManager.LoadScene("LevelOne");
    }

    public void Exit()
    {
        Application.Quit();
        Debug.Log("Exit");
    }

}