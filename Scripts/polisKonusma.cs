using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class polisKonusma : MonoBehaviour
{
    [SerializeField]public TMP_Text convText;
    [SerializeField]public TMP_Text infText;
    private String a;
    private bool girili = false;
    private int sayac=-1;
    private void OnTriggerEnter(Collider other)
    {
        girili = true;
        infText.text = "Polisle konuşmak için E tuşuna basın";
        
            
                
                
            
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
                    convText.text = "Player: Yollar Neden Kapalı?";
                    return;
                case 1:
                    convText.text = "Polis: Stadyumda maç olduğundan dolayı yolları kapattık.";
                    return;
                default:
                    infText.text = "Konuşma bitti";
                    convText.text = "";
                    return;
                       
            }

        }
    }
}
