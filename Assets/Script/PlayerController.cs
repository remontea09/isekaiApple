using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private float speed = 0.02f;
    private Animator animator;
    public bool CMStatus = true;
    public int hp;
    public int vec;

    private void Start()
    {
        animator = GetComponent<Animator>();
        hp = 5;
        vec = 0;
    }

    void Update()
    {
        if (CMStatus == true)
        {
            Vector2 pos = transform.position;

            if (Input.GetKey(KeyCode.S))
            {
                pos.y -= speed;
                animator.SetInteger("direction", 0);
                vec = 0;
            }
            else if (Input.GetKey(KeyCode.A))
            {

                pos.x -= speed;
                animator.SetInteger("direction", 1);
                vec = 1;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                pos.x += speed;
                animator.SetInteger("direction", 2);
                vec = 2;
            }
            else if (Input.GetKey(KeyCode.W))
            {
                pos.y += speed;
                animator.SetInteger("direction", 3);
                vec = 3;
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