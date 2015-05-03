using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class StageManager : MonoBehaviour {

    [System.Serializable]
    struct StageData
    {
        StageData(GameObject enemy,Sprite sprite):this()
        {
            this.enemy = enemy;
            backGround = sprite;
        }

        public GameObject enemy ;
        public Sprite backGround ;
    }

    [SerializeField]
    Image backGroundImage = null;

    [SerializeField]
    FadeController fade = null;

    [SerializeField]
    NavigatorController navi = null;

    [SerializeField]
    List<StageData> stageList = new List<StageData>();


    EnemySinkingMover enemySinkingMover = null;
    EnemyHitPointManager enemyHpManager = null;

    int stageIndex = 0;
    static public bool IsBonus { get; private set; }

	// Use this for initialization
	void Awake () 
    {
        Application.targetFrameRate = 30;
        Create();
        IsBonus = false;
	}
	
	// Update is called once per frame
	void Update () {
        NextStage();
        EnemyShinking();
	}

    void NextStage()
    {
        if (IsBonus) return;
        if (!enemySinkingMover.IsSinking) return;

        stageIndex++;
        backGroundImage.sprite = stageList[stageIndex].backGround;
        StartBonus();

        enemySinkingMover.Destory();
        Create();
    }

    void StartBonus()
    {
        if (stageIndex >= stageList.Count - 1)
        {
            IsBonus = true;
            var enemy = stageList[stageIndex].enemy;
            var clone = (GameObject)Instantiate(enemy, enemy.transform.position, Quaternion.identity);
            clone.name = enemy.name;
        }
    }

    void EnemyShinking()
    {
        if (IsBonus) return;
        if (!enemyHpManager.IsDes) return;
     
        fade.StartFading();
    }

    void Create()
    {
        if (IsBonus) return;
        navi.Play();

        var enemy = stageList[stageIndex].enemy;
        var clone = (GameObject)Instantiate(enemy, enemy.transform.position, Quaternion.identity);
        clone.name = enemy.name;
        enemySinkingMover = clone.GetComponent<EnemySinkingMover>();
        enemyHpManager = clone.GetComponent<EnemyHitPointManager>();

    }
}
