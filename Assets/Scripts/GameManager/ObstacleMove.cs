using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMove : MonoBehaviour
{
    public static ObstacleMove instance;




    void Start()
    {

        instance = this;


    }

    void Update()
    {


        Vector2 pos = transform.position;
        pos.x -= (PlayerManager.instance.accelerationXvelocity.x / 6f) * Time.deltaTime;

        transform.position = pos;

        Destroy(gameObject , 10f);


    }

    private void RayCast()
    {

        Debug.DrawRay(transform.position , transform.TransformDirection(Vector2.right) * 2f , Color.red);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right , 2f);

        if(hit)
        {
            if(hit.collider.tag == "deneme")
            {
                Debug.Log("deydi = " + hit.collider.tag);

            }

        }

    }


}
