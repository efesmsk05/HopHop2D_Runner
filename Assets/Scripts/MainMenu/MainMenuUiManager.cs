using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class MainMenuUiManager : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("PriceState")]
    public GameObject[] prices;

    public GameObject[] use;

    public Button[] buyButtons;

    public Button[] useButtons;

    public TextMeshProUGUI totalCarrot;
    public TextMeshProUGUI scoreText;

    [Header("Abilites")]
    // Double Jump
    public Button doubleJumpBuyButton;
    public GameObject abilitesUpgradePanel;
    public GameObject requiresPanel;
    public GameObject buyDoubleJumpPrice;

    public bool abilitesDoubleJump = false;
    public Button[] levels;
    public TextMeshProUGUI level; 
    public TextMeshProUGUI requieredCarrot;
    public TextMeshProUGUI requieredScore;
    public TextMeshProUGUI upgradeFull;



    public bool level1buyed = false;
    public bool level2buyed = false;
    public bool level3buyed = false;




    [Header("Color Stage")]

    //standart color stage
    public bool useStandartButton;
    //Blue buttonm Stage
    public bool isBuyableColorBlue = true;
    public  bool useBlueButton;
    public   bool isBuyedBlueColor;

    //pink color stage
    public  bool isBuyableColorPink = true;
    public   bool usePinkButton;
    public  bool isBuyedPinkColor;

    //brown color 
    public  bool isBuyableColorBrown = true;
    public  bool useBrownButton;
    public   bool isBuyedBrownColor;

    //spaciel color
    public bool isBuyableColorSpaciel = true;
    public bool useSpacielButton;
    public bool isBuyedSpacielColor;


    public bool reset = true;





    private void Awake()
    {


        colorChangeSave();

    }

    void Start()
    {
        print(level1buyed);
        print(level2buyed);
        print(level3buyed); 

        LoadPlayer();

        if (reset == true)
        {
            PlayerPrefs.DeleteAll();
            reset = false;

        }

        UÝController.score = PlayerPrefs.GetInt("bestScore");

        PlayerPrefs.SetInt("scoreText" , UÝController.score);

        UÝController.score = PlayerPrefs.GetInt("scoreText");

        PlayerPrefs.Save();

        //
        UÝController.MainMenuScore = PlayerPrefs.GetInt("Coin");

        PlayerPrefs.SetInt("TotalCarrot", UÝController.MainMenuScore);

        UÝController.MainMenuScore = PlayerPrefs.GetInt("TotalCarrot");

        PlayerPrefs.Save();

        totalCarrot.text = UÝController.MainMenuScore.ToString();
        scoreText.text = UÝController.score.ToString();

        print(UÝController.MainMenuScore);


        // Abilites 

        level.text = PlayerPrefs.GetInt("levelText" , 1).ToString();
        requieredCarrot.text = PlayerPrefs.GetInt("carrot" , 30).ToString();
        requieredScore.text = PlayerPrefs.GetInt("score" ,2500 ).ToString();

    }

    void Update()
    {
        colorChangeSave();
        abilitesSave();

        print(PlayerManager.level);

    }

    public void StorePrice(int Price)
    {
            if (PlayerPrefs.GetInt("Coin") >= Price)
            {

                UÝController.MainMenuScore -= Price;
                UÝController.coin -= Price;

                PlayerPrefs.SetInt("Coin", UÝController.coin);

                UÝController.coin = PlayerPrefs.GetInt("Coin");

                PlayerPrefs.Save();

                totalCarrot.text = UÝController.MainMenuScore.ToString();

                print(UÝController.MainMenuScore);

            }

    }// fiyat biçme kýsmý


    private void abilitesSave()
    {
        // abilites
        if (abilitesDoubleJump)
        {
            PlayerManager.doubleTapActive = true;
            doubleJumpBuyButton.image.color = Color.white;
            // Upgrade Ui panel active
            abilitesUpgradePanel.SetActive(true);
            buyDoubleJumpPrice.SetActive(false);
        }

        if(level1buyed == true)// level 1
        {
            levels[0].image.color = Color.green;
            PlayerManager.level = 1;
            PlayerPrefs.SetInt("levelText", 2);
            level.text = "2";
            PlayerPrefs.SetInt("carrot", 45);
            requieredCarrot.text = "45";
            PlayerPrefs.SetInt("score", 3500);
            requieredScore.text = "3500M";

        }
        if (level2buyed == true)// level 2 
        {
            levels[0].image.color = Color.green;

            levels[1].image.color = Color.green;
            PlayerManager.level = 2;
            PlayerPrefs.SetInt("levelText", 3);
            level.text = "3";
            PlayerPrefs.SetInt("carrot", 55);
            requieredCarrot.text = "55";

            PlayerPrefs.SetInt("score", 6000);
            requieredScore.text = "6000M";




        }
        if (level3buyed == true)
        {
            levels[0].image.color = Color.green;

            levels[1].image.color = Color.green;
            levels[2].image.color = Color.green;
            PlayerManager.level = 3;
            requiresPanel.SetActive(false);
            buyDoubleJumpPrice.SetActive(false);

            upgradeFull.gameObject.SetActive(true);


        }//level 3

    }

    private void colorChangeSave()
    {


        // Blue Color
        if (isBuyedBlueColor == true)
        {
            buyButtons[1].image.color = Color.white;

            prices[0].SetActive(false);
            use[0].SetActive(true);

        }
 

        if(useBlueButton == true)
        {
            UseButtonBlue();
            useButtons[0].image.color = Color.green;

        }
        else
        {
            useButtons[0].image.color = Color.white;

        }


        //Standart Color 
        if(useStandartButton == true)
        {
            standartColor();
            buyButtons[0].image.color = Color.green;

        }
        else
        {
            buyButtons[0].image.color = Color.white;

        }



        //Pink Color
        if (isBuyedPinkColor == true)
        {
            buyButtons[2].image.color = Color.white;
            prices[1].SetActive(false);
            use[1].SetActive(true);
        }
 

        if(usePinkButton == true)
        {
            UseButtonPink();
            useButtons[1].image.color= Color.green;

        }
        else
        {
            useButtons[1].image.color = Color.white;

        }

        //Brown Color

        if(isBuyedBrownColor == true)
        {
            buyButtons[3].image.color = Color.white;

            prices[2].SetActive(false);
            use[2].SetActive(true);
        }

        if(useBrownButton == true)
        {
            UseButtonBrown();
            useButtons[2].image.color = Color.green;

        }
        else
        {
            useButtons[2].image.color = Color.white;

        }

        // Spaciel Color
        
        if(isBuyedSpacielColor == true)
        {
            buyButtons[4].image.color = Color.white;

            prices[3].SetActive(false);
            use[3].SetActive(true);
        }


        if (useSpacielButton == true)
        {
            UseButtonSpaciel();
            useButtons[3].image.color = Color.green;

        }
        else
        {
            useButtons[3].image.color = Color.white;

        }


    }

    // Standart Color Stage
    public void standartColor()
    {
        PlayerManager.standartColor = true;
        PlayerManager.blueColor = false;
        PlayerManager.pinkColor = false;
        PlayerManager.bronwColor = false;
        PlayerManager.spacielColor = false;




        buyButtons[0].image.color = Color.green;

        useStandartButton = true;
        useBlueButton = false;
        usePinkButton = false;
        useBrownButton = false;
        useSpacielButton = false;

    }


    //Blue color
    public void blueColorBuyButton() // butonun satýn alma evresi 
    {

        if(PlayerPrefs.GetInt("Coin") >= 20)// price
        {
            if (isBuyableColorBlue == true)
            {
                StorePrice(20);
                isBuyableColorBlue = false;

                isBuyedBlueColor = true;

                buyButtons[1].image.color = Color.white;
                prices[0].SetActive(false);

                use[0].SetActive(true);

                
            }
        }



    }

    public void UseButtonBlue()
    {
        // oyun baþlayýnca renk deðiþimini saðlanayn kod 
        PlayerManager.blueColor = true;
        PlayerManager.standartColor = false;// standartý de aktive ediyor 
        PlayerManager.bronwColor= false;
        PlayerManager.pinkColor= false;
        PlayerManager.spacielColor = false;



        useBlueButton = true;
        usePinkButton = false;
        useBrownButton= false;
        useStandartButton = false;
        useSpacielButton = false;



        useButtons[0].image.color = Color.green;

    }

    //Pink Color Stage

    public void pinkColorBuyButton()
    {
        if(PlayerPrefs.GetInt("Coin")>= 20 )
        {
            if (isBuyableColorPink == true)
            {
                StorePrice(20);
                isBuyableColorPink = false;

                isBuyedPinkColor = true;
                buyButtons[2].image.color = Color.white;
                prices[1].SetActive(false);
                use[1].SetActive(true);

            }

        }


    }

    public void UseButtonPink()
    {
        PlayerManager.pinkColor = true;
        PlayerManager.standartColor = false;
        PlayerManager.blueColor = false;
        PlayerManager.bronwColor = false;
        PlayerManager.spacielColor = false;


        usePinkButton = true;
        useBlueButton = false;
        useBrownButton = false;
        useStandartButton = false;
        useSpacielButton = false;

        useButtons[1].image.color = Color.green;

    }

    //Brown Color Stage

    public void brownBuyButton()
    {
        if(PlayerPrefs.GetInt("Coin") >= 20)
        {
            if (isBuyableColorBrown == true)
            {
                StorePrice(20);
                isBuyableColorBrown = false;
                isBuyedBrownColor = true;

                buyButtons[3].image.color = Color.white;
                prices[2].SetActive(false);
                use[2].SetActive(true);

            }
        }


    }

    public void UseButtonBrown()
    {
        PlayerManager.bronwColor = true;
        PlayerManager.standartColor = false;
        PlayerManager.blueColor = false;
        PlayerManager.pinkColor = false;
        PlayerManager.spacielColor = false;


        useBrownButton = true;
        usePinkButton = false;
        useBlueButton = false;
        useStandartButton = false;
        useSpacielButton= false;


        useButtons[2].image.color = Color.green;
    }

    //Spaciel Color Stage

    public void spacielColorBuyButton()
    {
        if (PlayerPrefs.GetInt("Coin") >= 20)
        {
            if (isBuyableColorSpaciel == true)
            {
                StorePrice(20);
                isBuyableColorSpaciel = false;

                isBuyedSpacielColor = true;
                buyButtons[4].image.color = Color.white;
                prices[3].SetActive(false);
                use[3].SetActive(true);

            }

        }
    }

    public void UseButtonSpaciel()
    {
        PlayerManager.spacielColor = true;
        PlayerManager.standartColor = false;
        PlayerManager.blueColor = false;
        PlayerManager.bronwColor = false;
        PlayerManager.pinkColor=false;

        useSpacielButton = true;
        usePinkButton = false;
        useBlueButton = false;
        useBrownButton = false;
        useStandartButton = false;

        useButtons[3].image.color = Color.green;

    }



    // Double Jump System

    public void BuyDoubleJump()
    {
        if(PlayerPrefs.GetInt("Coin") > 30 && PlayerPrefs.GetInt("bestScore") > 1 && abilitesDoubleJump == false)
        {
            abilitesDoubleJump = true;

            if (abilitesDoubleJump)
            {
                PlayerManager.doubleTapActive = true;
                doubleJumpBuyButton.image.color = Color.white;
                PlayerManager.level = 0;

            }
            print("Double Jump Active");

        }
    }

    public void doubleJumpLevel()
    {
        if(level1buyed == false && level3buyed == false && level2buyed == false)
        {
            if (PlayerPrefs.GetInt("Coin") > 30 && PlayerPrefs.GetInt("bestScore") > 2)//level 1
            {
                StorePrice(30);
                PlayerManager.level = 1;
                print("level 1");

                level1buyed = true;
            }
        }
        else if ( level2buyed == false && level1buyed == true && level3buyed == false)
        {
            if (PlayerPrefs.GetInt("Coin") > 45 && PlayerPrefs.GetInt("bestScore") > 3)//level 2
            {
                StorePrice(45);
                PlayerManager.level = 2;
                print("level 2");

                level2buyed = true;
                level1buyed=false;
                

            }
        }
        else if( level3buyed == false && level2buyed == true)
        {
            if (PlayerPrefs.GetInt("Coin") > 55 && PlayerPrefs.GetInt("bestScore") > 4)//level 3
            {
                StorePrice(55);
                PlayerManager.level =3 ;
                print("level 3");
                level3buyed = true;
                level2buyed=false;
                level1buyed=false;
            }
        }
        else
        {
            return;
        }


    }




    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        useStandartButton = data.useStandartButton;


        isBuyableColorBlue = data.isBuyableColorBlue;
        useBlueButton = data.useBlueButton;
        isBuyedBlueColor = data.isBuyedBlueColor;


        isBuyableColorPink = data.isBuyableColorPink;
        usePinkButton = data.usePinkButton;
        isBuyedPinkColor = data.isBuyedPinkColor;

        isBuyableColorBrown = data.isBuyableColorBrown;
        useBrownButton = data.useBrownButton;
        isBuyedBrownColor = data.isBuyedBrownColor;

        isBuyableColorSpaciel = data.isBuyableColorSpaciel;
        useSpacielButton = data.useSpacielButton;
        isBuyedSpacielColor = data.isBuyedSpacielColor;

        abilitesDoubleJump = data.abilitesDoubleJump;

        level1buyed = data.level1buyed;
        level2buyed = data.level2buyed;
        level3buyed = data.level3buyed;

        reset = data.reset;

    }

    public void SavePlayer()
    {

        SaveSystem.SavePlayer(this);
    }

    public void ResetDeAtive()
    {
        reset = false;
    }



}
