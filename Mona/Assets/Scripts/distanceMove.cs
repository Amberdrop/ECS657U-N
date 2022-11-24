//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class distanceMove : MonoBehaviour
//{
//    [SerializeField] private Transform Enemy;

//    private float distance;

//    Vector3 originalPos;

//    private void Start()
//    {
//        originalPos = Enemy.transform.position;
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        // calculate distance
//        distance = (Enemy.transform.position - transform.position).magnitude;

//        if (distance > 10)
//        {
//            //Enemy.gameObject.SetActive(false);
//            Enemy.transform.position = originalPos;
//        }

//        else
//        {
//            Enemy.gameObject.SetActive(true);
//        }
//    }
//}
