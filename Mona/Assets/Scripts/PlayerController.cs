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
    public TextMeshProUGUI GemText;
    public TextMeshProUGUI UpgradeText;
    public TextMeshProUGUI MapUpgradeText;
    public TextMeshProUGUI Slot1Text;
    public Image img1;
    public TextMeshProUGUI Slot2Text;
    public Image img2;
    public TextMeshProUGUI Slot3Text;
    public Image img3;
    public TextMeshProUGUI Slot4Text;
    public Image img4;

    public GameObject MapButton;
    public bool waterMove = false;
    public bool mapOpen = false;

    [SerializeField] private AudioSource collectGemSoundEffect;
    [SerializeField] private AudioSource collectUpgradeSoundEffect;


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
            collectGemSoundEffect.Play();
        }

        //if player collides with water upgrade, allow for water movement
        if (other.gameObject.tag == "Upgrade"){
            other.gameObject.SetActive(false);
            waterMove = true;
            collectUpgradeSoundEffect.Play();
            SetUpgradeText();
        //if player collides w map upgrade, enable map button
        } else if (other.gameObject.tag == "MapUpgrade"){
            other.gameObject.SetActive(false);
            mapOpen = true;
            MapButton.SetActive(true);
            collectUpgradeSoundEffect.Play();
            SetMapUpgradeText();
        }
        //if player achieves quantum stone, win text pops up
        if (other.gameObject.tag == "Stone")
        {
            other.gameObject.SetActive(false);
            LevelManager.instance.Win();
        }

        //if player collects first slot diary entry
        if (other.gameObject.tag == "Slot1"){
            other.gameObject.SetActive(false);
            img1.gameObject.SetActive(false);
            SetSlot1Text();
        }

        //if player collects second slot diary entry
        if (other.gameObject.tag == "Slot2"){
            other.gameObject.SetActive(false);
            img2.gameObject.SetActive(false);
            SetSlot2Text();
        }
        
        //if player collects second slot diary entry
        if (other.gameObject.tag == "Slot3"){
            other.gameObject.SetActive(false);
            img3.gameObject.SetActive(false);
            SetSlot3Text();
        }

        //if player collects second slot diary entry
        if (other.gameObject.tag == "Slot4"){
            other.gameObject.SetActive(false);
            img4.gameObject.SetActive(false);
            SetSlot4Text();
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

    private void SetSlot1Text(){
        Slot1Text.text = "#1 Diary Entry slot holder";
    }
    private void SetSlot2Text(){
        Slot2Text.text = "#2 Diary Entry slot holder";
    }

    private void SetSlot3Text(){
        Slot3Text.text = "#3 Diary Entry slot holder";
    }

    private void SetSlot4Text(){
        Slot4Text.text = "#4 Diary Entry slot holder";
    }

}
