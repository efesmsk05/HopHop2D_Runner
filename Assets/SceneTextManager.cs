using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(TMP_Text))]
public class SceneTextManager : MonoBehaviour
{
    [Header("Test String")]
    [SerializeField] string testText;

    public GameObject text2;


    private TMP_Text textBox;
    
    // Basic typeWriter
    private int currentVisibleCharacterIndex;
    private Coroutine typeWriterCoroutine;
    //private Coroutine typeWriter;


    private WaitForSeconds _simpleDelay;
    private WaitForSeconds _noktalamaArasýDelay;

    [Header("TypeWriter Settings")]
    [SerializeField] private float charactersPerSecond = 20f;
    [SerializeField] private float noktalamaArasýDelay = 0.5f;


    private void Awake()
    {

        textBox = GetComponent<TMP_Text>();    
        _simpleDelay = new WaitForSeconds(1 / charactersPerSecond);
        _noktalamaArasýDelay = new WaitForSeconds(noktalamaArasýDelay);

    }

    private void Start()
    {
        SetText(testText);
    }


    private IEnumerator TypeWriter()
    {
        TMP_TextInfo textInfo = textBox.textInfo;

        while(currentVisibleCharacterIndex < textInfo.characterCount + 1)
        {
            char character = textInfo.characterInfo[currentVisibleCharacterIndex].character;

            textBox.maxVisibleCharacters++;

            currentVisibleCharacterIndex++;

            yield return _simpleDelay;


        }
        text2.SetActive(true);

    }


    private void SetText(string text)
    {
        if(typeWriterCoroutine != null)
        {
            StopCoroutine(typeWriterCoroutine);
        }

        textBox.text = text;
        textBox.maxVisibleCharacters = 0;
        noktalamaArasýDelay = 0;

        typeWriterCoroutine = StartCoroutine(TypeWriter());


    }




}
