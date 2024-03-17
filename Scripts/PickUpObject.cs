using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour
{

    public GameObject Weapon;
    public Transform PickUp;
    public bool CanAttack = false;
    public float AttackCoolDwon = 1.0f;
    [SerializeField]public Spider enemey;

   
    void Start()
    {
        Weapon.GetComponent<Rigidbody>().isKinematic = true;
        CanAttack = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Q))
        {
            if (CanAttack == true)
            {
                Drop();
                CanAttack = false;
            }
           
        }
        if(Input.GetMouseButtonDown(0))
        {
            if (CanAttack == true)
            {
                Attack();

            }

        }

    }

    void Attack()
    {
        Debug.Log("Vurma");
        enemey.health -= 20;
    }


    void Drop()
    {

        PickUp.DetachChildren();
        Weapon.transform.eulerAngles = new Vector3(Weapon.transform.position.x, Weapon.transform.position.z, Weapon.transform.position.y);
        
        Weapon.GetComponent<MeshCollider>().enabled = true;
        Weapon.GetComponent<Rigidbody>().isKinematic = false;
    }
    void Equip()
    {
        Weapon.GetComponent<Rigidbody>().isKinematic = true;

        Weapon.transform.position = PickUp.transform.position;
        Weapon.transform.rotation = PickUp.transform.rotation;

        Weapon.GetComponent<MeshCollider>().enabled = false;


        Weapon.transform.SetParent(PickUp);
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if (Input.GetKey(KeyCode.E))
            {
                CanAttack = true;
                Equip();
                Debug.Log("Alındı");
            }
        }
    }
}
