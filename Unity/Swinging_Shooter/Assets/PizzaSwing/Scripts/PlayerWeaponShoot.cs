using System.Collections;using System.Collections.Generic;using UnityEngine;public class PlayerWeaponShoot : MonoBehaviour{    //=======================================================================    //=                             Variables                               =    //=======================================================================    // ------------------------- public -------------------------     [Header("Crosshair")]    public SpriteRenderer Crosshair;    [Header("Projectile")]    public GameObject SampleProjectile;    public GameObject ProjectileBucket;    public GameObject ProjectileSpawn;    public GameObject player;    //public GameObject TestProjectile;    public Sprite[] ProjectileSprites = new Sprite[3];    public float ImpulseForce;    //public float XOffsetProjectileSpawn;    // ------------------------- private -------------------------     private Vector2 _aimDirection;    private Vector3 _stickInputControllerOne;    private Vector3 _stickInputControllerTwo;    private Quaternion _aimRotation;    // ############################################################################################################################################    // #                                                                                                                                          #    // #                                                               Start                                                                      #    // #                                                                                                                                          #    // ############################################################################################################################################    // Use this for initialization, Order: Awake, Start, Update, LateUpdate    void Start()    {        if(ImpulseForce <= 0)        {            ImpulseForce = 15;        }        SampleProjectile.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;        //Debug.Log("1. joystick = " + Input.GetJoystickNames()[0]);        //Debug.Log(Input.GetJoystickNames()[0]);    }    // ############################################################################################################################################    // #                                                                                                                                          #    // #                                                              Update                                                                      #    // #                                                                                                                                          #    // ############################################################################################################################################    // Update is called before rendering a frame    // interval times vary    // for: moving non-physics objects, simple timers, receiving input, ...    void Update()    {        _stickInputControllerOne = new Vector3(Input.GetAxisRaw("Controller1_X1"), -Input.GetAxisRaw("Controller1_Y1"), 0);        //CrosshairsFollowMouse();        CrosshairFollowStick();        // shoot on button press        if (Input.GetButtonDown("Controller1_Shoot"))        {            Debug.Log("shoot");           ShootWeapon();

        }    }


    // ############################################################################################################################################
    // #                                                                                                                                          #
    // #                                                            Costum Functions                                                              #
    // #                                                                                                                                          #
    // ############################################################################################################################################

    //=======================================================================
    //=                            Shoot (Weapon)                           =
    //=======================================================================
    private void ShootWeapon()    {        var newObject = Instantiate(SampleProjectile, ProjectileSpawn.transform.position, _aimRotation, ProjectileBucket.transform);

        // activate projectile game object
        newObject.SetActive(true);


        // random int max is exclusive [min] (max) e.g range 0,3 --> outputs 0, 1, 2
        int randomNumber = UnityEngine.Random.Range(0, ProjectileSprites.Length);

        //Debug.Log("randNum = " + randomNumber);
        // set projectile sprite
        newObject.GetComponent<SpriteRenderer>().sprite = ProjectileSprites[randomNumber];

        // change rigidbody type 
        newObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

        newObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * ImpulseForce, ForceMode2D.Impulse);    }


    //=======================================================================
    //=                       Crosshairs Follow Stick                       =
    //=======================================================================
    private void CrosshairFollowStick()    {        // controller 1        var controller1Direction = _stickInputControllerOne;        _aimDirection = controller1Direction;        float angle = Mathf.Atan2(_aimDirection.y, _aimDirection.x) * Mathf.Rad2Deg;        _aimRotation = Quaternion.AngleAxis(angle, Vector3.forward);        //         if (Mathf.Abs(_stickInputControllerOne.magnitude) >= 0.2f)        {            transform.rotation = _aimRotation;            player.transform.rotation = _aimRotation;        }    }    //=======================================================================    //=                       Crosshairs Follow Mouse                       =    //=======================================================================    private void CrosshairsFollowMouse()    {        _aimDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;        float angle = Mathf.Atan2(_aimDirection.y, _aimDirection.x) * Mathf.Rad2Deg;        _aimRotation = Quaternion.AngleAxis(angle, Vector3.forward);        transform.rotation = _aimRotation;    }    //=======================================================================    //=                       Angle Between Two Points                      =    //=======================================================================    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)    {        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;    }}