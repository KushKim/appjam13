using UnityEngine.UI;
using UnityEngine;

public class HpBar : MonoBehaviour
{
    private CharacterSheet characterSheet;

    private Image image;

    private float PlayerHp;

    void Start()
    {
        image = transform.GetComponent<Image>();

        characterSheet = InGameManager.Instance.CharacterSheet_readonly;
        PlayerHp = characterSheet.m_data[0].hp;
    }

    public void UpdateHpBar(float hp)
    {
        image.fillAmount = hp / 100f;
    }
}
