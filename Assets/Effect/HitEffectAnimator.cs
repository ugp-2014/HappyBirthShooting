using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HitEffectAnimator : MonoBehaviour {

    [SerializeField]
    List<Sprite> spriteList = new List<Sprite>();

    [SerializeField]
    int changeFrame = 10;


    SpriteRenderer spriteRenderer = null;

    int frame = 0;
    int index = 0;

	// Use this for initialization
	void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = spriteList[index];
	}
	
	// Update is called once per frame
	void Update () {
	    frame++;
        if (frame >= changeFrame)
        {
            frame = 0;
            SpriteIndexLimit();
            spriteRenderer.sprite = spriteList[index];
        }
	}

    void SpriteIndexLimit()
    {
        index++;
        if (index >= spriteList.Count - 1)
        {
            Destroy(gameObject);
        }
    }
}
