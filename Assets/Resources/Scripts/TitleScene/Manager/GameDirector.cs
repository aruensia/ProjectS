using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    static GameDirector instance;
    public OutgameManager outgameManager;
    public InputController inputController;
    public DataConteiner dataConteiner;
    public PlayerData playerData = new PlayerData();
    public Player player;

    //GameDirector의 생성자로써, 게임에 영향을 주는 클래스는 instance를 통해서만 접근할 수 있음.
    public static GameDirector Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        inputController = GetComponent<InputController>();

        player.Init(playerData);

        Debug.Log("싱글턴 매니저 실행");
        Debug.Log(player.playerData);
    }

    public void InitIngameManager(OutgameManager _ingamemanager)
    {
        inputController.ingameManager = _ingamemanager;
    }

   
}
