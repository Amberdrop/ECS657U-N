using System;
using System . Collections ;
using System . Collections . Generic ;
using UnityEngine ;
using UnityEngine.InputSystem;  
using UnityEngine .UI ;
using TMPro;

public class PlayerController : MonoBehaviour {

public Transform cam;
public Vector2 moveValue ;
public float speed ;
private int GemCount;
private AudioSource pop;
public TextMeshProUGUI GemText;
public TextMeshProUGUI UpgradeText;
public TextMeshProUGUI MapUpgradeText;
public GameObject MapButton;
public bool waterMove = false;
public bool mapOpen = false;

void Start () {
    GemCount = 0;
    waterMove = false;
    SetGemCountText();
    pop = GetComponent<AudioSource>();
    mapOpen = false;
}

void OnMove (InputValue value ) {
    moveValue = value.Get < Vector2 >() ;
}

void FixedUpdate () {
    Vector3 movement = new Vector3 ( moveValue .x , 0.0f , moveValue . y );

    if (movement.magnitude >= 0.1f){
    //to get the player to turn to the direction that it is traveling
    float targetAngle = Mathf.Atan2(movement.x, movement.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
    transform.rotation = Quaternion.Euler(0f,targetAngle,0f);

    //to get player to move in the direction that camera is pointing at
    Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

    GetComponent < Rigidbody >() . AddForce (moveDir.normalized * speed * Time .
    fixedDeltaTime ) ;
    }
}


void OnTriggerEnter(Collider other){
    //if player collides with gem, increase gem count
     if( other . gameObject . tag == "Gems" ) {
         other . gameObject . SetActive ( false ) ;
         GemCount += 1;
         SetGemCountText();
         pop.Play();
     }

    //if player collides with water upgrade, allow for water movement
     if (other.gameObject.tag == "Upgrade"){
        other.gameObject.SetActive(false);
        waterMove = true;

        SetUpgradeText();
    //if player collides w map upgrade, enable map button
     } else if (other.gameObject.tag == "MapUpgrade"){
        other.gameObject.SetActive(false);
        mapOpen = true;
        MapButton.SetActive(true);
        SetMapUpgradeText();
     }
     //if player achieves quantum stone, win text pops up
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
    UpgradeText.text = "Water Up: Yes";
}

private void SetMapUpgradeText(){
    MapUpgradeText.text = "Can open map: Yes";
}

}
