using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeponShop : MonoBehaviour
{
    public bool enter = false;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            enter = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            enter = false;
        }
    }
}