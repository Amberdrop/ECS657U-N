using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class CodeInput : MonoBehaviour
{
    public Button Button1, Button2, Button3, Button4, Button5, Button6, Button7, Button8, Button9, Enter;
    public TextMeshProUGUI InputSoFar;
    public GameObject Doorway;
    public string inputSF;

    void Start()
    {
        Button1.onClick.AddListener(butt1);
        Button2.onClick.AddListener(butt2);
        Button3.onClick.AddListener(butt3);
        Button4.onClick.AddListener(butt4);
        Button5.onClick.AddListener(butt5);
        Button6.onClick.AddListener(butt6);
        Button7.onClick.AddListener(butt7);
        Button8.onClick.AddListener(butt8);
        Button9.onClick.AddListener(butt9);
        Enter.onClick.AddListener(buttEnter);
    }

    

    void butt1()
    {
        inputSF += "1";
        updateText();
    }

    void butt2()
    {
        inputSF += "2";
        updateText();
    }

    void butt3()
    {
        inputSF += "3";
        updateText();
    }

    void butt4()
    {
        inputSF += "4";
        updateText();
    }

    void butt5()
    {
        inputSF += "5";
        updateText();
    }
    void butt6()
    {
        inputSF += "6";
        updateText();
    }
    void butt7()
    {
        inputSF += "7";
        updateText();
    }
    void butt8()
    {
        inputSF += "8";
        updateText();
    }
    void butt9()
    {
        inputSF += "9";
        updateText();
    }

    void buttEnter()
    {
        if (inputSF == "9427")
        {
            inputSF = "correct";
            Doorway.SetActive(false);

        }
        else
        {
            inputSF = "";
        }
        updateText();
    }

    void updateText()
    {
        InputSoFar.text = inputSF;
    } 

    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {
        
    }
}
