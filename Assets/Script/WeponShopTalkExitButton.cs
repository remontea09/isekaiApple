using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeponShopTalkExitButton : MonoBehaviour
{

    public GameObject panel;
    GameObject player;
    PlayerController playercnt;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        player = GameObject.FindWithTag("Player");
        playercnt = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        panel.SetActive(false);
        gameObject.SetActive(false);
        playercnt.CMtrue();
    }
}
