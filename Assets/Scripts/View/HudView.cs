using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudView : MonoBehaviour
{
    public Text MoneyText;
    public Text BasehealthText;
    public void SetMoney(int value)
    {
        MoneyText.text = value.ToString();

    }
    public void SetHealth(int value)
    {
        BasehealthText.text = value.ToString();
    }
    public void ShowHud()
    {
        Debug.Log("hud");
        gameObject.SetActive(true);
    }
    public void HideHud() {
        gameObject.SetActive(false);
    }
}
