using UnityEngine;
using System.Collections;

public class NavigatorController : MonoBehaviour {

    [SerializeField]
    VoicePlayer voicePlayer = null;

    static int stageNum = 1;

    public void Play()
    {
        voicePlayer.Play("Navi_" + stageNum,0.6f);
        stageNum++;
    }
}
