using UnityEngine;
using System.Collections;

public class CanvasSetting : MonoBehaviour {

    Canvas canvas = null;

	// Use this for initialization
	void Start () {
        canvas = GetComponent<Canvas>();
        canvas.worldCamera = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
