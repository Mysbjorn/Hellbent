using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialog : Interactable
{
    public GameObject dialogWindow;
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed;
    public GameObject continueButton;
    public override void Interact()
    {
        base.Interact();
        Debug.Log("Talking with me!");
        StartCoroutine(Type());
        
    }

    
    IEnumerator Type()
    {
        Debug.Log("Hello");
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);

            if (textDisplay.text == sentences[index])
            {
                continueButton.SetActive(true);
            }
        }
    }

    public void NextSemtemce()
    {
        continueButton.SetActive(false);
        if (index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            textDisplay.text = "";
            continueButton.SetActive(false);
        }
    }

}
