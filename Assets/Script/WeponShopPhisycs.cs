using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeponShopPhisycs : MonoBehaviour
{
    public GameObject cv;
    WeponShopTolkButton button;

    private void Start()
    {
        button = cv.GetComponent<WeponShopTolkButton>();
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            button.ButtonA();
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            button.ButtonF();
        }
    }
}
