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
    
    public TextMeshProUGUI GemText, UpgradeText, MapUpgradeText;
    public GameObject InputSoFar;
    public GameObject Button1, Button2, Button3, Button4, Button5, Button6, Button7, Button8, Button9, Enter;
    public TextMeshProUGUI Slot1Text, Slot2Text, Slot3Text, Slot4Text;
    public Image img1, img2, img3, img4;

    public GameObject MapButton;
    public bool waterMove = false;
    public bool mapOpen = false;

    [SerializeField] private AudioSource collectGemSoundEffect, collectUpgradeSoundEffect, collectSlotSoundEffect;

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

        switch (other.gameObject.tag)
        {
            //if player collides with gem, increase gem count
            case "Gems":
                other . gameObject . SetActive ( false ) ;
                GemCount += 1;
                SetGemCountText();
                playSound(collectGemSoundEffect);
                break;
            
            //if player collides with water upgrade, allow for water movement
            case "Upgrade":
                other.gameObject.SetActive(false);
                waterMove = true;
                playSound(collectUpgradeSoundEffect);
                SetUpgradeText();
                break;
            
            //if player collides w map upgrade, enable map button
            case "MapUpgrade":
                other.gameObject.SetActive(false);
                mapOpen = true;
                MapButton.SetActive(true);
                playSound(collectUpgradeSoundEffect);
                SetMapUpgradeText();
                break;
            
            //if player achieves quantum stone, win text pops up
            case "Stone":
                other.gameObject.SetActive(false);
                LevelManager.instance.Win();
                break;
            
            //if player collects first slot diary entry
            case "Slot1":
                playSound(collectSlotSoundEffect);
                other.gameObject.SetActive(false);
                img1.gameObject.SetActive(false);
                SetSlot1Text();
                break;
            
            //if player collects second slot diary entry
            case "Slot2":
                playSound(collectSlotSoundEffect);
                other.gameObject.SetActive(false);
                img2.gameObject.SetActive(false);
                SetSlot2Text();
                break;
            
            //if player collects third slot diary entry
            case "Slot3":
                playSound(collectSlotSoundEffect);
                other.gameObject.SetActive(false);
                img3.gameObject.SetActive(false);
                SetSlot3Text();
                break;

            //if player collects forth slot diary entry
            case "Slot4":
                playSound(collectSlotSoundEffect);
                other.gameObject.SetActive(false);
                img4.gameObject.SetActive(false);
                SetSlot4Text();
                break;

            case "Password":
                //InputSoFar.SetActive(true);
                Button1.SetActive(true);
                Button2.SetActive(true);
                Button3.SetActive(true);
                Button4.SetActive(true);
                Button5.SetActive(true);
                Button6.SetActive(true);
                Button7.SetActive(true);
                Button8.SetActive(true);
                Button9.SetActive(true);
                Enter.SetActive(true);
                InputSoFar.SetActive(true);
                break;

            default:
                break;
        }
    }

    void OnTriggerExit(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Password":
                //InputSoFar.SetActive(false);
                Button1.SetActive(false);
                Button2.SetActive(false);
                Button3.SetActive(false);
                Button4.SetActive(false);
                Button5.SetActive(false);
                Button6.SetActive(false);
                Button7.SetActive(false);
                Button8.SetActive(false);
                Button9.SetActive(false);
                Enter.SetActive(false);
                InputSoFar.SetActive(false);
                break;

            default:
                break;

        }

    }

    private void playSound(AudioSource audioSource) {
        if (PlayerPrefs.HasKey("volume")) {
            audioSource.volume = PlayerPrefs.GetFloat("volume");
        }
        audioSource.Play();
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
