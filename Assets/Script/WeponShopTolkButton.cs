using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeponShopTolkButton : MonoBehaviour
{
    void Start()
    {
        gameObject.SetActive(false);
    }

    public void ButtonA()
    {
        gameObject.SetActive(true);
    }

    public void ButtonF()
    {
        gameObject.SetActive(false);
    }
}
