using UnityEngine;
using System.Collections;

public class EnemySinkingMover : MonoBehaviour {

    [SerializeField]
    EnemyHitPointManager hpManager = null;

    [SerializeField]
    GameObject effect = null;

    [SerializeField]
    float speed = 1.0f;

    [SerializeField]
    int createEffectFrame = 10;

    int frame = 0;

    public bool IsSinking { get; private set; }

	// Use this for initialization
	void Start () {
        IsSinking = false;  
	}
	
	// Update is called once per frame
	void Update () {
        if (IsSinking) return;
        if (!hpManager.IsDes) return;

        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        Sinking();
        CreateEffect();
	}

    void Sinking()
    {
        if (transform.position.z >= 10)
        {
            IsSinking = true;
        }
    }

    public void Destory()
    {
        Destroy(gameObject);
    }

    void CreateEffect()
    {
        frame++;
        if (frame >= createEffectFrame)
        {
            frame = 0;
            const float range = 1.5f;
            var x = Random.Range(-range, range);
            var y = Random.Range(-range, range);
            Instantiate(effect, transform.position + new Vector3(x, y, 0), Quaternion.identity);
        }
    }
}
