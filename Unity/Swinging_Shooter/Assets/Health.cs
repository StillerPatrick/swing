using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {

    public Slider slider;
    public GameObject player;
    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        Hook hook = player.GetComponent<Hook>();
        if (Input.GetKeyDown(KeyCode.H))
        {
            hook.health -= 1;
        }
        slider.value = hook.health;
    }
}
