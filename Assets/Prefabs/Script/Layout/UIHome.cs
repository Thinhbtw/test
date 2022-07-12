using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHome : MonoBehaviour
{
    [SerializeField] Button btnStart, btnSetting, btnShop, btnAchivement, btnDropMenu, btnLevel;

    public static UIHome Instance;
    [SerializeField] GameObject panel;
    bool isOn;
    [SerializeField] Text levelText;
    private void Awake()
    {
        Instance = (UIHome)this;
        if (PlayerPrefs.HasKey("Progress"))
        {
            int level = PlayerPrefs.GetInt("SelectedLevel");
            if ((level + 1) < 10)
            {
                levelText.text = "0" + (level  + 1).ToString();
            }
            else
            {
                levelText.text = (level / 5 + 1).ToString();
            }
            btnLevel.interactable = true;
        }
        else
            btnLevel.interactable = false;
    }

    private void Start()
    {
        if (btnDropMenu != null)
            btnDropMenu.onClick.AddListener(() =>
            {
                isOn = !isOn;
                panel.gameObject.SetActive(isOn);
            });

        
    }

    private void OnEnable()
    {
        if (btnLevel != null)
            btnLevel.onClick.AddListener(() =>
            {
                if(UILevel.Instance == null)
                {
                    UIManager.Instance.AddToListDialog(UIManager.Instance.UILevel);
                }
                else
                {
                    UILevel.Instance.gameObject.SetActive(true);
                }
            });
        if (btnStart != null)
            btnStart.onClick.AddListener(() =>
            {
                if (UIGameplay.Instance == null && UiEnd.Instance == null)
                {
                    UIManager.Instance.AddToListDialog(UIManager.Instance.UIGameplay);
                    UIManager.Instance.AddToListDialog(UIManager.Instance.UIEnd);
                    UIManager.Instance.AddToListDialog(UIManager.Instance.UILevel);
                    UILevel.Instance.gameObject.SetActive(false);
                    UIBackground.Instance.gameObject.SetActive(true);
                    UiEnd.Instance.canvas.sortingOrder = 10;
                    UIManager.Instance.RemoveFromListDialog(this.gameObject);
                    

                }
                else
                {
                    UiEnd.Instance.gameObject.SetActive(true);
                    UIGameplay.Instance.gameObject.SetActive(true);
                    UIBackground.Instance.gameObject.SetActive(true);
                }
                
            }
            );
        if(btnSetting != null)
        {
            btnSetting.onClick.AddListener(() =>
            {
                if (UISetting.Instance == null)
                {
                    UIManager.Instance.AddToListDialog(UIManager.Instance.UISetting);
                }
                else
                {
                    UISetting.Instance.gameObject.SetActive(true);
                }
            });
        }

        if (btnShop != null)
            btnShop.onClick.AddListener(() =>
            {
                if(UIShop.Instance == null)
                {
                    gameObject.SetActive(false);
                    UIManager.Instance.AddToListDialog(UIManager.Instance.UIShop);
                }
            });

        if (btnAchivement != null)
            btnAchivement.onClick.AddListener(() =>
            {
                if (achivementManager.instance == null)
                {
                    gameObject.SetActive(false);
                    UIManager.Instance.AddToListDialog(UIManager.Instance.UIAchivement);
                }
            });
        
    }
}
