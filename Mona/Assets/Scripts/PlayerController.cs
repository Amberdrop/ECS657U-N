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
public TextMeshProUGUI GemText;
public TextMeshProUGUI UpgradeText;
public TextMeshProUGUI MapUpgradeText;
public object DeathFloor;
public GameObject MapButton;
public bool waterMove = false;
public bool mapOpen = false;

void Start () {
GemCount = 0;
waterMove = false;
SetGemCountText();
mapOpen = false;
}

void OnMove (InputValue value ) {
moveValue = value.Get < Vector2 >() ;
}

void FixedUpdate () {
Vector3 movement = new Vector3 ( moveValue .x , 0.0f , moveValue . y );

GetComponent < Rigidbody >() . AddForce ( movement * speed * Time .
fixedDeltaTime ) ;
}


void OnTriggerEnter ( Collider other ) {
 if( other . gameObject . tag == "Gems" ) {
 other . gameObject . SetActive ( false ) ;
 GemCount += 1;
 SetGemCountText();
 }
 if (other.gameObject.tag == "Upgrade"){
    other.gameObject.SetActive(false);
    waterMove = true;

    SetUpgradeText();
 }
  else if (other.gameObject.tag == "MapUpgrade"){
    other.gameObject.SetActive(false);
    mapOpen = true;
    MapButton.SetActive(true);
    SetMapUpgradeText();
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

private void SetMapUpgradeText(){
    MapUpgradeText.text = "Can open map: Yes";
}

}
