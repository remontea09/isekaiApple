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

            if (Input.GetKey(KeyCode.S))//↓キーを押したら
            {
                pos.y -= speed;
                animator.SetInteger("direction", 0);//正面を向く
            }
            else if (Input.GetKey(KeyCode.A))//←キーを押したら
            {

                pos.x -= speed;
                animator.SetInteger("direction", 1);//左を向く
            }
            else if (Input.GetKey(KeyCode.D))//→キーを押したら
            {
                pos.x += speed;
                animator.SetInteger("direction", 2);//右を向く

            }
            else if (Input.GetKey(KeyCode.W))//↑キーを押したら
            {
                pos.y += speed;
                animator.SetInteger("direction", 3);//後ろを向く
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