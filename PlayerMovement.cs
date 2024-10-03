using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody2D rb;
    public int speed;
    Vector2 movement;

     private bool canDash = true;
    private bool isDashing;
    [SerializeField] private float dashingPower = 24f;
    private float dashingTime = 0.15f;
    private float dashingCooldown = 1f;
    [SerializeField] private TrailRenderer tr;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Input into Vector
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        //PLayer Rotation 
        Vector2 mousepos = Input.mousePosition;
        mousepos = Camera.main.ScreenToWorldPoint(mousepos);
        Vector2 direction = new Vector2(mousepos.x-transform.position.x, mousepos.y - transform.position.y);
        transform.up = direction;

        
    }

    private void FixedUpdate() {
        //Moevment
        rb.MovePosition(rb.position+movement.normalized*speed*Time.fixedDeltaTime);
        // Tried Something Didnt work
        // rb.velocity = movement.Normalize()*speed*Time.deltaTime;
        
        
        //Dash
         if (Input.GetKeyDown(KeyCode.Space) && canDash)
        {
            StartCoroutine(Dash());
        }
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        rb.velocity = new Vector2( movement.x*dashingPower, movement.y*dashingPower);
        // rb.MovePosition(rb.position+movement.normalized*dashingPower*Time.fixedDeltaTime);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }

}
