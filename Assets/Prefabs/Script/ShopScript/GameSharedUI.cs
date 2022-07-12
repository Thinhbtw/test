using UnityEngine;
using UnityEngine.UI;

public class GameSharedUI : MonoBehaviour
{

    #region Singleton class: GameSharedUI

    public static GameSharedUI instance;

    private void Awake()
    {
        if(instance == null)
            instance = this;

    }

    #endregion

    [SerializeField] Text[] coinUIText;


    public void UpdateCoinsUIText()
    {
        for(int i = 0; i < coinUIText.Length; i++)
        {
            SetCoinsText(coinUIText[i], GameData.GetCoin());
        }
    }

    void SetCoinsText(Text text, int value)
    {
        if (value > 1000)
            text.text = string.Format("{0}K.{1}", (value / 1000), GetFirstDigitFromNumber(value % 1000));
        else
            text.text = value.ToString();
    }

    int GetFirstDigitFromNumber(int num)
    {
        return int.Parse(num.ToString() [0].ToString());
    }
}
