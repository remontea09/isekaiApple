using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using Cysharp.Threading.Tasks;
using Unity.VisualScripting;

public class Story : MonoBehaviour
{

    public GameObject player;
    PlayerController pc;
    Transform plt;
    Vector2 pos;
    public GameObject heroineImage;
    public GameObject playerImage;
    public TextMeshProUGUI heroineText;
    public TextMeshProUGUI playerText;
    int sinkoudo;
    public GameObject playerBack;
    public GameObject ghost;
    GhostMove ghostMove;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        pc = player.GetComponent<PlayerController>();
        plt = pc.GetComponent<Transform>();
        heroineImage.SetActive(false);
        playerImage.SetActive(false);
        sinkoudo = 0;//�i�s�x���[��
        SceneManager.sceneLoaded += SceneLoaded;
        StoryStart();
    }

    async void SceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if(sinkoudo == 1)
        {
            ghost = GameObject.Find("Ghost");
            ghostMove = ghost.GetComponent<GhostMove>();
            pos = new Vector2 (0, -1.52f);
            plt.transform.position = pos;
            pc.CMfalse();
            //�ȉ���b�C�x���g
            playerImage.SetActive(true);
            playerText.text = "�����ɗ������I";
            await UniTask.WaitUntil(() => Input.GetMouseButtonDown(0));
            playerText.text = "���ǂ悭�l�����畐�킪�Ȃ�����U���ł��Ȃ��ȁc�c";
            await UniTask.WaitUntil(() => Input.GetMouseButtonDown(0));
            playerText.text = "����A�҂Ă�";
            await UniTask.WaitUntil(() => Input.GetMouseButtonDown(0));
            playerText.text = "���ɂ͂��̑̂����邶��Ȃ����I";
            await UniTask.WaitUntil(() => Input.GetMouseButtonDown(0));
            playerText.text = "�H��Ƀ^�b�N�����܂����ē|���Ă�낤�I�I";
            await UniTask.WaitUntil(() => Input.GetMouseButtonDown(0));
            playerImage.SetActive(false);
            pc.CMtrue();
            ghostMove.Attack();
        }
    }

    public async void StoryStart()
    {
        pc.CMfalse();
        pos = new Vector2(-1.72f, -1.73f); //�q���C���̑O�Ɉړ�
        plt.transform.position = pos;
        playerBack.SetActive(true);
        playerImage.SetActive(true);
        playerText.text = "�l�ƌ������Ă��������I";
        await UniTask.WaitUntil(() => Input.GetMouseButtonDown(0));
        playerImage.SetActive(false);
        heroineImage.SetActive(true);
        heroineText.text = "���[��c�c";
        await UniTask.WaitUntil(() => Input.GetMouseButtonDown(0));
        heroineText.text = "���Ⴀ�A�w�ւ������Ă��Ă��ꂽ�炢�����";
        await UniTask.WaitUntil(() => Input.GetMouseButtonDown(0));
        heroineImage.SetActive(false);
        playerImage.SetActive(true);
        playerText.text = "�w�ւ����c�c";
        await UniTask.WaitUntil(() => Input.GetMouseButtonDown(0));
        playerText.text = "�m���H��̑f�ނ𕐊퉮�Ɏ����Ă����΍�ꂽ�͂���";
        await UniTask.WaitUntil(() => Input.GetMouseButtonDown(0));
        playerText.text = "�H��͊X�̐��ɂ��鑐���ɂ����͂�";
        await UniTask.WaitUntil(() => Input.GetMouseButtonDown(0));
        playerText.text = "�����ƌ��܂�Α����o�����I";
        await UniTask.WaitUntil(() => Input.GetMouseButtonDown(0));
        playerImage.SetActive(false);
        playerBack.SetActive(false);
        pc.CMtrue();
        player.SetActive(true);
        sinkoudo = 1;
    }
}
