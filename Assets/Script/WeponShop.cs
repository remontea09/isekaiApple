using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeponShop : MonoBehaviour
{
    public GameObject GameObject;
    bukiyaBotton botton;

    private void Start()
    {
        botton = gameObject.GetComponent<bukiyaBotton>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            botton.enter = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
           botton.enter = false;
        }
    }
}