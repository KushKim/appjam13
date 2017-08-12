using UnityEngine;

public class PlayerDataContainer : MonoBehaviour
{
    [SerializeField]
    private string firstPlayerName;

    [SerializeField]
    private Transform playerGroup;

    [SerializeField]
    private GameObject warriorObject;

    [SerializeField]
    private GameObject magicianObject;


    private bool isWarrior;

    private CharacterSheet characterSheet;

    private void Awake()
    {
        isWarrior = false;

        ChangeCharacter();
    }

    public GameObject _Model { set; get; }
    public Transform _Transform { set; get; }
    public Rigidbody _Rigidbody { set; get; }

    public string CharacterName { get; set; }

    public void ChangeCharacter()
    {
        GameObject character = new GameObject();

        if (isWarrior)
        {
            character = warriorObject;
            warriorObject.SetActive(true);
            magicianObject.SetActive(false);
        }
        else
        {
            character = magicianObject;
            warriorObject.SetActive(false);
            magicianObject.SetActive(true);
        }

        _Model = character.gameObject;
        _Transform = character.transform;
        _Rigidbody = character.GetComponent<Rigidbody>();

        isWarrior = !isWarrior;
    }
}