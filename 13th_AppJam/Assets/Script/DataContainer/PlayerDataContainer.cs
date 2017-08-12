using UnityEngine;

public class PlayerDataContainer : MonoBehaviour
{
    [SerializeField]
    private string firstPlayerName;

    [SerializeField]
    private Transform playerGroup;

    private CharacterSheet characterSheet;

    private void Awake()
    {
        characterSheet = InGameManager.Instance.CharacterSheet_readonly;

        ChangeCharacter(firstPlayerName);
    }

    public GameObject _Model { set; get; }
    public Transform _Transform { set; get; }
    public Rigidbody _Rigidbody { set; get; }

    public string CharacterName { get; set; }

    public void ChangeCharacter(string characterName)
    {
        CharacterName = characterName;

        GameObject character = new GameObject();

        for (int i = 0; i < characterSheet.m_data.Count; i++)
        {
            if(characterSheet.m_data[i].name == characterName)
                character = characterSheet.m_data[i].prefab;
        }

        _Model = character.gameObject;
        _Transform = character.transform;
        _Rigidbody = character.GetComponent<Rigidbody>();
    }
}