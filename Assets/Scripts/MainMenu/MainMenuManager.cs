using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    

    private void Awake()
    {
        Time.timeScale = 1.0f;
    }
    void Start()
    {


        print("start");

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void LoadScene()
    {
        SceneManager.LoadScene(2);
    }
    
    public void OpenUiPanel()
    {
        

    }
}
