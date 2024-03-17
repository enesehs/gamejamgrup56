using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RollingPinController : MonoBehaviour
{
    public Animator hittingAnim; // Hitting_Test.controller i�erisindeki animasyon

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Sol t�klama bas�ld���nda animasyonu �al��t�r
            hittingAnim.SetTrigger("Hit");
            Debug.Log("vurdu");
        }
        else
        {
            // Sol t�klama bas�lmad���nda animasyonu idle'da tut
            hittingAnim.SetTrigger("Idle");
        }
    }
}
