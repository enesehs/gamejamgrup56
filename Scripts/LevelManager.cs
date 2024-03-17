using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private int id;

    private void OnTriggerEnter(Collider other){
        
            SceneManager.LoadScene(id);
       
        
    }
}
