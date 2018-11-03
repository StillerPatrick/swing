﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileTrigger : MonoBehaviour {





    // ############################################################################################################################################
    // #                                                                                                                                          #
    // #                                                         Pre defined Functions                                                            #
    // #                                                                                                                                          #
    // ############################################################################################################################################



    //=======================================================================
    //=                         On Trigger Enter (Event)                    =
    //=======================================================================
    void OnTriggerEnter2D(Collider2D col)
    {
        // destroy item if they felt in water
        if (col.CompareTag("LevelBorder"))
        {
            //Debug.Log("projectile " + name + "hit level border");

            // projectile destroys its self if it hits a level border
            Destroy(gameObject);
        }


    }
}
