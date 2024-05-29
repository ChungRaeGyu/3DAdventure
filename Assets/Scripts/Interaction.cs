using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interaction : MonoBehaviour
{
    Camera camera;
    public float maxDistance;
    public LayerMask layerMask;
    public Text text;
    // Start is called before the first frame update
    private void Awake() {
        camera = Camera.main;
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width/2,Screen.height/2,0));
        RaycastHit hit;
        if(Physics.Raycast(ray,out hit,maxDistance, layerMask)){
            text.text = $"이름 : {hit.collider.gameObject.name}";
        }else
            { text.text = ""; }
    }
}
