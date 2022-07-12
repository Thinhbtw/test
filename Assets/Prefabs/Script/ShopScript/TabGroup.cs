using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabGroup : MonoBehaviour
{
    // Start is called before the first frame update
    public List<TabButtons> tabButtons;
    public Sprite tabIdle;
    public Sprite tabHover;
    public Sprite tabActive;
    public TabButtons selectedTab;
    public List<GameObject> objectsToSwap;
    public int index;

    public void Subscribe(TabButtons button)
    {
        if(tabButtons == null)
        {
            tabButtons = new List<TabButtons>();
        }
        tabButtons.Add(button);
    }

    public void OnTabEnter(TabButtons button)
    {
        ResetTab();
        if (selectedTab == null || button != selectedTab)
        {
            button.background.sprite = tabHover;
        }
    }
    public void OnTabExit(TabButtons button)
    {
        ResetTab();
    }
    public void OnTabSelected(TabButtons button)
    {
        selectedTab = button;
        ResetTab();
        button.background.sprite = tabActive;
        index = button.transform.GetSiblingIndex();
        for(int i = 0; i < objectsToSwap.Count; i++)
        {
            if(i == index)
            {
                objectsToSwap[i].SetActive(true);
            }
            else
            {
                objectsToSwap[i].SetActive(false);
            }
        }
    }

    public void ResetTab()
    {
        foreach(TabButtons button in tabButtons)
        {
            if(selectedTab != null && button == selectedTab) { continue; }
            button.background.sprite = tabIdle; 
        }
    }
}
