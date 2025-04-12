using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDamage : MonoBehaviour
{

    public GameObject ghost;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player");
        this.gameObject.SetActive(false);
    }

    public void Hit()
    {
        Transform gtf = ghost.transform;
        PlayerController plc = player.GetComponent<PlayerController>();
        int p = plc.vec;
        this.gameObject.transform.position = gtf.position;
        if (p == 0)
        {
            this.gameObject.transform.position += new Vector3(0, 1,0);
        }
        else if (p == 1)
        {
            this.gameObject.transform.position += new Vector3(1, 0, 0);
        }
        else if (p == 2)
        {
            this.gameObject.transform.position += new Vector3(-1, 0, 0);
        }
        else
        {
            this.gameObject.transform.position += new Vector3(0, -1, 0);
        }
        gameObject.SetActive(true);
        StartCoroutine(ColHit());
        ColHit();
    }

    IEnumerator ColHit()
    {
        yield return new WaitForSeconds(0.2f);
        gameObject.SetActive(false);
    }
}
