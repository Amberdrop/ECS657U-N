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
private int ScrewCount;
public TextMeshProUGUI GemText;
public TextMeshProUGUI ScrewText;

void Start () {
GemCount = 0;
ScrewCount=0;
SetCountText();
}

void OnMove (InputValue value ) {
moveValue = value.Get < Vector2 >() ;
}

void FixedUpdate () {
Vector3 movement = new Vector3 ( moveValue .x , 0.0f , moveValue . y ) ;

GetComponent < Rigidbody >() . AddForce ( movement * speed * Time .
fixedDeltaTime ) ;
}


void OnTriggerEnter ( Collider other ) {
 if( other . gameObject . tag == "Gems" ) {
 other . gameObject . SetActive ( false ) ;
 GemCount += 1;
 SetCountText();
 }
 if (other.gameObject.tag == "Screw"){
    other.gameObject.SetActive( false);
    ScrewCount += 1;
    SetCountText();
 }
}

private void SetCountText(){
    GemText.text = "Gem: " + GemCount.ToString();
    ScrewText.text = "Screw: " + ScrewCount.ToString();
}

}
