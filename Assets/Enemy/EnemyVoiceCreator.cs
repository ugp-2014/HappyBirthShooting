using UnityEngine;
using System.Collections;

public class EnemyVoiceCreator : MonoBehaviour {

    VoicePlayer voicePlayer = null;

    void Awake()
    {
        voicePlayer = FindObjectOfType(typeof(VoicePlayer)) as VoicePlayer;
    }

    public void StartVoicePlay()
    {
        voicePlayer.Play(name + "_1",0.9f);
    }

    public void DesVoicePlay()
    {
        voicePlayer.Play(name + "_DesVoice",0.9f);
    }
}
