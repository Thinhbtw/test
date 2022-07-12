using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiEnd : MonoBehaviour
{
    public static UiEnd Instance;
    public GameObject pannel;
    [SerializeField] Text text, textBtn;
    [SerializeField] Button btnNext;
    public Canvas canvas;
    LevelComplete myScript;
    UIGameplay uiGameplay;
    public bool isComplete;
    LevelProgressBar progressBar;

    private void Awake()
    {
        Instance = (UiEnd)this;
        pannel.SetActive(false);
        canvas = GetComponent<Canvas>();
    }

    private void Start()
    {
        myScript = FindObjectOfType<LevelComplete>();
        uiGameplay = FindObjectOfType<UIGameplay>();
        progressBar = FindObjectOfType<LevelProgressBar>();
    }

    public void DieWhenWinning()
    {
        text.text = "Game Over!";
        textBtn.text = "Retry Level";
        myScript.isComplete = true;
        myScript.isDed = true;
    }

    public IEnumerator WaitPanel(bool win)
    {
        yield return new WaitForSeconds(2);
        if (win)
        {
            text.text = "Level Complete!";
            textBtn.text = "Next Level";
            pannel.SetActive(true);

        }
        else
        {
            text.text = "Game Over!";
            textBtn.text = "Retry Level";
            myScript.check= true;
            myScript.isComplete= true;
            pannel.SetActive(true);
        }
        yield break;
    }

    

    private void Update()
    {     
        if(myScript == null)
            myScript = FindObjectOfType<LevelComplete>();
        /*if(uiGameplay == null)
            uiGameplay = FindObjectOfType<UIGameplay>();*/
        if(progressBar == null)
            progressBar = FindObjectOfType<LevelProgressBar>();
    }

    private void OnEnable()
    {

        isComplete = false;
        canvas.sortingOrder = 10;
        if (btnNext != null)
            btnNext.onClick.AddListener(() =>
            {
                if(myScript.isDed)
                {
                    var lvl = Instantiate(UIManager.Instance.listLevel[uiGameplay.levelAt], uiGameplay.levelField.transform);
                    uiGameplay.Level.Add(lvl);
                    Destroy(uiGameplay.Level[uiGameplay.Level.Count - uiGameplay.Level.Count]);
                    uiGameplay.Level.RemoveAt(uiGameplay.Level.Count - uiGameplay.Level.Count);

                    pannel.SetActive(false);

                    myScript.isDed = false;
                }

                else if(!myScript.isDed)
                {
                    if (UIManager.Instance.listLevel.Count % 5 == 0)
                    {
                        progressBar.progressBar.value = 0;
                    }

                    isComplete = true;
                    pannel.SetActive(false);
                    uiGameplay.hasNextLevel = true;
                                           
                }

            });
    }
}
