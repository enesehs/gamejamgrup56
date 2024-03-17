using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrandMother : MonoBehaviour
{
    public GameObject GMother;
    public Transform PickUp;
    public bool Talk = true;
    public int speak = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        GMother.GetComponent<Rigidbody>().isKinematic = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            Drop();
        }
    }

    void Drop()
    {
        Talk = true;
        PickUp.DetachChildren();
        var position = GMother.transform.position;
        position = new Vector3(position.x, position.z, position.y);
        GMother.transform.position = position;
        GMother.transform.rotation = new Quaternion(0, 0, 0, 0);
        GMother.GetComponent<MeshCollider>().enabled = true;
        GMother.GetComponent<Rigidbody>().isKinematic = false;
    }

    void Equip()
    {
        Talk = false;
        GMother.GetComponent<Rigidbody>().isKinematic = true;

        GMother.transform.position = PickUp.transform.position;
        GMother.transform.rotation = PickUp.transform.rotation;

        GMother.GetComponent<MeshCollider>().enabled = false;


        GMother.transform.SetParent(PickUp);
        Debug.Log("Guzummmm Kaldırımın karşısına bırak");

    }
    void Talking() {
        if (speak == 0)
        {
            Debug.Log("Yavrum karşıya geçemiyorum beni sırtlar mısın?");
            speak += 1;
        }
        if (speak == 1)
        {
            Debug.Log("Benden mi ürküyün guzummm :) ");
            speak += 1;
            Talk = false;
        }
        if (speak == 2)
        {
            Debug.Log("Allah razı olsun guzum ne muradın varsa gör. Yiğidim Kahramanım benim iyiki anan doğurmuş seni :D");
            speak += 1;
            Talk = true;
        }
        if(speak >= 3)
        {
            Debug.Log("Yeni Nesilde Çok inatçı Yaw Çık git");
            speak += 1;
        }

    }
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if (Input.GetKey(KeyCode.E))
            {
                Equip();
            }
        }
    }

}
