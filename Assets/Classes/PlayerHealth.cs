using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int depression = 0;

    public Text depressionText;

    public Text loseText;
    private bool hasLost = false;

    private void Start()
    {
        InvokeRepeating("DepressionUp", 2.0f, 3.33f);
    }

    private void Update()
    {
        if (depression >= 300 && !hasLost)
        {
            loseText.text = "TOO DEPRESSED TO CARE";
            hasLost = true;
        }
    }

    void DepressionUp() {
        depression += 1;
        depression = Mathf.Min(depression, 100);
        depressionText.text = "Depression: " + depression.ToString() + "/100";
    }
}
