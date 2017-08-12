using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private float moveSpeed;
    public PlayerStatus playerStatus;

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
        Vector3 movement = new Vector3(direction.x, 0, direction.y);

        playerRigid.MovePosition(playerTrans.position + movement * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        playerStatus.Star += 1;
    }
}