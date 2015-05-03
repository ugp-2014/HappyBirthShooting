using UnityEngine;
using System.Collections;

public class SlantingBulletMover : MonoBehaviour {

    [SerializeField]
    float verticalSpped = 0;

    [SerializeField]
    float horizontalSpeed = 0;

    float axisX = 0;
    Vector2 velocity = Vector2.zero;


    // Use this for initialization
    void Start()
    {
        velocity.x = horizontalSpeed * axisX;
        velocity.y = verticalSpped;

    }

    public void SetVelocityAxisX(float axisX)
    {
        this.axisX = axisX;
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(velocity * Time.deltaTime);

        var screenPos = Camera.main.WorldToScreenPoint(transform.position);
        if (screenPos.y <= 0)
        {
            Destroy(gameObject, 1.0f);
        }
    }
}
