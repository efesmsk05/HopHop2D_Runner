using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UiAnimation : MonoBehaviour
{
    public Transform Box;
    public CanvasGroup background_;


    private void Start()
    {
        //background_.alpha = 0;
        //background_.LeanAlpha(1, 0.5f);

        //Box.LeanMoveLocalY(0, 0.9f).setEaseOutExpo();
    }

    public void Up()
    {
        this.GetComponent<Canvas>().enabled = true;
        Box.LeanMoveLocalY(0, 0.9f).setEaseOutExpo();
    }

    //public void CloseDialog()
    //{
    //    background_.LeanAlpha(0f , .5f);

    //    Box.LeanMoveLocalY(-Screen.height, 0.9f).setEaseInExpo().setOnComplete(OnComplate);// set on complate iþlem tammalandýktan sonra yap anlamýna gelir

    //}

    //void OnComplate()
    //{
    //    gameObject.SetActive(false);

    //}










}
