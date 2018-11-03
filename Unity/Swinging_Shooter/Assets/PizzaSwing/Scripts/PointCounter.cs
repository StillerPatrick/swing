using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointCounter : MonoBehaviour {
    private int pizza_count;
    private int boy_count;

    public
	// Use this for initialization
	void Start () {
        pizza_count = 0;
        boy_count = 0;
}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(KeyCode.U))
        {
            pizza_count += 1;
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            boy_count += 1;
        }


    }
}
