using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBarUI : MonoBehaviour
{
    [SerializeField] private Character character;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private Image healthBarFill;

    private void OnEnable()
    {
        character.onTakeDamage += UpdateHealthBar;
        character.onHeal += UpdateHealthBar;
    }

    private void OnDisable()
    {
        character.onTakeDamage -= UpdateHealthBar;
        character.onHeal -= UpdateHealthBar;
    }

    private void Start()
    {
        SetNameText(character.DisplayName);
    }

    void SetNameText (string text)
    {
        nameText.text = text;
    }

    void UpdateHealthBar ()
    {
        float healthPercent = (float)character.CurHp / character.MaxHp;
        healthBarFill.fillAmount = healthPercent;
    }
}
