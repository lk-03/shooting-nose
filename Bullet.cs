using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float  speed = 20f;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.up *speed * Time.deltaTime;
        
    }
    private void Update() {
        Invoke(nameof(Destroy), 5f);
    }
    private void OnTriggerEnter2D(Collider2D other) {
       Enemy enemy = other.GetComponent<Enemy>();
        if (enemy!=null){
            Destroy(other);
        }

        Destroy(gameObject);
    }

    void Destroy(){
        Destroy(gameObject);
    }
   
}
