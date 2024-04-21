using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class UI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI healthText;

    // Start is called before the first frame update
    void Start()
    {
        DisplayText();
    }

    // Update is called once per frame
    void Update()
    {
        DisplayText();
    }

    void DisplayText()
    {
        healthText.text = "Health: " + Player.instance.Health + "\nCurrent damage: " + Player.instance.AttackDamage;
    }
}
