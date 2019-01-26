using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSkills : MonoBehaviour
{
    public int knowledge = 10;
    public int social = 10;
    public int kindness = 10;
    public int experience = 10;

    public Text[] texts = new Text[4];

    public void setSkill(Skill skill, int amount = 1)
    {
        switch (skill)
        {
            case Skill.knowledge:
                this.knowledge += amount;
                texts[0].text = "Knowledge: " + knowledge.ToString() + "/100";
                break;
            case Skill.social:
                this.social += amount;
                texts[1].text = "Social: " + social.ToString() + "/100";
                break;
            case Skill.kindness:
                this.kindness += amount;
                texts[2].text = "Kindness: " + kindness.ToString() + "/100";
                break;
            case Skill.experience:
                this.experience += amount;
                texts[3].text = "Experience: " + experience.ToString() + "/100";
                break;
        }
    }
}
