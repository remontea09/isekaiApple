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
    public GameObject hitDamage;
    HitDamage hitdamage;
    public int hp;
    public GameObject attackFront;
    public GameObject attackBack;
    public GameObject attackRight;
    public GameObject attackLeft;
    bool attack;
    OnAttack atF;
    OnAttack atB;
    OnAttack atR;
    OnAttack atL;

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
        hitdamage = hitDamage.GetComponent<HitDamage>();
        hp = 100;
        attackFront.SetActive(false);
        attackBack.SetActive(false);
        attackRight.SetActive(false);
        attackLeft.SetActive(false);
        atF = attackFront.GetComponent<OnAttack>();
        atB = attackBack.GetComponent<OnAttack>();
        atR = attackRight.GetComponent<OnAttack>();
        atL = attackLeft.GetComponent<OnAttack>();
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
            attack = false;
        }
        else　//移動していなければ攻撃
        {
            attack = true;
        }

        if(hp == 0)//死亡メソッド
        {
            Dead();
        }

        if(attack == true)//攻撃メソッドを呼び出す debug.logを後から消す
        {

            if (playerx < ghostx)//プレイヤーが幽霊より左側にいることが確定
            {
                if (playery > ghosty - 1.0f && playery < ghosty + 1.0f)//プレイヤーが左側にいる
                {
                    Debug.Log("Left");
                    attackLeft.SetActive(true);
                    atL.Attack();
                }
                else if (playery < ghosty + 1.0f)//プレイヤーが下側にいる
                {
                    Debug.Log("under");
                    attackFront.SetActive(true);
                    atF.Attack();
                }
                else //プレイヤーが上側に居る
                {
                    Debug.Log("up");
                    attackBack.SetActive(true);
                    atB.Attack();
                }
            }
            else if (playerx > ghostx)//プレイヤーが幽霊より右側にいることが確定
            {
                if (playery > ghosty - 1.0f && playery < ghosty + 1.0f)//プレイヤーが右側にいる
                {
                    Debug.Log("right");
                    attackRight.SetActive(true);
                    atR.Attack();
                }
                else if (playery < ghosty + 1.0f)//プレイヤーが下側にいる
                {
                    Debug.Log("under");
                    attackFront.SetActive(true);
                    atF.Attack();
                }
                else //プレイヤーが上側に居る
                {
                    Debug.Log("up");
                    attackBack.SetActive(true);
                    atB.Attack();
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            //playerのノックバック、ヒット音とエフェクト
            if(pc.vec == 0)
            {
                collision.gameObject.transform.Translate(0, 1, 0);
                plDamageSound.PlayOneShot(plDamage);
                hitdamage.Hit();
                hp -= 1;
            }
            else if (pc.vec == 1)
            {
                collision.gameObject.transform.Translate(1, 0, 0);
                plDamageSound.PlayOneShot(plDamage);
                hitdamage.Hit();
                hp -= 1;
            }
            else if(pc.vec == 2)
            {
                collision.gameObject.transform.Translate(-1, 0, 0);
                plDamageSound.PlayOneShot(plDamage);
                hitdamage.Hit();
                hp -= 1;
            }
            else if(pc.vec == 3)
            {
                collision.gameObject.transform.Translate(0, -1, 0);
                plDamageSound.PlayOneShot(plDamage);
                hitdamage.Hit();
                hp -= 1;
            }
        }
    }

    private void Dead()
    {
        Destroy(this.gameObject);
    }
}
