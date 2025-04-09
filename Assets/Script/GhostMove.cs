using Cysharp.Threading.Tasks;
using System;
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
    float speed; //�ǔ����x
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
    async UniTask Update()
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
        else�@//�ړ����Ă��Ȃ���΍U���@�ړ��t���O�̗��ĕ���ς���
        {
            attack = true;
        }

        if(hp == 0)//���S���\�b�h
        {
            Dead();
        }

        if(attack == true)//�U�����\�b�h���Ăяo�� debug.log���ォ�����
        {

            var token = this.GetCancellationTokenOnDestroy();

            if (playerx < ghostx)//�v���C���[���H���荶���ɂ��邱�Ƃ��m��
            {

                if (playery > ghosty - 1.0f && playery < ghosty + 1.0f)//�v���C���[�������ɂ���
                {
                    Debug.Log("Left");
                    attackLeft.SetActive(true);
                    await UniTask.Delay(TimeSpan.FromSeconds(1f), cancellationToken: token);
                    atL.Attack();
                    attackLeft.SetActive(false);
                    await UniTask.Delay(TimeSpan.FromSeconds(1f), cancellationToken: token);
                }
                else if (playery < ghosty + 1.0f)//�v���C���[�������ɂ���
                {
                    Debug.Log("under");
                    attackFront.SetActive(true);
                    await UniTask.Delay(TimeSpan.FromSeconds(1f), cancellationToken: token);
                    atF.Attack();
                    attackFront.SetActive(false);
                    await UniTask.Delay(TimeSpan.FromSeconds(1f), cancellationToken: token);
                }
                else //�v���C���[���㑤�ɋ���
                {
                    Debug.Log("up");
                    attackBack.SetActive(true);
                    await UniTask.Delay(TimeSpan.FromSeconds(1f), cancellationToken: token);
                    atB.Attack();
                    attackBack.SetActive(false);
                    await UniTask.Delay(TimeSpan.FromSeconds(1f), cancellationToken: token);
                }
            }
            else if (playerx > ghostx)//�v���C���[���H����E���ɂ��邱�Ƃ��m��
            {
                if (playery > ghosty - 1.0f && playery < ghosty + 1.0f)//�v���C���[���E���ɂ���
                {
                    Debug.Log("right");
                    attackRight.SetActive(true);
                    await UniTask.Delay(TimeSpan.FromSeconds(1f), cancellationToken: token);
                    atR.Attack();
                    attackRight.SetActive(false);
                    await UniTask.Delay(TimeSpan.FromSeconds(1f), cancellationToken: token);
                }
                else if (playery < ghosty + 1.0f)//�v���C���[�������ɂ���
                {
                    Debug.Log("under");
                    attackFront.SetActive(true);
                    await UniTask.Delay(TimeSpan.FromSeconds(1f), cancellationToken: token);
                    atF.Attack();
                    attackFront.SetActive(false);
                    await UniTask.Delay(TimeSpan.FromSeconds(1f), cancellationToken: token);
                }
                else //�v���C���[���㑤�ɋ���
                {
                    Debug.Log("up");
                    attackBack.SetActive(true);
                    await UniTask.Delay(TimeSpan.FromSeconds(1f), cancellationToken: token);
                    atB.Attack();
                    attackBack.SetActive(false);
                    await UniTask.Delay(TimeSpan.FromSeconds(1f), cancellationToken: token);
                }
            }
        }
        else if(attack == false)
        {
            attackBack.SetActive(false);
            attackFront.SetActive(false);
            attackLeft.SetActive(false);
            attackRight.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            //player�̃m�b�N�o�b�N�A�q�b�g���ƃG�t�F�N�g
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
        //ghost�̑f�ނ���肳����
    }
}
