using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyHitPointManager : MonoBehaviour {

    [SerializeField]
    float maxHp = 10;

    float hp = 0;

    [SerializeField]
    EnemyGuageController guage = null;

    public bool IsDes { get; private set; }

    SEPlayer sePlayer = null;

    void Start()
    { 
        IsDes = false;
        hp = maxHp;
        sePlayer = FindObjectOfType(typeof(SEPlayer)) as SEPlayer;
    }

    public void Damage(int damageValue)
    {
        if (IsDes) return;

        hp -= damageValue;
        
        var percent = hp / maxHp;
        guage.Damage(percent);

        HitSoundPlay();
        Dying();
    }

    int playFrame = 0;

    void HitSoundPlay()
    {
        playFrame++;
        if (playFrame >= 2)
        {
            playFrame = 0;
            sePlayer.Play("Hit");
        }
    }

    /// <summary>
    /// 死んでいくようにする
    /// </summary>
    void Dying()
    {
        if (hp >= 0) return;

        IsDes = true;

        var voiceCreator = GetComponent<EnemyVoiceCreator>();
        voiceCreator.DesVoicePlay();

        sePlayer.Play("Explosive");

        foreach (Transform children in gameObject.transform)
        {
            GameObject.Destroy(children.gameObject);
        }
    }
}
