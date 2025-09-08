using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    public Canvas gameOverCanvas;

    public float isSpawnableCounter;



    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
            Time.timeScale = 1.0f;
    }

    void Update()
    {

        SpawnGround();

        if(PlayerManager.instance.gameOver == true)
        {
            gameOverCanvas.GetComponent<Canvas>().enabled = true;
            Time.timeScale = 0.0f;
        }
        
    }

    private void SpawnGround()
    {
       
        if(GroundManager.instance.isSpawnable == true)
        {

            GroundManager.instance.generateGround();
            GroundManager.instance.isSpawnable = false;

        }

    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(1);
    }



}
