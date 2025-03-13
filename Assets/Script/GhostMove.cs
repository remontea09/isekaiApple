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
    float speed; //追尾速度
    Rigidbody2D rb;
    PlayerController pc;
    public AudioClip plDamage;
    AudioSource plDamageSound;

    // Start is called before the first frame update
    void Start()
    {
        speed = 0.1f;
        player = GameObject.FindWithTag("Player");
        playerTF = player.GetComponent<Transform>();
        ghostTF = this.transform;
        rb = player.GetComponent<Rigidbody2D>();
        pc = player.GetComponent<PlayerController>();
        plDamageSound = GetComponent<AudioSource>();

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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            //playercontrollerのノックバック
            if(pc.vec == 0)
            {
                collision.gameObject.transform.Translate(0, 1, 0);
                plDamageSound.PlayOneShot(plDamage);
            }
            else if (pc.vec == 1)
            {
                collision.gameObject.transform.Translate(1, 0, 0);
                plDamageSound.PlayOneShot(plDamage);
            }
            else if(pc.vec == 2)
            {
                collision.gameObject.transform.Translate(-1, 0, 0);
                plDamageSound.PlayOneShot(plDamage);
            }
            else if(pc.vec == 3)
            {
                collision.gameObject.transform.Translate(0, -1, 0);
                plDamageSound.PlayOneShot(plDamage);
            }
        }
    }
}
