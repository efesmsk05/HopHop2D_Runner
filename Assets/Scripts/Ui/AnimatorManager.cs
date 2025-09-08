using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorManager : MonoBehaviour
{

    public Animator _Animator;

    private void Awake()
    {
        _Animator = GetComponent<Animator>();
    }
    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            _Animator.SetBool("isJumping" , true);
        }

        if(Input.GetKeyUp(KeyCode.Mouse0) )
        {
            _Animator.SetBool("isJumping", false);

        }

        //if (PlayerManager.instance.isTriggered == true)
        //{
        //    _Animator.SetBool("hit", true);

        //}
        //if(PlayerManager.instance.isTriggered == false)
        //{
        //    _Animator.SetBool("hit", false);

        //}
    }


}
