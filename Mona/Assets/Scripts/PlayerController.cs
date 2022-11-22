using System;
using System . Collections ;
using System . Collections . Generic ;
using UnityEngine ;
using UnityEngine.InputSystem;  
using UnityEngine .UI ;
using TMPro;

public class PlayerController : MonoBehaviour {

public Vector2 moveValue ;
public float speed ;
private int GemCount;
private AudioSource pop;
public TextMeshProUGUI GemText;
public TextMeshProUGUI UpgradeText;
public object DeathFloor;
public bool waterMove = false;

void Start () {
    GemCount = 0;
    waterMove = false;
    SetGemCountText();
    pop = GetComponent<AudioSource>();
}

void OnMove (InputValue value ) {
    moveValue = value.Get < Vector2 >() ;
}

void FixedUpdate () {
    Vector3 movement = new Vector3 ( moveValue .x , 0.0f , moveValue . y );

    GetComponent < Rigidbody >() . AddForce ( movement * speed * Time .
    fixedDeltaTime ) ;
}


void OnTriggerEnter(Collider other){
     if( other . gameObject . tag == "Gems" ) {
         other . gameObject . SetActive ( false ) ;
         GemCount += 1;
         SetGemCountText();
         pop.Play();
     }

     if (other.gameObject.tag == "Upgrade"){
        other.gameObject.SetActive(false);
        waterMove = true;

        SetUpgradeText();
     }

     if (other.gameObject.tag == "Stone")
     {
        other.gameObject.SetActive(false);
        LevelManager.instance.Win();
     }
 }

private void SetGemCountText(){
    GemText.text = "Gems: " + GemCount.ToString() + "/16";
}

private void SetUpgradeText(){
    UpgradeText.text = "Can walk on water: Yes";
}

}
