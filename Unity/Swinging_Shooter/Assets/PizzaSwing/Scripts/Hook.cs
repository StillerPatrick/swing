using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour {

    int accelerator;
    private int maxVelocity = 70;
    private int acceleration = 25;
    private int rotationSpeed = 2;

    public Vector2 radialVector()
    {
        Vector2 objectPosition = gameObject.GetComponent<Rigidbody2D>().position;
        Vector2 anchorPosition = gameObject.GetComponent<DistanceJoint2D>().connectedBody.position;
        return  anchorPosition - objectPosition;

    }





public void rotatePlayer()
    {
    var horizontal = Input.GetAxis("horizontalPlayer1");
    var vertical = Input.GetAxis("verticalPlayer1");

        if (horizontal * horizontal + vertical * vertical > 0.1)
        {
            var angle = Mathf.Atan2(horizontal,vertical) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(new Vector3(0, 0, -angle)), Time.deltaTime * rotationSpeed);
        }
    }


    public void accelerateCounterclockwise()
    {

        if (Input.GetKey("j") && (gameObject.GetComponent<Rigidbody2D>().velocity.magnitude < maxVelocity))
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.Perpendicular(radialVector().normalized)*acceleration);
        }
    }

    public void accelerateClockwise()
    {
        if (Input.GetKey("l") && (gameObject.GetComponent<Rigidbody2D>().velocity.magnitude < maxVelocity))
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.Perpendicular(radialVector().normalized)*-acceleration);
        }
    }

    public void hookIn()
    {
        if (Input.GetKeyDown("i"))
        {
            accelerator = 0;
        }
        if (Input.GetKey("i"))
        {
            gameObject.GetComponent<DistanceJoint2D>().distance -= (float)0.01*(float)accelerator;
            if (accelerator < 20)
            {
                accelerator++;
            }
        }
    }
    
    public void hookOut()
    {
        if (Input.GetKeyDown("k"))
        {
            accelerator = 0;
        }
        if (Input.GetKey("k"))
        {
            gameObject.GetComponent<DistanceJoint2D>().distance += (float)0.01*(float)accelerator;
            if (accelerator < 20)
            {
                accelerator++;
            }
        }
    }

    public void setTarget()
    {
        if (!gameObject.GetComponent<DistanceJoint2D>().enabled && (Input.GetKey("space"))) {
            RaycastHit2D hit = Physics2D.Raycast(gameObject.GetComponent<Transform>().position, gameObject.GetComponent<Transform>().rotation*Vector2.right, 20.0f);
            if ((hit  && hit.rigidbody)) {
                gameObject.GetComponent<DistanceJoint2D>().connectedBody = hit.rigidbody;
                gameObject.GetComponent<DistanceJoint2D>().distance = (hit.rigidbody.position - gameObject.GetComponent<Rigidbody2D>().position).magnitude;
                gameObject.GetComponent<DistanceJoint2D>().enabled = true;
                gameObject.GetComponent<LineRenderer>().enabled = true;
            }
        }
    }

    public void letGo()
    {
        if (Input.GetKeyUp("space"))
        {
            gameObject.GetComponent<DistanceJoint2D>().enabled = false;
            gameObject.GetComponent<LineRenderer>().enabled = false;
        }
    }

    public void controllLoop()
    {
        if (gameObject.GetComponent<DistanceJoint2D>().enabled)
        {
            accelerateClockwise();
            accelerateCounterclockwise();
            hookIn();
            hookOut();
            letGo();
        }
        setTarget();
        rotatePlayer();
    }

	// Use this for initialization
	void Start () {
        LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.widthMultiplier = 0.2f;
	}

    // Update is called once per frame
    void Update()
    {
        controllLoop();
        if (gameObject.GetComponent<DistanceJoint2D>().enabled)
        {
            LineRenderer lineRenderer = GetComponent<LineRenderer>();
            lineRenderer.SetPosition(0, gameObject.GetComponent<Transform>().position);
            lineRenderer.SetPosition(1, gameObject.GetComponent<DistanceJoint2D>().connectedBody.position);
        }
    }
}
