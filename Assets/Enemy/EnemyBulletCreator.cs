using UnityEngine;
using System.Collections;

public class EnemyBulletCreator : MonoBehaviour {


    [SerializeField]
    GameObject bullet = null;

    enum State
    {
        None,
        Vertical,
        Slanting,
        Radiation,
    }
    State state = State.None;

    float axisX = 1.0f;

    public void SetVerticalBehaviour()
    {
        state = State.Vertical;
    }

    public void SetSlantingBehaviour()
    {
        state = State.Slanting;
    }

    public void SetRadiationBehaviour()
    {
        state = State.Radiation;
    }


    public void Create()
    {
        switch (state)
        { 
            case State.Vertical:
                VerticalMove();
                break;

            case State.Slanting:
                SlantingMove();
                break;

            case State.Radiation:
                RadiationMove();
                break;
        }


    }

    void RadiationMove()
    {
        const int num = 2;
        for (int i = -num / 2; i < num / 2; i++)
        {
            var clone = Instantiate(bullet, transform.position, Quaternion.identity) as GameObject;
            clone.name = bullet.name;
            var radiation = clone.GetComponent<RadiationBulletMover>();
            radiation.enabled = true;
            radiation.SetVelocity(new Vector2(i, -5));
        }
    }

    void VerticalMove()
    {
        var clone = Instantiate(bullet, transform.position, Quaternion.identity) as GameObject;
        clone.name = bullet.name;

        clone.GetComponent<VercitalBulletMover>().enabled = true;
    }

    void SlantingMove()
    {
        var clone = Instantiate(bullet, transform.position, Quaternion.identity) as GameObject;
        clone.name = bullet.name;

        var slanting = clone.GetComponent<SlantingBulletMover>();
        slanting.enabled = true;
        slanting.SetVelocityAxisX(axisX);
        axisX *= -1;
    }
}
