using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public GameObject youWinText;

    private void Awake () {
        if (LevelManager.instance == null) instance = this;
        else Destroy(gameObject);
    }

    public void GameOver(){
        UIManager _ui = GetComponent<UIManager>();
        
        //turn on death panel when player dies
        if (_ui != null) {
            _ui.ToggleDeathPanel();
        }

        //ensure game is paused when player dies
        Time.timeScale=0f;
    }

    public void Win(){
        //when player hits quantum stone, the win text pops up
        youWinText.SetActive (true);

    }
}
