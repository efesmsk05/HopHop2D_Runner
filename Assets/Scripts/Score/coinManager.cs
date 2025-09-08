using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        Vector2 pos = transform.position;
        pos.x -= (PlayerManager.instance.accelerationXvelocity.x / 6f) * Time.deltaTime;

        transform.position = pos;

    }
}
