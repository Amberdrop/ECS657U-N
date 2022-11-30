using System;
using System . Collections ;
using System . Collections . Generic ;
using UnityEngine ;
using UnityEngine.InputSystem;  
using UnityEngine .UI ;
using TMPro;

public class MapButtonScript : MonoBehaviour {

     public TextMeshProUGUI mapButton;

     public void showOrHide(GameObject obj) {
          if (obj.activeSelf == true) {
               Resume();
               obj.SetActive(false);
               mapButton.text = "Open Map";
          } else {
               Pause();
               obj.SetActive(true);
               mapButton.text = "Close Map";
          }
     }

     void Resume() {
          Time.timeScale = 1f;
     }

     void Pause() {
          Time.timeScale = 0f;
     }

     public void show(GameObject obj) {
      obj.SetActive(true);
     }

     public void hide(GameObject obj) {
      obj.SetActive(false);
     }
     
     void Start() {

     }

     // Update is called once per frame
     void Update() {
          
     }
}
