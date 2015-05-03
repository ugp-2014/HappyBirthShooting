using UnityEngine;
using System.Collections;

public class CheeringVoiceManager : MonoBehaviour {

    [SerializeField]
    VoicePlayer voicePlayer = null;

    [SerializeField]
    int maxNum = 11;

    [SerializeField]
    float nextTime = 0;

    int playNum = 0;
    float time = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        if (time >= nextTime)
        {
            time = 0;
            playNum = Random.Range(1, maxNum);
            voicePlayer.Play("Cheer_" + playNum);
        }
	}
}
