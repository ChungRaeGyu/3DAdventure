using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public interface Iinteractable
{
    public string returnText();
    public void OnInteract();
}
public class ItemManager : MonoBehaviour,Iinteractable
{

    public ItemData itemData;

    public void OnInteract()
    {
        GameManager.Instance.PlayerData.addItem?.Invoke(); //UIInventory 아이템추가 메소드 호출
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    public string returnText(){
        string str = $"이름 : {itemData.name} \n 설명 : {itemData.description}";
        return str;
    }
}
