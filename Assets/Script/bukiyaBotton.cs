using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bukiyaBotton : MonoBehaviour
{

    LoadScene scene;
    public bool enter = false;

    // Start is called before the first frame update
    void Start()
    {
        scene = GetComponent<LoadScene>();
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




    void OnClikc()
    {
        scene.bukiyaLoad();
    }

}
