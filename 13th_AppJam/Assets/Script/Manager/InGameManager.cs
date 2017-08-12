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

    private void Awake()
    {
        instance = this;
    }

    #region Sheet

    public CharacterSheet CharacterSheet_readonly { get { return characterSheet; } }

    #endregion
}