using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISetting : MonoBehaviour
{
    [SerializeField] Button btnBack, btnMusic, btnNotification, btnVibrate;

    public static UISetting Instance;
    [SerializeField] Sprite[] spriteArray;

    private void Awake()
    {
        Instance = (UISetting)this;
        if (!PlayerPrefs.HasKey("SaveSettings"))
        {
            PlayerPrefs.SetString("SaveSettings", "024");
        }
        if (PlayerPrefs.GetString("SaveSettings").Contains("0"))
            btnMusic.image.sprite = spriteArray[0];
        if (PlayerPrefs.GetString("SaveSettings").Contains("1"))
            btnMusic.image.sprite = spriteArray[1];
        if (PlayerPrefs.GetString("SaveSettings").Contains("2"))
            btnNotification.image.sprite = spriteArray[2];
        if (PlayerPrefs.GetString("SaveSettings").Contains("3"))
            btnNotification.image.sprite = spriteArray[3];
        if (PlayerPrefs.GetString("SaveSettings").Contains("4"))
            btnVibrate.image.sprite = spriteArray[4];
        if (PlayerPrefs.GetString("SaveSettings").Contains("5"))
            btnVibrate.image.sprite = spriteArray[5];

        if (btnMusic != null)
            btnMusic.onClick.AddListener(() =>
            {
                if (PlayerPrefs.GetString("SaveSettings").Contains("0"))
                {
                    PlayerPrefs.SetString("SaveSettings", PlayerPrefs.GetString("SaveSettings").Replace("0", "1"));
                    btnMusic.image.sprite = spriteArray[1];
                    return;

                }
                if (PlayerPrefs.GetString("SaveSettings").Contains("1"))
                {
                    PlayerPrefs.SetString("SaveSettings", PlayerPrefs.GetString("SaveSettings").Replace("1", "0"));
                    btnMusic.image.sprite = spriteArray[0];
                    return;
                }

            });
        if (btnNotification != null)
            btnNotification.onClick.AddListener(() =>
            {
                if (PlayerPrefs.GetString("SaveSettings").Contains("2"))
                {
                    PlayerPrefs.SetString("SaveSettings", PlayerPrefs.GetString("SaveSettings").Replace("2", "3"));
                    btnNotification.image.sprite = spriteArray[3];
                    return;
                }
                if (PlayerPrefs.GetString("SaveSettings").Contains("3"))
                {
                    PlayerPrefs.SetString("SaveSettings", PlayerPrefs.GetString("SaveSettings").Replace("3", "2"));
                    btnNotification.image.sprite = spriteArray[2];
                    return;
                }
            });
        if (btnVibrate != null)
            btnVibrate.onClick.AddListener(() =>
            {
                if (PlayerPrefs.GetString("SaveSettings").Contains("5"))
                {
                    PlayerPrefs.SetString("SaveSettings", PlayerPrefs.GetString("SaveSettings").Replace("5", "4"));
                    btnVibrate.image.sprite = spriteArray[4];
                    return;
                }
                if (PlayerPrefs.GetString("SaveSettings").Contains("4"))
                {
                    PlayerPrefs.SetString("SaveSettings", PlayerPrefs.GetString("SaveSettings").Replace("4", "5"));
                    btnVibrate.image.sprite = spriteArray[5];
                    return;
                }
                
            });
    }

    private void OnEnable()
    {
        if (btnBack != null)
            btnBack.onClick.AddListener(() =>
            {               
                if(UIManager.Instance.list.Count > 2)
                {
                    UIManager.Instance.LoadPreviousDialog();
                    UIGameplay.Instance.gameObject.SetActive(false);
                    UIHome.Instance.gameObject.SetActive(true);
                }
                else
                {
                    UIManager.Instance.LoadPreviousDialog();
                    UIHome.Instance.gameObject.SetActive(true);
                }
            });
    }

}
