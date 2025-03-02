using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GhostMove : MonoBehaviour
{

    GameObject player;
    Transform ghostTF;
    Transform playerTF;
    float ghostx;
    float ghosty;
    float playerx;
    float playery;
    float speed; //’Ç”ö‘¬“x

    // Start is called before the first frame update
    void Start()
    {
        speed = 0.1f;
        player = GameObject.FindWithTag("Player");
        playerTF = player.GetComponent<Transform>();
        ghostTF = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        ghostx = ghostTF.transform.position.x;
        ghosty = ghostTF.transform.position.y;
        playerx = playerTF.transform.position.x;
        playery = playerTF.transform.position.y;
        float x = Mathf.Abs(ghostx - playerx);
        float y = Mathf.Abs(ghosty - playery);

        if(x > 4 || y > 4)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerTF.position, speed);
        }
    }
}
