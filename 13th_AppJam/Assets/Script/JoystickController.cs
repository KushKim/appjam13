using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class JoystickController : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    private bool DisDrag;


    public Image PedImg;
    public Image JoystickImg;

    private Rigidbody PlayerRigid;

    private Vector3 InputVector;
    private Vector3 StartVector;

    [SerializeField]
    private Vector3 NowVector;
    [SerializeField]
    private Vector3 Direction;

    private PlayerDataContainer playerDataContainer;

    private float Degree;

    public Transform tran;
    public Weapon weapon;
    public PlayerAttack playerAttack;

    //private PlayerManager playerManager;

    private void Awake()
    {
        //playerManager = InGameManager.Instance.PlayerDataContainer_readonly._PlayerManager;
        playerDataContainer = InGameManager.Instance._PlayerDataContainer;
    }

    public virtual void OnDrag(PointerEventData ped)
    {
        DisDrag = true;

        Vector2 pos;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(PedImg.rectTransform,
                                                                    ped.position,
                                                                    ped.pressEventCamera,
                                                                    out pos))
        {
            pos.x = (pos.x / PedImg.rectTransform.sizeDelta.x);
            pos.y = (pos.y / PedImg.rectTransform.sizeDelta.y);

            NowVector = JoystickImg.transform.localPosition;

            InputVector = new Vector3(pos.x * 2, 0, pos.y * 2);
            InputVector = (InputVector.magnitude > 1.0f) ? InputVector.normalized : InputVector;



            JoystickImg.rectTransform.anchoredPosition =
                new Vector3(InputVector.x * (PedImg.rectTransform.sizeDelta.x / 2.5f), InputVector.z * (PedImg.rectTransform.sizeDelta.y / 2.5f));
        }
        NowVector = JoystickImg.transform.localPosition;
        Direction = (NowVector - StartVector).normalized;

        Degree = Mathf.Atan2(NowVector.y - StartVector.y, NowVector.x - StartVector.x) * Mathf.Rad2Deg + 180;

        playerDataContainer._Transform.rotation = Quaternion.Euler(0, -Degree, 0);

    }

    public virtual void OnPointerDown(PointerEventData ped)
    {
        StartVector = Vector3.zero;
        OnDrag(ped);
        playerDataContainer._Model.GetComponent<PlayerBehaviour>().PlayerAni.ChangeAni(PlayerState.Run);
    }

    public virtual void OnPointerUp(PointerEventData ped)
    {
        DisDrag = false;
        InputVector = Vector3.zero;
        JoystickImg.rectTransform.anchoredPosition = Vector3.zero;

        //playerManager.Idle();
        playerDataContainer._Model.GetComponent<PlayerBehaviour>().PlayerAni.ChangeAni(PlayerState.Idle);
    }

    public void InitPos()
    {
        DisDrag = false;
        InputVector = Vector3.zero;
        JoystickImg.rectTransform.anchoredPosition = Vector3.zero;

    }
    
    private void FixedUpdate()
    {
        playerDataContainer._Model.GetComponent<PlayerBehaviour>().Move(new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0));

        if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            playerDataContainer._Model.GetComponent<PlayerBehaviour>().PlayerAni.ChangeAni(PlayerState.Run);
            playerDataContainer._Transform.rotation = Quaternion.Euler(0, -Degree, 0);

            Degree = Mathf.Atan2(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal")) * Mathf.Rad2Deg + 180;
        }
        else if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
        {
            playerDataContainer._Model.GetComponent<PlayerBehaviour>().PlayerAni.ChangeAni(PlayerState.Idle);
        }

        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0))
        {
            weapon.AttackButtonClick(tran);
            playerAttack.Attack();
        }



        if (DisDrag)
        {
            playerDataContainer._Model.GetComponent<PlayerBehaviour>().Move(Direction); // 하드코딩이니까 수정하자
        }
    }
}