using UnityEngine;

public class InGameManager : MonoBehaviour
{
    private static InGameManager instance = null;
    public static InGameManager Instance
    {
        get
        {
            if (instance)
                return instance;
            else
                return instance = new GameObject("InGameManager").AddComponent<InGameManager>();
        }
    }

    [SerializeField]
    private CharacterSheet characterSheet;

    [SerializeField]
    private PlayerDataContainer playerDataContainer;

    private void Awake()
    {
        instance = this;

        _PlayerDataContainer = playerDataContainer;
    }

    #region DataContainer

    public PlayerDataContainer _PlayerDataContainer { set; get; }

    #endregion

    #region Sheet

    public CharacterSheet CharacterSheet_readonly { get { return characterSheet; } }

    #endregion
}