using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Skill { knowledge, social, kindness, experience }

public class SkillController : MonoBehaviour
{
    public Skill skill = Skill.knowledge;

    private bool isInteractable = false;

    public GameObject interactPop;

    private GameObject player;
    private PlayerSkills playerSkills;

    private void Start()
    {
        player = GameObject.Find("Player");
        playerSkills = player.GetComponent<PlayerSkills>();
        setInteractable(false);
    }

    private void Update()
    {
        if(isInteractable && Input.GetKeyUp(KeyCode.E) && playerSkills != null) {
            playerSkills.setSkill(skill);
        }
    }

    private void setInteractable(bool interactable) 
    {
        isInteractable = interactable;
        interactPop.GetComponent<Renderer>().enabled = interactable;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        setInteractable(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        setInteractable(false);
    }
}
