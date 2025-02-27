using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeponShopOut : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
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

    public void OnClick()
    {
        player.transform.position = new Vector3(-25, 0, 0);
    }
}
