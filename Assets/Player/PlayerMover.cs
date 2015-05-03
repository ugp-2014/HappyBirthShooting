using UnityEngine;
using System.Collections;

public class PlayerMover : MonoBehaviour {

    [SerializeField]
    float horizontalSpeed = 1.0f;
    
    [SerializeField]
    float moveTime = 1;

    float velocitySpeed = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        velocitySpeed = horizontalSpeed * Time.deltaTime;

        HorizontalMove();
        MovingRange();

        MoveByTap();
	}

    void MoveByTap()
    {
        if (!Input.GetMouseButton(0)) return;

        var tapPosition = Input.mousePosition;
        tapPosition.z = 10;
        var x = Camera.main.ScreenToWorldPoint(tapPosition).x;
        iTween.MoveTo(gameObject, new Vector3(x, transform.position.y, 0), moveTime);
    }

    void HorizontalMove()
    {
        var velocityX = Input.GetAxis("Horizontal") * velocitySpeed;

        transform.Translate(velocityX, 0, 0);
    }

    void MovingRange()
    {
        var screenPos = Camera.main.WorldToScreenPoint(transform.position);
        if (screenPos.x <= 0 + transform.lossyScale.x * 50)
        {
            transform.Translate(velocitySpeed, 0, 0);
        }
        if (screenPos.x >= Screen.width - transform.lossyScale.x * 50)
        {
            transform.Translate(-velocitySpeed, 0, 0);
        }

    }
}
