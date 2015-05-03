using UnityEngine;
using System.Collections;

public class FadeController : MonoBehaviour {

    [SerializeField]
    float interval = 3.0f;

    Texture2D backGround = null;
    float fadeAlpha = 1;
    float time = 0;

    enum State
    {
        None,
        FadeIn,
        FadeOut,
    };

    State FadingState = State.None;

	// Use this for initialization
	void Start () {
        backGround = new Texture2D(32, 32, TextureFormat.RGB24, false);
        backGround.SetPixel(0, 0, Color.white);
        backGround.Apply();

        FadingState = State.FadeIn;
	}

    void OnGUI()
    {
        if (FadingState == State.None) return;

        GUI.color = new Color(1, 1, 1, fadeAlpha);
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), backGround);
    }

    public void StartFading()
    {
        if (FadingState != State.None) return;

        FadingState = State.FadeOut;
    }
	
	// Update is called once per frame
	void Update () 
    {
        if (FadingState == State.FadeOut)
        {
            FadeAlphaMoveTo(0, 1);
            FadeEnd(State.FadeIn);

        }
        else if (FadingState == State.FadeIn)
        {
            FadeAlphaMoveTo(1, 0);
            FadeEnd(State.None);
        }
	}

    void FadeEnd(State state)
    {
        if (time >= interval)
        {
            FadingState = state;
            time = 0;
        }
    }

    void FadeAlphaMoveTo(float start,float end)
    {
        fadeAlpha = Mathf.Lerp(start, end, time / interval);
        time += Time.deltaTime;
    }
}
