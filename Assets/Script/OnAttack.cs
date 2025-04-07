using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

        //�R���[�`����SetActiv(false)��x�点��
        //this.gameObject.SetActive(false);
    }


}
