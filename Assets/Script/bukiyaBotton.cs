using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bukiyaBotton : MonoBehaviour
{

    LoadScene scene;
    bool enter = false;

    // Start is called before the first frame update
    void Start()
    {

        scene = GetComponent<LoadScene>();
        gameObject.SetActive(false);
    }

    private void Update()
    {

        if (enter)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }



    void OnClikc()
    {
        scene.bukiyaLoad();
    }

}
