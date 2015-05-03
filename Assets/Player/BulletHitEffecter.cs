using UnityEngine;
using System.Collections;

public class BulletHitEffecter : MonoBehaviour {

    [SerializeField]
    string hitTagName = string.Empty;

    [SerializeField]
    GameObject effect = null;

    GameObject hitGameObject = null;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if (hitGameObject != null) return;

        hitGameObject = GameObject.FindGameObjectWithTag(hitTagName);
	}

    void OnTriggerEnter(Collider collision)
    {
        if (hitGameObject == null) return;

        if (collision.gameObject.name == hitGameObject.name)
        {
            Instantiate(effect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
