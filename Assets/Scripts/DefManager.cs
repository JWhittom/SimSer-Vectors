﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DefManager : MonoBehaviour 
{
    // SerializeFields for assignment in-editor
    // Time before the user can proceed
    [SerializeField] float waitTime = 3f;
    // Name of next scene
    [SerializeField] string nextScene = "Main";
    // Text to indicate how to proceed
    [SerializeField] Text goText;

    // Private fields
    // Has enough time passed to proceed?
    bool canGo;
    // Has the player given input to proceed?
    bool shouldGo;

	// Use this for initialization
	void Start () 
	{
        canGo = false;
        goText.gameObject.SetActive(false);
        StartCoroutine(WaitToProceed());
	}

    private void Update()
    {
        HandleInput();
        if (canGo && shouldGo)
            SceneManager.LoadScene(nextScene);
    }

    void HandleInput()
    {
        if (Input.GetMouseButtonDown(0))
            shouldGo = true;
        else
            shouldGo = false;
    }

    // IEnumerators
    IEnumerator WaitToProceed()
    {
        yield return new WaitForSeconds(waitTime);
        goText.gameObject.SetActive(true);
        canGo = true;
    }
}