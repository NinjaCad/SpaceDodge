using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float speed;
    private Vector2 input;
    [SerializeField] private LayerMask borders;
    [SerializeField] private BoxCollider2D boxCollider2d;
    private RaycastHit2D raycastHit2d;
    private Vector2 targetMovePosition;

    // Start is called before the first frame update
    void Start()
    {
        speed = 50;
        //starting position
        transform.position = new Vector2(-30, 0);
        //Get box collider
        boxCollider2d = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Get input for vertical which is y-axis
        input = new Vector3(0, Input.GetAxisRaw("Vertical")).normalized;
        //set new position on map
        //Check if wall
        raycastHit2d = Physics2D.Raycast(transform.position, input, speed * Time.deltaTime + 2, borders);
        
        if (raycastHit2d.collider == null) {
            //Can move no hit
            transform.position = new Vector2(transform.position.x, transform.position.y + input.y * speed * Time.deltaTime);
        }
    }
}