using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelOneStateManager : MonoBehaviour
{

    public void RetryGame (){
         SceneManager.LoadScene ("Level1");
    }

    public void BackToMenu(){
        SceneManager.LoadScene("Menu");
    }

}
