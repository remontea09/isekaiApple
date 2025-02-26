using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 0.02f;
    private Animator animator;
    public bool CMStatus = true;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (CMStatus == true)
        {
            Vector2 pos = transform.position;

            if (Input.GetKey(KeyCode.S))//���L�[����������
            {
                pos.y -= speed;
                animator.SetInteger("direction", 0);//���ʂ�����
            }
            else if (Input.GetKey(KeyCode.A))//���L�[����������
            {

                pos.x -= speed;
                animator.SetInteger("direction", 1);//��������
            }
            else if (Input.GetKey(KeyCode.D))//���L�[����������
            {
                pos.x += speed;
                animator.SetInteger("direction", 2);//�E������

            }
            else if (Input.GetKey(KeyCode.W))//���L�[����������
            {
                pos.y += speed;
                animator.SetInteger("direction", 3);//��������
            }
            else
            {
                animator.SetInteger("direction", -1);
            }
            transform.position = pos;
        }
    }

    public void CMtrue()
    {
        CMStatus = true;
    }

    public void CMfalse()
    {
        CMStatus = false;
    }
}