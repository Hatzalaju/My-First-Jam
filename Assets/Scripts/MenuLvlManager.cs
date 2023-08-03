using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuLvlManager : MonoBehaviour
{
    public GameObject menuPanel; 
    private bool isMenuOpen = false;

    private void Start()
    {
        menuPanel.SetActive(false); 
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleMenu();
        }
    }

    public void ToggleMenu()
    {
        isMenuOpen = !isMenuOpen;

        if (isMenuOpen)
        {
            Time.timeScale = 0f; 
            menuPanel.SetActive(true);
        }
        else
        {
            Time.timeScale = 1f; 
            menuPanel.SetActive(false);
        }
    }

    public void ReturnMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Exit()
    {
        Application.Quit();
        Debug.Log("Exit");
    }
}
