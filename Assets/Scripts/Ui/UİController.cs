using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.UI;

public class UİController : MonoBehaviour
{

    public static UİController instance;

    
    public TextMeshProUGUI bestScoreText;
    public TextMeshProUGUI scoreText;
    public  TextMeshProUGUI coinText;
    public TextMeshProUGUI TotalCoinText;
    public TextMeshProUGUI currentCoinText;
    public TextMeshProUGUI doubleJumpTimer;
    public static int coin = 0;
    public int currentCoin;
    public int GameOverPanelCoin = 0;
    int distance;

    public static int MainMenuScore;
    public static int score;


    private void Awake()
    {
        //MainMenuScore = PlayerPrefs.GetInt("Coin");

        PlayerPrefs.Save();

        instance = this;
    }

    void Start()
    {

        coin = PlayerPrefs.GetInt("Coin");


        MainMenuScore = PlayerPrefs.GetInt("Coin");
        //PlayerPrefs.Save();

        currentCoin = 0;

        TotalCoinText.text = PlayerPrefs.GetInt("Total" , 0 ).ToString() + " Total";

        bestScoreText.text = PlayerPrefs.GetInt("bestScore", 0).ToString()  + "m";

        doubleJumpTimer.text = PlayerPrefs.GetInt("doubleJumpTimer").ToString();


        UpdateHighScore();

    }
    void Update()
    {


        if (PlayerManager.instance.coinTouched == true)
        {
            coin += 1000;
            currentCoin += 1000;
            CoinUpdate();
            PlayerManager.instance.coinTouched = false;

        }

        TotalCoinText.text = coinText.text ;

        currentCoinText.text = currentCoin.ToString();
        

        

        scoreText.text = Mathf.Floor(PlayerManager.instance.distance).ToString() + "m";// score güncelleme

        doubleJumpTimer.text = MathF.Floor(PlayerManager.doubleJumpCounter).ToString();

        distance = Convert.ToInt32(PlayerManager.instance.distance);

        UpdateHighScore();

        coinText.text =  coin.ToString() ;
        currentCoinText.text =  "+" + currentCoin.ToString() ;

    }


    private void UpdateHighScore()
    {

        if(distance > PlayerPrefs.GetInt("bestScore"))
        {
            PlayerPrefs.SetInt("bestScore" , distance   );
            bestScoreText.text = distance.ToString() + "m";
            score = PlayerPrefs.GetInt("bestScore");
        }

    }

    public void CoinUpdate()
    {
        PlayerPrefs.SetInt("Coin" , coin);// coin güncelleme

        coin = PlayerPrefs.GetInt("Coin");

        MainMenuScore = PlayerPrefs.GetInt("Coin");

        PlayerPrefs.Save();

    }






}
