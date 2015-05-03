using UnityEngine;
using System.Collections;

public class BulletHitAttacker : MonoBehaviour {

    [SerializeField]
    int attackPower = 1;

    EnemyHitPointManager enemyHpManager = null;
    TreasureChestOpenController treasureChest = null;

	// Use this for initialization
	void Start () {
	}
    void Update()
    {
        if (!enemyHpManager)
        {
            enemyHpManager = GameObject.FindObjectOfType(typeof(EnemyHitPointManager)) as EnemyHitPointManager;
        }

        if (!treasureChest)
        {
            treasureChest = GameObject.FindObjectOfType(typeof(TreasureChestOpenController)) as TreasureChestOpenController;
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        EnemyHitCollision(collision);
        TreasureChestCollision(collision);
    }

    void EnemyHitCollision(Collider collider)
    {
        if (!enemyHpManager) return;

        if (collider.gameObject.name == enemyHpManager.name)
        {
            enemyHpManager.Damage(attackPower);
        }
    }

    void TreasureChestCollision(Collider collider)
    {
        if (!StageManager.IsBonus) return;

        if (collider.gameObject.name == treasureChest.name)
        {
            treasureChest.Open();
        }
    }


}
