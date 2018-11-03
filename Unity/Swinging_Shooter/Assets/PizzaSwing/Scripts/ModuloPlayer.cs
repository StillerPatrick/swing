using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuloObject : MonoBehaviour {

    // set borders 
    private float maximum_x = 20f;
    private float maximum_y = 11.25f;
    private float minimum_x = -20f;
    private float minimum_y = -11.25f;


    // Update is called once per frame
    void FixedUpdate () {
        Vector2 pos = transform.position;


        // check if its out of level and clip it to the other side


        if(pos.x > maximum_x){
            transform.position = new Vector2(minimum_x, pos.y);
        }

        if (pos.x < minimum_x)
        {
            transform.position = new Vector2(maximum_x, pos.y);
        }

        if (pos.y > maximum_y)
        {
            transform.position = new Vector2(pos.x, minimum_y);
        }

        if (pos.y < minimum_y)
        {
            transform.position = new Vector2(pos.x, maximum_y);
        }


    }
}
