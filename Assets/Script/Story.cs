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
        sinkoudo = 0;//進行度がゼロ
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
            //以下会話イベント
            playerImage.SetActive(true);
            playerText.text = "草原に来たぞ！";
            await UniTask.WaitUntil(() => Input.GetMouseButtonDown(0));
            playerText.text = "けどよく考えたら武器がないから攻撃できないな……";
            await UniTask.WaitUntil(() => Input.GetMouseButtonDown(0));
            playerText.text = "いや、待てよ";
            await UniTask.WaitUntil(() => Input.GetMouseButtonDown(0));
            playerText.text = "俺にはこの体があるじゃないか！";
            await UniTask.WaitUntil(() => Input.GetMouseButtonDown(0));
            playerText.text = "幽霊にタックルしまくって倒してやろう！！";
            await UniTask.WaitUntil(() => Input.GetMouseButtonDown(0));
            playerImage.SetActive(false);
            pc.CMtrue();
            ghostMove.Attack();
        }
    }

    public async void StoryStart()
    {
        pc.CMfalse();
        pos = new Vector2(-1.72f, -1.73f); //ヒロインの前に移動
        plt.transform.position = pos;
        playerBack.SetActive(true);
        playerImage.SetActive(true);
        playerText.text = "僕と結婚してください！";
        await UniTask.WaitUntil(() => Input.GetMouseButtonDown(0));
        playerImage.SetActive(false);
        heroineImage.SetActive(true);
        heroineText.text = "うーん……";
        await UniTask.WaitUntil(() => Input.GetMouseButtonDown(0));
        heroineText.text = "じゃあ、指輪を持ってきてくれたらいいわよ";
        await UniTask.WaitUntil(() => Input.GetMouseButtonDown(0));
        heroineImage.SetActive(false);
        playerImage.SetActive(true);
        playerText.text = "指輪かあ……";
        await UniTask.WaitUntil(() => Input.GetMouseButtonDown(0));
        playerText.text = "確か幽霊の素材を武器屋に持っていけば作れたはずだ";
        await UniTask.WaitUntil(() => Input.GetMouseButtonDown(0));
        playerText.text = "幽霊は街の西にある草原にいたはず";
        await UniTask.WaitUntil(() => Input.GetMouseButtonDown(0));
        playerText.text = "そうと決まれば早速出発だ！";
        await UniTask.WaitUntil(() => Input.GetMouseButtonDown(0));
        playerImage.SetActive(false);
        playerBack.SetActive(false);
        pc.CMtrue();
        player.SetActive(true);
        sinkoudo = 1;
    }
}
