using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Border : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Get the Information of the Ridgidbody to perform a raycast
        Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
        float width = other.transform.localScale.x;
        float height = other.transform.localScale.y;

        RaycastHit2D[] hits;
        hits = Physics2D.RaycastAll(transform.position, -rb.velocity);


        other.transform.position = hits[hits.Length - 1].point;

        rb.velocity = new Vector2(rb.velocity.x + 1f, rb.velocity.y);

    }
}
