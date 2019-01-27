using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSkills : MonoBehaviour
{
    public int knowledge = 10;

    public Text knowledgeText;

    public void setKnowledge(int amount = 1)
    {
        this.knowledge += amount;
        this.knowledge = Mathf.Min(this.knowledge, 100);
        knowledgeText.text = "Knowledge: " + knowledge.ToString() + "/100";
    }
}
