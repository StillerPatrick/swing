﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponShoot : MonoBehaviour
{

    //=======================================================================
    //=                             Variables                               =
    //=======================================================================

    // ------------------------- public ------------------------- 
    [Header("Crosshair")]
    public SpriteRenderer Crosshair;

    [Header("Projectile")]
    public GameObject SampleProjectile;
    public GameObject ProjectileBucket;
    public GameObject ProjectileSpawn;

    public Sprite[] ProjectileSprites = new Sprite[3];

    public float ImpuleForce;
    //public float XOffsetProjectileSpawn;


    // ------------------------- private ------------------------- 
    private Vector2 _aimDirection;
    private Quaternion _aimRotation;




    // ############################################################################################################################################
    // #                                                                                                                                          #
    // #                                                               Start                                                                      #
    // #                                                                                                                                          #
    // ############################################################################################################################################
    // Use this for initialization, Order: Awake, Start, Update, LateUpdate
    void Start()
    {

        SampleProjectile.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;

    }




    // ############################################################################################################################################
    // #                                                                                                                                          #
    // #                                                              Update                                                                      #
    // #                                                                                                                                          #
    // ############################################################################################################################################
    // Update is called before rendering a frame
    // interval times vary
    // for: moving non-physics objects, simple timers, receiving input, ...
    void Update()
    {

        CrosshairsFollowMouse();



        // shoot on button press
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("shoot");
            ShootWeapon();
        }


    }


    // ############################################################################################################################################
    // #                                                                                                                                          #
    // #                                                            Costum Functions                                                              #
    // #                                                                                                                                          #
    // ############################################################################################################################################


    //=======================================================================
    //=                            Shoot (Weapon)                           =
    //=======================================================================
    private void ShootWeapon()
    {
        var spawnPointVector3 = new Vector3(ProjectileSpawn.transform.position.x, ProjectileSpawn.transform.position.y, 1);
        var newProjectile = Instantiate(SampleProjectile, spawnPointVector3, SampleProjectile.transform.rotation, ProjectileBucket.transform);

        // rotate in shoot direction
        newProjectile.transform.rotation = _aimRotation;

        // random int max is exclusive [min] (max) e.g range 0,3 --> outputs 0, 1, 2
        int randomNumber = UnityEngine.Random.Range(0, ProjectileSprites.Length);

        Debug.Log("randNum = " + randomNumber);
        // set projectile sprite
        newProjectile.GetComponent<SpriteRenderer>().sprite = ProjectileSprites[randomNumber];

        // activate projectile game object
        newProjectile.SetActive(true);

        // change rigidbody type 
        newProjectile.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

        // add impuse force
        newProjectile.GetComponent<Rigidbody2D>().AddForce(_aimDirection.normalized * ImpuleForce, ForceMode2D.Impulse);
    }



    //=======================================================================
    //=                       Crosshairs Follow Mouse                       =
    //=======================================================================
    private void CrosshairsFollowMouse()
    {

        _aimDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        float angle = Mathf.Atan2(_aimDirection.y, _aimDirection.x) * Mathf.Rad2Deg;

        _aimRotation = Quaternion.AngleAxis(angle, Vector3.forward);

        transform.rotation = _aimRotation;
    }




    //=======================================================================
    //=                       Angle Between Two Points                      =
    //=======================================================================
    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}
