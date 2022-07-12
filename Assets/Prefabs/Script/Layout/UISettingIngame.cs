
using UnityEngine;
using UnityEngine.UI;

public class UISettingIngame : MonoBehaviour
{
    public static UISettingIngame Instance;
    public Canvas canvas;
    [SerializeField] Button btnContinue, btnShop;


    private void Awake()
    {
        canvas = GetComponent<Canvas>();
        Instance = (UISettingIngame)this;

    }

    private void OnEnable()
    {
        if (btnContinue != null)
            btnContinue.onClick.AddListener(() => 
            {
                UIManager.Instance.RemoveFromListDialog(this.gameObject);
                UIGameplay.Instance.gameObject.SetActive(true); 
                Continue();
            });
        if (btnShop != null)
            btnShop.onClick.AddListener(() =>
            {
                if (UIShop.Instance == null)
                {
                    UIManager.Instance.AddToListDialog(UIManager.Instance.UIShop);
                    UIShop.Instance.canvas.sortingOrder = 12;
                    UIGameplay.Instance.gameObject.SetActive(false);
                    UiEnd.Instance.gameObject.SetActive(false);
                    UIBackground.Instance.gameObject.SetActive(false);
                    Continue();
                }
            });
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        UIBackground.Instance.isPause = true;
    }

    public void Continue()
    {
        Time.timeScale = 1f;
        UIBackground.Instance.isPause = false;
    }
}
