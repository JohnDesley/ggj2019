using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    public int money = 0;
    public int scraps = 0;
    public Item[] items = new Item[6];

    public Text[] texts = new Text[2];

    public Text winText;
    private bool hasWon = false;

    private void Update()
    {
        if(money >= 300 && !hasWon) {
            winText.text = "YOU MADE ENOUGH MONEY TO RENT A HOUSE";
            hasWon = true;
        }
    }

    public void setCurrency(Currency currency, int amount = 1)
    {
        switch (currency)
        {
            case Currency.scraps:
                this.scraps += amount;
                texts[0].text = "Scraps: " + scraps.ToString();
                break;
            case Currency.money:
                this.money += amount;
                texts[1].text = "Money: $" + money.ToString();
                break;
        }
    }
}
