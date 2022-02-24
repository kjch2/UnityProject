using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    //references to camera, projectile object and throw point
    public Camera cam;
    public GameObject projectile;
    public Transform throwPoint;

    //set projectile velocity and store destination
    public float projectileVelocity = 10.0f;
    private Vector3 destination;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //check if mouse is pressed then call throw method
        if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                ThrowBall();
            }
    }

    //method for moving projectile outwards towards centre screen
    void ThrowBall()
    {
        //project a ray towards the middle of the screen from main camera
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        //set bool for ray hit object or not
        bool hitCheck = Physics.Raycast(ray, out hit);
        //if projected ray hits anything then set destination
        if (hitCheck)
        {
            destination = hit.point;
        }
        //if not set destination far away 
        else
        {
            destination = ray.GetPoint(50);
        }
        //then throw projectile 
        InstatiateProjectile(throwPoint);
    }

    //method to create projectile
    void InstatiateProjectile(Transform x)
    {
        //initiate the object into the game and use destination and throwpoint to project object at set velocity
        var projectileObject = Instantiate(projectile, throwPoint.position, Quaternion.identity) as GameObject;
        projectileObject.GetComponent<Rigidbody>().velocity = (destination - throwPoint.position).normalized * projectileVelocity;
    }
}
