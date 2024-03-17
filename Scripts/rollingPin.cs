using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RollingPinController : MonoBehaviour
{
    public Animator hittingAnim; // Hitting_Test.controller içerisindeki animasyon

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Sol týklama basýldýðýnda animasyonu çalýþtýr
            hittingAnim.SetTrigger("Hit");
            Debug.Log("vurdu");
        }
        else
        {
            // Sol týklama basýlmadýðýnda animasyonu idle'da tut
            hittingAnim.SetTrigger("Idle");
        }
    }
}
