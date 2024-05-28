using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Condition : MonoBehaviour
{
    public float curValue;
    public float maxValue;
    public Image uiBar;
    // Start is called before the first frame update
    
    void Start()
    {
        //피해를 입으면 subtract를 호출한다.
        //회복을 하면 Add를 호출한다. 
        //UI없데이트를 해줘야 한다.
        
    }
    public void UpdateBar(){
        uiBar.fillAmount = curValue/maxValue;
    }
    
    public void Add(float value){
        curValue = Mathf.Min(curValue+value,maxValue);
        UpdateBar();
    }
    public void Subtract(float value){
        curValue = Mathf.Max(curValue - value, 0);
        UpdateBar();
    }
}
