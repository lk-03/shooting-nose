using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevisedPlayerMovement : MonoBehaviour
{

    public float moveSpeed;
    public Rigidbody2D rb;
    private Vector2 moveInput;

    private float activeMoveSpeed;
    public float dashSpeed;
    public bool isDashing = false;
    public float dashLength = .25f, dashCooldown = 4f;

    float dashCounter;
    float dashCoolCounter;
    public TrailRenderer tr;


    //Spawning Enemy
    public int enemyCount = 0;
    Vector2 playerpos;
    Vector2 spawnPoint;
    public GameObject enemyCircle;

    // Start is called before the first frame update
    void Start()
    {
        activeMoveSpeed = moveSpeed;
        // enemyCircle = GameObject.FindGameObjectWithTag("Enemy");

    }

    // Update is called once per frame
    void Update()
    {
        //Movement

        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        moveInput.Normalize();

        rb.velocity = moveInput * activeMoveSpeed;

        //Rotation
         Vector2 mousepos = Input.mousePosition;
        mousepos = Camera.main.ScreenToWorldPoint(mousepos);
        Vector2 direction = new Vector2(mousepos.x-transform.position.x, mousepos.y - transform.position.y);
        transform.up = direction;

        // Dash
        Dash();
       
        
        

    }

    void Dash(){

         if (Input.GetKeyDown(KeyCode.Space)){
            if (dashCoolCounter <= 0 && dashCounter <=0){
                activeMoveSpeed = dashSpeed;
                dashCounter = dashLength;
                tr.emitting= true;
                isDashing = true;
            }

        }

        if (dashCounter >0){
            dashCounter -= Time.deltaTime;
            if (dashCounter <= dashLength/2){
                tr.emitting = false;
            }

            if(dashCounter <=0){
                isDashing = false;
                activeMoveSpeed= moveSpeed;
                dashCoolCounter = dashCooldown;
            }
        }

        if (dashCoolCounter >0){
            dashCoolCounter -= Time.deltaTime;
        }
        

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Enemy enemy = other.GetComponent<Enemy>();
        if (enemy!=null && isDashing){
            enemy.Destroy();
            
        }
        else if(enemy!=null && !isDashing){
            GameOver();
        }

    }



    public void GameOver(){
        
    }

   
}
