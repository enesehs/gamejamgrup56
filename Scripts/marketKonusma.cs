using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class marketKonusma : MonoBehaviour
{
    [SerializeField]public TMP_Text convText;
    [SerializeField]public TMP_Text infText;
    private bool girili = false;
    private int sayac=-1;
    private void OnTriggerEnter(Collider other)
    {
        girili = true;
        infText.text = "Kasiyerle konuşmak için E tuşuna basın";
        
            
                
                
            
        }

    private void OnTriggerExit(Collider other)
    {
        infText.text = "";
        convText.text = "";
        girili = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)&&girili==true)
        {
            sayac += 1;
            switch (sayac)
            { 
                case 0:
                    convText.text = "Player: Sirke, Karbonat ve Lavanta Yağı alabilir miyim??";
                    return;
                case 1:
                    convText.text = "Kasiyer: Tabi ki buyrun.";
                    return;
                default:
                    infText.text = "Eşyalar envantere eklendi. ";
                    infText.text += "Konuşma bitti";
                    convText.text = "";
                    return;
                       
            }

        }
    }
}
