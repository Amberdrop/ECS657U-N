using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterScript : MonoBehaviour
{
    public PlayerController Player;

    public GameObject Water;

    void Start()
    {
        Water.GetComponent<BoxCollider>().enabled = false;
    }

    void Update()
    {
        if (Player.waterMove == true)
        {
            Water.GetComponent<BoxCollider>().enabled = true;
        }
    }
}
