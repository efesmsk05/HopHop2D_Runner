using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiAnimator : MonoBehaviour
{
    // Start is called before the first frame update
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {



    }

    public void On()
    {
        animator.SetTrigger("Open");
    }
    public void Close()
    {
        animator.SetTrigger("Close");

    }


}
