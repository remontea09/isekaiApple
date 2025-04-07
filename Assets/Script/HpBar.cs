using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{

    public TextMeshProUGUI enemyHP;
    public TextMeshProUGUI myHP;
    public GameObject ghost;
    public GameObject player;
    GhostMove gm;
    PlayerController pc;
    int iEnemyHP;
    int iMyHP;

    // Start is called before the first frame update
    void Start()
    {
        gm = ghost.GetComponent<GhostMove>();
        pc = player.GetComponent<PlayerController>(); 
    }

    private void Update()
    {
        iEnemyHP = gm.hp;
        iMyHP = pc.hp;
        string e = iEnemyHP.ToString();
        string m = iMyHP.ToString();
        enemyHP.SetText(e);
        myHP.SetText(m);
    }
}
