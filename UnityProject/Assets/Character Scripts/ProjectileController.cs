using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    private bool collision;

    //method for collision instance
    void OnCollisionEnter(Collision impact)
    {
        //check for collision with anything other than player and not already in collision
        if (impact.gameObject.tag != "Player" && !collision)
        {
            //set collision to true and destroy projectile
            collision = true;
            Destroy (gameObject);
        }
    }
}
