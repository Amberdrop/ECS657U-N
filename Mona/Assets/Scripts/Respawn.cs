using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public GameObject Player;
    public GameObject RespawnPoint;
   
   void OnTriggerEnter(Collider other){
    Player.transform.position = RespawnPoint.transform.position;
   }
}
