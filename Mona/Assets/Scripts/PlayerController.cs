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
    public GameObject Button1, Button2, Button3, Button4, Button5, Button6, Button7, Button8, Button9, Enter, Clear;
    public GameObject ship;
    public TextMeshProUGUI Slot1Text, Slot2Text, Slot3Text, Slot4Text;
    public Image img1, img2, img3, img4;

    public GameObject MapButton;
    public GameObject Doorway;
    public bool waterMove = false;
    public bool mapOpen = false;
    public bool playerHasMoved = false;

    [SerializeField] private AudioSource collectGemSoundEffect, collectUpgradeSoundEffect, collectSlotSoundEffect;

    void Start () {
        GemCount = 0;
        waterMove = false;
        SetGemCountText();
        mapOpen = false;

        if (PlayerPrefs.HasKey("speed")) {
            speed = PlayerPrefs.GetInt("speed");
        }

        if (PlayerPrefs.HasKey("diaries")) {
            string diaryCheckpoint = PlayerPrefs.GetString("diaries");
            string[] diaryArray =  diaryCheckpoint.Split(char.Parse(" "));
            
            if (diaryArray[0] == "1") {
                Debug.Log("first diary found from past game session");
                img1.gameObject.SetActive(false);
                SetSlot1Text();
            }
            if (diaryArray[1] == "1") {
                Debug.Log("second diary found from past game session");
                img2.gameObject.SetActive(false);
                SetSlot2Text();
            }
            if (diaryArray[2] == "1") {
                Debug.Log("third diary found from past game session");
                img3.gameObject.SetActive(false);
                SetSlot3Text();
            }
            if (diaryArray[3] == "1") {
                Debug.Log("fourth diary found from past game session");
                img4.gameObject.SetActive(false);
                SetSlot4Text();
            }

        }
    }

    void OnMove (InputValue value ) {
        moveValue = value.Get < Vector2 >() ;
    }

    void FixedUpdate () {
        Vector3 movement = new Vector3 ( moveValue .x , 0.0f , moveValue . y );

        if (movement.magnitude >= 0.1f){
            
            if (!playerHasMoved) {
                playerHasMoved = true;
                // Debug.Log("player first moved");
                deactiveSpaceship();
            }
            
            //to get the player to turn to the direction that it is traveling
            float targetAngle = Mathf.Atan2(movement.x, movement.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            transform.rotation = Quaternion.Euler(0f,targetAngle,0f);

            //to get player to move in the direction that camera is pointing at
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            GetComponent < Rigidbody >() . AddForce (moveDir.normalized * speed * Time .
            fixedDeltaTime ) ;
        }
    }

    void deactiveSpaceship() {
        ship.SetActive(false);
    }

    void OnTriggerEnter(Collider other){

        switch (other.gameObject.tag)
        {
            //if player collides with gem, increase gem count
            case "Gems":
                other.gameObject.SetActive ( false ) ;
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
               // playSound(collectSlotSoundEffect);
                other.gameObject.SetActive(false);
                img1.gameObject.SetActive(false);
                SetSlot1Text();
                updateDiaryCheckpoint(1);
                break;
            
            //if player collects second slot diary entry
            case "Slot2":
               // playSound(collectSlotSoundEffect);
                other.gameObject.SetActive(false);
                img2.gameObject.SetActive(false);
                SetSlot2Text();
                updateDiaryCheckpoint(2);
                break;
            
            //if player collects third slot diary entry
            case "Slot3":
               // playSound(collectSlotSoundEffect);
                other.gameObject.SetActive(false);
                img3.gameObject.SetActive(false);
                SetSlot3Text();
                updateDiaryCheckpoint(3);
                break;

            //if player collects forth slot diary entry
            case "Slot4":
                // playSound(collectSlotSoundEffect);
                other.gameObject.SetActive(false);
                img4.gameObject.SetActive(false);
                SetSlot4Text();
                updateDiaryCheckpoint(4);
                break;
            
            //if player enters the trigger box for the keycode input
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
                Clear.SetActive(true);
                break;

            default:
                break;
        }
    }

    // remove GUI for code input when outside the box
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
                Clear.SetActive(false);
                InputSoFar.SetActive(false);
                ResumeTime();
                break;

            default:
                break;

        }

    }

    private void ResumeTime() {
          Time.timeScale = 1f;
     }

    private void PauseTime() {
          Time.timeScale = 0f;
     }

    private void updateDiaryCheckpoint(int diary) {

        string s = "0 0 0 0";
        if (PlayerPrefs.HasKey("diaries")) {
            s = PlayerPrefs.GetString("diaries");
        } 

        // diary 1 -> update 0 index
        // diary 2 -> update 2 index
        // diary 3 -> update 4 index
        // diary 4 -> update 6 index

        int index = (diary - 1) * 2;
        s = s.Remove(index,index+1);
        s = s.Insert(index,"1");

        PlayerPrefs.SetString("diaries", s);
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
        Slot1Text.text = "Log 1; 27/4/2043    Finally landed on our new home - been awake now for around 3 hours - cryosleep really does a number on your knees! Still, better than spending 3 years sitting around on a cramped ship. I can't believe we are finally here. The planet is beautiful - full of grass and trees (Real trees! I havn't seen those since I was just a kid!). The island we are one is big enough for our plans, and we still have the terraaformer if we need to expand, and the new state-of-the-art drones in orbit, ready to keep us happy and healthy no matter what! Guess it's time to go meet my new neighbours! .S";
    }
    private void SetSlot2Text(){
        Slot2Text.text = "Log 2; 17/5/2043  All going well. Been getting along with the rest of the settelers well - V and I have struck up a friendship, and there havn't been any big fights. Only event of not was K breaking her leg, but we have a doctor and some medical supplies, and we have sent for a medical drone to come down from orbit to help. Should be here in the next couple of days.  .S";
    }

    private void SetSlot3Text(){
        Slot3Text.text = "Log 3; 23/5/2043   We haven't heard from K for the last 3 days. She was doing well, seemed to be in good spirits, but when the drone came down it insisted we lock her into the old storage cupboard on the little island in the North, and told us they were not to be disturbed. There isn't any food or water in there, and neither of them have come out. We havn't heard anything. I'm beginning to worry.  .S ";

    }

    private void SetSlot4Text(){
        Slot4Text.text = "Log 4; 28/5/2043 K is dead. The medical drone finally came out and told us. It won't say how, and it won't let the doctor, P, in to check the body. She was absolutely fine, and a broken leg is basically nothing to the meds even we have in the med kit. I don't trust the drones. I need to find out whats in the storage shed, what the drones are up to. I know the control center for them is in there. I found the code - its 9427. That should let me in. Wish me luck. If anyone finds these logs, it means I failed. Please - destroy the drones before they can do any more harm. ";
    }

}
