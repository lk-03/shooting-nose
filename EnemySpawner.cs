using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private float minTime;
    [SerializeField] private float maxTime;
    [SerializeField] private float timeUntilSpawn;


    // Start is called before the first frame update
    void Start()
    {
        settimeuntilspawn();
    }

    // Update is called once per frame
    void Update()
    {
        timeUntilSpawn -= Time.deltaTime;
        if (timeUntilSpawn<=0){
            Instantiate(enemy, transform.position, Quaternion.identity);
            settimeuntilspawn();
        }
        
    }

void settimeuntilspawn(){
    timeUntilSpawn= Random.Range(minTime,maxTime);
}

}
