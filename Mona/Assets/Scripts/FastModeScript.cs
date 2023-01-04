using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FastModeScript : MonoBehaviour
{

    [SerializeField] private Toggle toggle;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("speed") && PlayerPrefs.GetInt("speed") == 1000) {
            toggle.isOn = true;
        } 

        toggle.onValueChanged.AddListener(val => {
            if (toggle.isOn) {
                PlayerPrefs.SetInt("speed", 1000);
            } else {
                PlayerPrefs.SetInt("speed", 500);
            }
        });
    }

    
}
