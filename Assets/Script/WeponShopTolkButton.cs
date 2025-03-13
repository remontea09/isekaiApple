using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WeponShopTolkButton : MonoBehaviour
{

    public GameObject panel;
    public GameObject button;
    GameObject player;
    PlayerController playercnt;
    public GameObject ringText;
    public GameObject ItemKeeper;
    TextMeshProUGUI ring;
    ItemKeeper itemKeeper;
    int ghost = 0;

    void Start()
    {
        gameObject.SetActive(false);
        player = GameObject.FindWithTag("Player");
        playercnt = player.GetComponent<PlayerController>();
        ring = ringText.GetComponent<TextMeshProUGUI>();
        itemKeeper = ItemKeeper.GetComponent<ItemKeeper>();
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
        panel.SetActive(true);
        button.SetActive(true);
        gameObject.SetActive(false);
        playercnt.CMfalse();
        ghost = itemKeeper.Ghost;
        string a = ghost.ToString();
        ring.SetText(a + "/3");
    }
}
