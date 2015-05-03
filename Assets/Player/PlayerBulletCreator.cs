using UnityEngine;
using System.Collections;

public class PlayerBulletCreator : MonoBehaviour {

    [SerializeField]
    GameObject bulletParent = null;

    [SerializeField]
    GameObject bullet = null;

    [SerializeField]
    int intervalFrame = 0;

    int frame = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        frame++;
        if (frame >= intervalFrame)
        {
            frame = 0;
            Create();
        }

	}

    void Create()
    {
        var bulletClone = Instantiate(bullet, transform.position + Vector3.up * 0.5f, Quaternion.identity) as GameObject;
        bulletClone.name = bullet.name;
        bulletClone.transform.SetParent(bulletParent.transform);
    }
}
