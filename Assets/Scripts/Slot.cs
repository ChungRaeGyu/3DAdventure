using System;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public ItemData itemData;
    public Image icon;
    public UIInventory uIInventory;
    public void Set(){
        icon.sprite = itemData.icon;
    }

    public void Clear()
    {
        icon.sprite = null;
        icon=null;
    }
    
    public void OnButton(){
        //버튼이 눌렸을때 행동
        if(itemData==null)return;
        uIInventory.SetDescription(this);
    }    
}
