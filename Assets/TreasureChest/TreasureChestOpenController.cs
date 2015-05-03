using UnityEngine;
using System.Collections;

public class TreasureChestOpenController : MonoBehaviour {

    int hp = 50;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    /// <summary>
    /// URLに飛ぶ
    /// </summary>
    public void Open()
    {
        hp--;
        if (hp >= 0) return;

        Application.OpenURL("https://yosetti.com/mainyosegakis/gift_send_web?id=1422519&sc=r3NZw");
    }
}
