using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PointCounter : MonoBehaviour {
    private int pizza_count;
    private int boy_count;

    public Text PizzaPoints;
    public Text BoyPoints;


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
            PizzaPoints.text = pizza_count.ToString();
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            boy_count += 1;
            BoyPoints.text = boy_count.ToString();
        }

    



    }
}
