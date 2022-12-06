using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelOneStateManager : MonoBehaviour
{

    public void RetryGame (){
        Time.timeScale=1;
         SceneManager.LoadScene ("Level1");
    }

    public void BackToMenu(){
        Time.timeScale=1;
        SceneManager.LoadScene("Menu");
    }

}
