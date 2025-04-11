using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangeSceneButton : MonoBehaviour
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

    public void OnClick()
    {
        SceneManager.LoadScene("Battlefield");
    }
}
