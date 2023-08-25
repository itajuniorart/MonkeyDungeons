using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuFunctions : MonoBehaviour
{
    [SerializeField] private SystemVariables systemVariables;
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Exit()
    {
        SceneManager.LoadScene("START");
    }

    public void StartGame()
    {
        if(systemVariables.tutorial == true)
        {
            TutorialGame();
        }
        else
        {
            SceneManager.LoadScene("GAMEJAM");
        }
        
    }

    public void TutorialGame()
    {
        systemVariables.tutorial = true;
        SceneManager.LoadScene("START");
        
    }
}


