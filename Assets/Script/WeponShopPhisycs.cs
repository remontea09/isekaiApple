using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeponShopPhisycs : MonoBehaviour
{
    public GameObject cv;
    WeponShopTolkButton botton;

    private void Start()
    {
        botton = cv.GetComponent<WeponShopTolkButton>();
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
