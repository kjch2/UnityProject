using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileImpact : MonoBehaviour
{

    //method for when collided
    void OnCollisionEnter(Collision impact)
    {
        //if collided with object with tag "Ball" then
        if (impact.gameObject.tag == "Ball")
        {
            //destroy this game object
            Destroy(gameObject);
        }
    }

}
