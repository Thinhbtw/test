using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelProgressBar : MonoBehaviour
{
    public Slider progressBar;
    UIGameplay uiGameplay;
    int levelIndex;

    // Start is called before the first frame update

    private void Awake()
    {
        uiGameplay = FindObjectOfType<UIGameplay>();

    }

    private void OnEnable()
    {
        progressBar.value = uiGameplay.levelAt % 5;
        
    }

    private void Update()
    {
        if(uiGameplay == null)
            uiGameplay = FindObjectOfType<UIGameplay>();

        if (progressBar.value <= 4 && uiGameplay.levelAt % 5 != 0) 
            progressBar.value = Mathf.MoveTowards(progressBar.value, uiGameplay.levelAt % 5, Time.deltaTime * 1);

        


    }
}