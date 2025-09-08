using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]// kaydedilmesini saðlar
public class PlayerData
{
    //standart color stage
    public bool useStandartButton;

    //Blue buttonm Stage
    public  bool isBuyableColorBlue;
    public  bool useBlueButton;
    public  bool isBuyedBlueColor;

    //pink color stage
    public  bool isBuyableColorPink;
    public  bool usePinkButton;
    public  bool isBuyedPinkColor;

    //brown color 
    public  bool isBuyableColorBrown;
    public  bool useBrownButton;
    public  bool isBuyedBrownColor;


    //spaciel color
    public bool isBuyableColorSpaciel;
    public bool useSpacielButton;
    public bool isBuyedSpacielColor;

    public bool reset;


    // Abilities
    public bool abilitesDoubleJump;
    public bool level1buyed;
    public bool level2buyed;
    public bool level3buyed;


    public PlayerData(MainMenuUiManager player)
    {
        useStandartButton = player.useStandartButton;

        isBuyableColorBlue = player.isBuyableColorBlue;
        useBlueButton = player.useBlueButton;
        isBuyedBlueColor = player.isBuyedBlueColor;

        isBuyableColorPink = player.isBuyableColorPink;
        usePinkButton = player.usePinkButton;
        isBuyedPinkColor = player.isBuyedPinkColor;

        isBuyableColorBrown = player.isBuyableColorBrown;
        useBrownButton = player.useBrownButton;
        isBuyedBrownColor = player.isBuyedBrownColor;

        isBuyableColorSpaciel = player.isBuyableColorSpaciel;
        useSpacielButton = player.useSpacielButton;
        isBuyedSpacielColor = player.isBuyedSpacielColor;

        abilitesDoubleJump = player.abilitesDoubleJump;

        level1buyed = player.level1buyed;
        level2buyed = player.level2buyed;
        level3buyed = player.level3buyed;


        reset = player.reset;

    }


}
