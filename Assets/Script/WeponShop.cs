using System.Collections;
using System.Collections.Generic;
using UnityEditor;
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


    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            botton.enter = true;
            Debug.Log("true");
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
           Debug.Log("false");
           botton.enter = false;
        }
    }
}