using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class WeponShop : MonoBehaviour
{
    public GameObject cv;
    bukiyaBotton botton;

    private void Start()
    {
        botton = cv.GetComponent<bukiyaBotton>();
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            botton.ButtonA();
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
           botton.ButtonF();
        }
    }
}