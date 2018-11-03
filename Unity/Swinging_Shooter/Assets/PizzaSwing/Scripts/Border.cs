using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Border : MonoBehaviour {




    private void Start()
    {

    }


    private void OnTriggerEnter2D(Collider2D borderColliderObject)
    {
        // Get the Information of the Ridgidbody to perform a raycast
        Rigidbody2D rb = borderColliderObject.GetComponent<Rigidbody2D>();
        float width = borderColliderObject.transform.localScale.x;
        float height = borderColliderObject.transform.localScale.y;

        RaycastHit2D[] hits;
        hits = Physics2D.RaycastAll(transform.position, -rb.velocity);


        borderColliderObject.transform.position = hits[hits.Length - 1].point;



        //rb.velocity = new Vector2(rb.velocity.x + 1f, rb.velocity.y);

    }
}
