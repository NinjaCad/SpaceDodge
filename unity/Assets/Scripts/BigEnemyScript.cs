using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class BigEnemyScript : MonoBehaviour
{
    [SerializeField] private LayerMask player;
    [SerializeField] private BoxCollider2D boxCollider2d;
    RaycastHit2D raycastHit2d;
    
    public float speed;
    private int go;
    public float spawnTimer;
    private float speedTimerCount;

    // Start is called before the first frame update
    void Start()
    {
        speed = 2.5f;
        go = 1;
        spawnTimer = 0.75f;
        boxCollider2d = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //go forwards
        if (go == 1) {
            transform.position = new Vector2(transform.position.x - 10 * Time.deltaTime, transform.position.y);
        }
        //go = 2
        if (transform.position.x < 38 && go == 1) {
            go = 2;
        }
        //stop for 1 second
        if (go == 2) {
            if (spawnTimer > 0 ) {
                spawnTimer -= Time.deltaTime;
            }
            //go again
            if (spawnTimer <= 0) {
                go = 3;
            }
        }
        //go forwards
        if (go == 3) {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        }

        //timer
        if (speedTimerCount > 0) {
            speedTimerCount -= Time.deltaTime;
        }
        //speed increases per the timer
        if (speedTimerCount <= 0) {
            speed = speed * 1.1f;
            speedTimerCount = 0.1f;
        }

        //reset game
        if (isTouching()) {
            SceneManager.LoadScene("GameScene");
        }

        //Self destruct if out of screen
        if (transform.position.x <= -50) {
            ScoreTextScript.scoreValue += 1;
            Destroy(GameObject.Find("BigEnemyPrefab(Clone)"), 0);
        }

        //sets the layer to x position
        gameObject.GetComponent<SpriteRenderer> ().sortingOrder = (int)gameObject.transform.position.x + 100;
    }

    //if touching player
    private bool isTouching() {
        raycastHit2d = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.left, 0.1f, player);
        return raycastHit2d.collider != null;
    }
}
