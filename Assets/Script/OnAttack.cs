using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OnAttack : MonoBehaviour
{

    bool a = false; //UŒ‚‚ª“–‚½‚é‚©‚Ç‚¤‚©‚Ì”»’è
    public AudioClip attackSound;
    AudioSource atks;
    public GameObject player;
    PlayerController pc;

    void Start()
    {
        atks = GetComponent<AudioSource>();
        pc = player.GetComponent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        a = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        a = false;
    }


    public void Attack()
    {
        if(a == true)
        {
            atks.PlayOneShot(attackSound);
            pc.hp -= 1;
        }

        //ƒRƒ‹[ƒ`ƒ“‚ÅSetActiv(false)‚ğ’x‚ç‚¹‚é
        //this.gameObject.SetActive(false);
    }


}
