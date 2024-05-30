<div align="center"><h1>3DAdventure</h1>
게임개발 숙련 과제 입니다. 
</div>

- [구현사항](#구현사항)
- [와어프레임](#와이어프레임)

# 구현사항
### 필수구현사항
1. 기본이동 구현 및 점프
- 이동 : WASD로 움직이며 new InputSystem,Rigidbody.Velocity를 사용했습니다.
- 점프 : Space바로 작동 new InputSystem, Rigidbody.AddForce를 사용했습니다.
2. 체력바UI
- 체력바 : UI ImageType Filled를 사용했습니다.
- 스테미나 : 점프를 했을때 감소하도록 했습니다.
3. 동적 환경 조사
- RayCast를 사용하여 물체 인식시 InteractLayer에 있다면 그 아이템의 정보를 표시했습니다.
 ![image](https://github.com/ChungRaeGyu/3DAdventure/assets/125470068/5407719c-279a-446f-a292-2c912b9325a4)
4. 점프대
- OnTriggerEnter를 사용하여 일정 범위에 들어오면 AddForce의 ForceMode.Impulse를 사용하여 뛰도록 했습니다.
![image](https://github.com/ChungRaeGyu/3DAdventure/assets/125470068/65e0820a-186d-4302-9800-ff051144052d)

5. 아이템 데이터
- Scriptable오브젝트를 사용하여 ItemData를 생성해서 Item프리팹에 넣어서 사용하였습니다.
![image](https://github.com/ChungRaeGyu/3DAdventure/assets/125470068/8f6a41db-14bd-4a69-a864-d0a2fe2d62b3)

6. 아이템 사용
- InventoryUI를 만들어서 UI에서 버튼을 이용하여 선택 후 선택된 아이템의 정보를 받아오고 사용하기 버튼을 이용하여 Player의 능력치가 오르게 만들었습니다.
  ![image](https://github.com/ChungRaeGyu/3DAdventure/assets/125470068/5ebf6fd1-735b-4f3f-a1e0-07be3f711553)



  
