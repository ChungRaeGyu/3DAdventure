using UnityEngine;
using UnityEngine.UI;

public class UIInventory : MonoBehaviour
{
    public Slot[] slots;
    private Slot curSlot;
    public GameObject slotPanel;
    PlayerController playerController;

    [Header("Description")]
    public Text name;
    public Text description;
    public GameObject equipButton;
    public GameObject dropButton;
    public GameObject consumButton;
    public GameObject unEquipButton;

    
    // Start is called before the first frame update
    private void Awake() {
        playerController = GameObject.FindObjectOfType<PlayerController>();
        //slots = slotPanel.GetComponentsInChildren<Slot>();
    }
    void Start()
    {
        playerController.OnInventoryEvent += OpenInventory;
        GameManager.Instance.PlayerData.addItem += AddItem;
        gameObject.SetActive(false);
    }

    private void OpenInventory()
    {
        bool check = gameObject.activeSelf;
        Cursor.lockState = !check ? CursorLockMode.None : CursorLockMode.Locked;
        GameManager.Instance.PlayerData.OnInventory=!check;
        gameObject.SetActive(!check);     
    }

    public void AddItem()
    {
        Debug.Log("AddItem");
        ItemData itemData= GameManager.Instance.PlayerData.curItem;
        for(int i=0; i<slots.Length; i++){
            if(slots[i].itemData==null){
                slots[i].itemData = itemData;
                UpdateUI();
                return;
            }
        }
        DropItem(itemData);
        //만약에 인벤토리가 꽉 찼다면 버리기를 한다.
        //TODO : 아이템 삭제, GameManager.Instance.PlayerData.curItem 삭제, slots에 설정해주기음~~
    }
    public void DropItem(ItemData itemData)
    {
        UpdateUI();
        Instantiate(itemData.dropPrefab);
    }

    void UpdateUI(){
        foreach(Slot slot in slots){
            if(slot.itemData!=null){
                slot.Set();
            }else{
                slot.Clear();
            }
        }
    }

    public void ConsumBtn(){
        if(curSlot.itemData==null) return;
        //TODO : 아이템별로 각각 분리시켜서 능력 추가를 해야함 이렇게 하면 어떤 아이템을 사용해도 속도만 올라간다.
        GameManager.Instance.PlayerData.speed +=2;
        Debug.Log("실행");
        curSlot.itemData=null;
        curSlot = null;
        UpdateUI();
    }

    public void SetDescription(Slot slot)
    {
        curSlot = slot;
        name.text = curSlot.itemData.name;
        description.text = curSlot.itemData.description;
        consumButton.SetActive(curSlot.itemData.type== ItemType.Consumable);
        dropButton.SetActive(true);
        equipButton.SetActive(curSlot.itemData.type==ItemType.Equipable&& curSlot.itemData.isEquip);
        unEquipButton.SetActive(curSlot.itemData.type == ItemType.Equipable && !curSlot.itemData.isEquip);
    }
}
