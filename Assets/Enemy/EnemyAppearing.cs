using UnityEngine;
using System.Collections;

public class EnemyAppearing : MonoBehaviour {

    [SerializeField]
    float time = 3.0f;


	// Use this for initialization
	void Start () {
        iTween.MoveTo(gameObject, new Vector3(0,5,0), time);

        StartCoroutine("VoiceStart");
	}

    IEnumerator VoiceStart()
    {
        yield return new WaitForSeconds(3.0f);

        var voiceCreator = GetComponent<EnemyVoiceCreator>();
        voiceCreator.StartVoicePlay();
    }
}
