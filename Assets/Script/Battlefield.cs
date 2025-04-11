using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Battlefield : MonoBehaviour
{

    public GameObject BFButton;
    ChangeSceneButton button;


    // Start is called before the first frame update
    void Start()
    {
        button = BFButton.GetComponent<ChangeSceneButton>();
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
