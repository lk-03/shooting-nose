using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public Transform firepoint;
    public GameObject bullet; 

       void Update()
    {

        if (Input.GetButton("Fire1")){
            Shooting(); 
        }
        
    }

    void Shooting(){
        Instantiate(bullet, firepoint.position, firepoint.rotation);

    }

}
