using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetScript : MonoBehaviour
{
    private float size;
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(2, 5);
        size = Random.Range(10, 50);
        transform.localScale = new Vector2(size, size);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, 5);

        if (transform.position.x <= -50) {
            Destroy(gameObject, 0);
        }
    }
}
