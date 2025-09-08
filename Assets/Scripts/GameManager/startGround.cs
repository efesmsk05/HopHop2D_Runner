using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startGround : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;   

        transform.Translate(-(transform.position.x + 1f) * Time.deltaTime , transform.position.y , transform.position.z);
        pos.x -= (PlayerManager.instance.accelerationXvelocity.x / 6f) * Time.deltaTime; 
        Destroy(gameObject,10f);

        transform.position = pos;   
        
    }
}
