using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeponShopOutPh : MonoBehaviour
{
    public GameObject cv;
    WeponShopOut botton;

    private void Start()
    {
        botton = cv.GetComponent<WeponShopOut>();
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
