using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public GameObject Player;
    public GameObject RespawnPoint;

   void OnTriggerEnter(Collider other){
        if (other.gameObject.tag == "Player") { 
            LevelManager.instance.GameOver();
            gameObject.SetActive(false);
            /// Player.transform.position = RespawnPoint.transform.position;
    } 
  }


}
 