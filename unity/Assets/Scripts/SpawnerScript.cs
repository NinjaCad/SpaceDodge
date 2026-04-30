using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public GameObject normalEnemy;
    public GameObject fastEnemy;
    public GameObject bigEnemy;
    public GameObject player;
    public GameObject baren;
    public GameObject ice;
    public GameObject lava;
    public GameObject terran;
    Vector2 position;
    public float spawnRate;
    private float spawnTimer;
    private float spawnRateTimerCount;
    private float planetTimer;
    private float dice;

    // Start is called before the first frame update
    void Start()
    {
        spawnRate = 1;
    }

    // Update is called once per frame
    void Update()
    {
        spawner();
        enemys();
        planets();

    }

    private void spawner() {
        //Spawn rate increases as you play
        if (spawnRateTimerCount > 0) {
            spawnRateTimerCount -= Time.deltaTime;
        }
        if (spawnRateTimerCount <= 0) {
            spawnRate = spawnRate * 0.99f;
            spawnRateTimerCount = 1;
        }
    }

    private void enemys() {
        //timer
        if (spawnTimer > 0) {
            spawnTimer -= Time.deltaTime;
        }
        //what is does after timer
        if (spawnTimer <= 0) {
            //set a position
            if (Random.Range(1, 6) == 1) {
                position = new Vector2 (50, player.transform.position.y);
            } else {
                position = new Vector2(50, Random.Range(-22, 22));
            }
            
            //spawn clone
            dice = Random.Range(1, 11);
            if (dice == 1) {
                Instantiate(fastEnemy, position, Quaternion.identity);
            } else if (dice == 2) {
                Instantiate(bigEnemy, position, Quaternion.identity);
            } else {
                Instantiate(normalEnemy, position, Quaternion.identity);
            }
            //timer reset
            spawnTimer = spawnRate;
        }
    }

    private void planets() {
        if (planetTimer > 0) {
            planetTimer -= Time.deltaTime;
        }

        //Planets get spawned
        if (planetTimer <= 0) {
            position = new Vector2 (50, Random.Range(-22, 22));
            dice = Random.Range(1, 5);
            if (dice == 1) {
                Instantiate(baren, position, Quaternion.identity);
            }
            else if (dice == 2) {
                Instantiate(ice, position, Quaternion.identity);
            }
            else if (dice == 3) {
                Instantiate(lava, position, Quaternion.identity);
            }
            else if (dice == 4) {
                Instantiate(terran, position, Quaternion.identity);
            }
            
            planetTimer = Random.Range(15, 20);
        }
    }
}