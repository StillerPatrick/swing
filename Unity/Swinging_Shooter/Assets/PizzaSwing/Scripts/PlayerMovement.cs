using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {


    //=======================================================================
    //=                             Variables                               =
    //=======================================================================

    // ------------------------- public ------------------------- 
    public float SpeedLimit;

    // ------------------------- private ------------------------- 
    private Rigidbody2D _playersRigidbody2D;

    // ############################################################################################################################################
    // #                                                                                                                                          #
    // #                                                               Start                                                                      #
    // #                                                                                                                                          #
    // ############################################################################################################################################
    // Use this for initialization, Order: Awake, Start, Update, LateUpdate
    void Start () 
    {
        _playersRigidbody2D = transform.GetComponent<Rigidbody2D>();

        if (SpeedLimit <= 0)
        {

            SpeedLimit = 10;
        }
    }


    // ############################################################################################################################################
    // #                                                                                                                                          #
    // #                                                               Fixed Update                                                               #
    // #                                                                                                                                          #
    // ############################################################################################################################################
    private void FixedUpdate()
    {
        LimitSpeed();
    }


    private void LimitSpeed()
    {
        // get rigidbody velocity
        float objectVelocity = Mathf.Abs(_playersRigidbody2D.velocity.magnitude);

        // get velocity vector (inlcuding the direction)
        Vector2 objectVelocityVector2 = _playersRigidbody2D.velocity;

        Debug.Log("");

        // limit velocity
        if (SpeedLimit >= objectVelocity)
        {
            // normalize velocity vector and multiply with speed
            _playersRigidbody2D.velocity = objectVelocityVector2.normalized * SpeedLimit;

            Debug.Log("player rb velocity = " + _playersRigidbody2D.velocity); 
        }



       //Debug.Log("object velocity = " + _playersRigidbody2D.velocity.magnitude);
    }

}
