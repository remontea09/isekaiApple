using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class OnAttack : MonoBehaviour
{

    bool a = false; //�U���������邩�ǂ����̔���
    public AudioClip attackSound;
    AudioSource atks;
    public GameObject player;
    PlayerController pc;

    void Start()
    {
        atks = GetComponent<AudioSource>();
        pc = player.GetComponent<PlayerController>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        a = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        a = false;
    }


    public void Attack()
    {
        if (a == true)
        {
            atks.PlayOneShot(attackSound);
            pc.hp -= 1;
        }
    }


}
