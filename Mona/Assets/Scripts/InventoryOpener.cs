using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryOpener : MonoBehaviour
{
    public GameObject Panel;

    // public void OpenPanel(){

    //     // if inventory panel is not open, open the panel
    //     if (Panel != null)
    //     {
    //         bool isActive = Panel.activeSelf;
    //         Panel.SetActive(!isActive);
    //         Time.timeScale = 0f;
    //     }
    // }

    public void showOrHide() {
          if (Panel.activeSelf == true) {
               Resume();
               Panel.SetActive(false);
               
          } else {
               Pause();
               Panel.SetActive(true);
               
          }
     }

     void Resume() {
          Time.timeScale = 1f;
     }

     void Pause() {
          Time.timeScale = 0f;
     }
    
}
