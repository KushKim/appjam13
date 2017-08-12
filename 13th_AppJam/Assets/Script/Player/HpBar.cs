using UnityEngine.UI;
using UnityEngine;

public class HpBar : MonoBehaviour
{
    private CharacterSheet characterSheet;

    private Image image;
    
    void Start()
    {
        image = transform.GetComponent<Image>();

        characterSheet = InGameManager.Instance.CharacterSheet_readonly;
    }

    public void UpdateHpBar(float hp)
    {
        image.fillAmount = hp / 100f;
    }
}
