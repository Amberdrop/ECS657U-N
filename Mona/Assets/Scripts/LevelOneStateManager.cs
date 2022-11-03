using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelOneManager : MonoBehaviour
{
    public void RetryGame (){
         SceneManager.LoadScene ("Level1");
    }

    public void BackToMenu(){
        SceneManager.LoadScene("Menu");
    }

}
