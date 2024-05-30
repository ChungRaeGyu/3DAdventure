using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interaction : MonoBehaviour
{
    Camera camera;
    public float maxDistance;
    public LayerMask layerMask;
    Iinteractable curItem;
    GameObject curObject;
    public Text text;
    PlayerController playerController;
    // Start is called before the first frame update
    private void Awake() {
        camera = Camera.main;
        playerController=GetComponent<PlayerController>();
    }
    private void Start() {
        playerController.OnInteractEvent+=onInteract;
        
    }
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width/2,Screen.height/2,0));
        RaycastHit hit;
        if(Physics.Raycast(ray,out hit,maxDistance, layerMask)){
            if(hit.collider== curObject) return;
            curItem = hit.collider.GetComponent<Iinteractable>();
            curObject = hit.collider.gameObject;
            GameManager.Instance.PlayerData.curItem = curObject.GetComponent<ItemManager>().itemData;
            PromptPrint();  //아이템 출력 메소드
            //TODO : 아이템 출력 메소드 생성하기 
        }else
        {
            curItem = null;
            curObject = null;
            text.gameObject.SetActive(false);
            GameManager.Instance.PlayerData.curItem = null;
        }
    }

    private void onInteract()
    {
        curItem.OnInteract();
    }
    private void PromptPrint()
    {
        text.gameObject.SetActive(true);
        text.text = curItem.returnText();
    }
}
