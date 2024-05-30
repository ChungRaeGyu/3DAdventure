using System.Diagnostics;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class PlayerMovement : MonoBehaviour
{
    private PlayerController playerController;
    public Vector2 direction;
    public LayerMask groundLayerMask;
    public LayerMask MoveGroundLayerMask;
    private Rigidbody rigidbody;

    //MoveGround
    public Vector3 MoveGround;
    public bool isOn=false;
    //RotateCamera
    private Vector2 mouseDelta;
    private float mouseRotX;
    private float mouseRotY=0;
    public float InsentivityMouse;
    public Transform cameraContainer;

    [Header("Condition")]
    public ConditionController conditionController;
    void Start()
    {
        
        playerController = GetComponent<PlayerController>();
        rigidbody = GetComponent<Rigidbody>();
        playerController.OnMoveEvent += OnMove;
        playerController.OnJumpEvent += OnJump;
        playerController.OnLookEvent += OnLook;
    }

    private void FixedUpdate() {
        if(GameManager.Instance.PlayerData.OnInventory) return;
        Move();
    }
    private void LateUpdate() {
        if (GameManager.Instance.PlayerData.OnInventory) return;
        CameraLook();
    }
    private void Update() {
    }
    private void OnMove(Vector2 vector)
    {
        direction = vector;
        
    }
    private void Move(){
        //플레이어가 존나 덜덜거림
        //회전값에 영향을 안받아 그러니까 forward를 포함 시켜 줘야 할 꺼 같다.
        Vector3 dir = transform.forward*direction.y + transform.right*direction.x;
        dir *= GameManager.Instance.PlayerData.speed;
        dir.y = rigidbody.velocity.y;
        rigidbody.velocity=isOn?dir+MoveGround:dir;
        
    }

    private void OnLook(Vector2 vector)
    {
        mouseDelta = vector;
    }
    private void CameraLook(){
        //Debug.Log(mouseDelta.y); //진짜 변화량만 나온다. 확 내리면 확 바뀐다.
        //내가 원하는건 transform.eulerAngles의 x값이 -85~85사이로 유지하는 것
        mouseRotY +=mouseDelta.y;
        mouseRotY = Mathf.Clamp(mouseRotY, -850,850);
        cameraContainer.localEulerAngles = new Vector3(-mouseRotY * InsentivityMouse,0,0);
        //localEulerAngles를 사용하면 부모의 rotation값에 영항을 받는다.
        mouseRotX += mouseDelta.x;
        transform.eulerAngles = new Vector3(0, mouseRotX * InsentivityMouse, 0);
    }

    private void OnJump()
    {
        if(IsGrounded(groundLayerMask)){
            rigidbody.AddForce(Vector3.up * GameManager.Instance.PlayerData.jumpPower, ForceMode.Impulse);
            conditionController.stamina.Subtract(2);
        }
        
    }

    bool IsGrounded(LayerMask layerMask)
    {
        Ray[] rays = new Ray[4]{
            new Ray(transform.position + (transform.forward *0.2f)+ (transform.up*0.01f),Vector3.down),
            new Ray(transform.position + (-transform.forward *0.2f)+ (transform.up*0.01f),Vector3.down),
            new Ray(transform.position + (transform.forward *0.2f)+ (transform.up*0.01f),Vector3.down),
            new Ray(transform.position + (-transform.forward *0.2f)+ (transform.up*0.01f),Vector3.down),
        };
        for (int i = 0; i < rays.Length; i++)
        {  
            RaycastHit hit;
            if (Physics.Raycast(rays[i], out hit, 0.7f, layerMask))
            {
                return true;
            }
        }
        return false;
    }

    public void OnJumpSpot(float Power){
        rigidbody.AddForce(Vector3.up * Power, ForceMode.Impulse);
    }
}
