using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour
{
   public float speed;
   private Transform target;
   private Vector2 spawnPoint;
   private Vector2 playerpos;


   private void Start() {

        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        

   }

   private void Update() {     

    //Follow
    transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    Invoke(nameof(Destroy),25f);
   }


   
    public void Destroy(){

        Destroy(gameObject);

    }


}
