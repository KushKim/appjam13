using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private float moveSpeed;

    private PlayerDataContainer playerContainer;

    private CharacterData characterData;
    private CharacterSheet characterSheet;

    private void Awake()
    {
        playerContainer = InGameManager.Instance._PlayerDataContainer;

        characterSheet = InGameManager.Instance.CharacterSheet_readonly;

        for (int i = 0; i < characterSheet.m_data.Count; i++)
        {
            if (characterSheet.m_data[i].name == playerContainer.CharacterName)
                characterData = characterSheet.m_data[i];
        }

        moveSpeed = characterData.moveSpeed;
    }

    public void Move(Vector3 direction)
    {
        playerContainer._Rigidbody.MovePosition(playerContainer._Transform.position + (direction * moveSpeed * Time.deltaTime));
    }
}