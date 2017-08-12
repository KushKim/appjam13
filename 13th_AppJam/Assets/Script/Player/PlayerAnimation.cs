using UnityEngine;

public enum PlayerState
{
    Idle,
    Run,
    Attack
}

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField]
    private Animator playerAni;

    private PlayerState prevState = PlayerState.Idle;

    private void OnEnable()
    {
        prevState = PlayerState.Idle;
    }

    public void ChangeAni(PlayerState state)
    {
        if (prevState == state)
            return;

        StopAni();

        switch (state)
        {
            case PlayerState.Idle:
                break;

            case PlayerState.Run:
                playerAni.SetBool("isRun", true);
                break;

            case PlayerState.Attack:
                playerAni.SetTrigger("isAttack");
                break;

            default:
                Debug.LogError("Switch / Out of Range");
                break;
        }

        prevState = state;
    }

    public void StopAni()
    {
        switch (prevState)
        {
            case PlayerState.Idle:
                break;

            case PlayerState.Run:
                playerAni.SetBool("isRun", false);
                break;

            case PlayerState.Attack:
                break;

            default:
                Debug.LogError("Switch / Out of Range");
                break;
        }
    }
}