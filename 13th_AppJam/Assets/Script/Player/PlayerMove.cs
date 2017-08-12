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

    public void Move(Vector3 direction, Transform playerTrans, Rigidbody playerRigid)
    {
        float positionY = playerTrans.position.y;

        Vector3 movement = playerTrans.position + (direction * moveSpeed * Time.deltaTime);

        movement = new Vector3(movement.x, positionY, movement.z);

        playerRigid.MovePosition(movement);
    }
}