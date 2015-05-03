using UnityEngine;
using System.Collections;

public class TreasureChestMover : MonoBehaviour {

    float frame = 0;
    const float moveTime = 1.0f;

	// Use this for initialization
	void Start () {

        MoveTo();
	}

	// Update is called once per frame
	void Update () {
        frame += Time.deltaTime;
        if (frame >= moveTime)
        {
            frame = 0;
            MoveTo();
        }
	}

    void MoveTo()
    {
        var x = Random.Range(-4.0f, 4.0f);
        var y = Random.Range(0.0f, 5.0f);
        var pos = new Vector3(x, y, 0);
        iTween.MoveTo(gameObject, iTween.Hash("position", pos, "time", moveTime, "easetype", iTween.EaseType.easeInBack));
        
    }
}
