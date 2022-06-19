using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private Vector3 moveDelta;//keep track of the delta moovement[players current position]
    private RaycastHit2D hit; //can we go there (throught the wall? Now we can't :D)
    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }
    private void FixedUpdate()
    { //following the same frames as the physics
        
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        //reset Move Delta
        moveDelta = new Vector3(x,y,0);
        // Swap sprite direction, Aka right or left
        if (moveDelta.x > 0)//Above 0
        {
            transform.localScale = Vector3.one;
        }
        else if (moveDelta.x < 0)//Bellow 0
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        // Make sure we can move in this place, by casting a box there, if the box returns null we can move
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Character", "Blocking"));
        if (hit.collider == null) {
            //Make the viking dance in your screen
            transform.Translate(0, moveDelta.y * Time.deltaTime, 0);
        }

        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(moveDelta.x,0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Character", "Blocking"));
        if (hit.collider == null)
        {
            //Make the viking dance in your screen
            transform.Translate(moveDelta.x * Time.deltaTime, 0, 0);
        }

    }
}
 