using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParalaxController : MonoBehaviour
{
    Vector2 movementpos;
    public GameObject RandomYObject;

    public float depth= 2f;

    public float startLimit = 10f;
    public float lastLimit = -10;



    void Start()
    {
        
    }

    void FixedUpdate()
                
    {
        float realVelocity =( PlayerManager.instance.accelerationXvelocity.x / 4f)/ depth;

        Vector2 movementpos = transform.position;
        movementpos.x -= realVelocity * Time.fixedDeltaTime;// sola doðru sürekli hýzlanan bir haraket yaptýrýyoruz

        if (movementpos.x <= lastLimit)
        {
            movementpos.x = startLimit;

        }
        
        transform.position = movementpos;



       
    }


}
