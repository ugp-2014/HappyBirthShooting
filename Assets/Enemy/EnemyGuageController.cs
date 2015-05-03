using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyGuageController : MonoBehaviour {

    Image image = null;

	// Use this for initialization
	void Start () {
        image = GetComponent<Image>();
	}

    public void Damage(float percent)
    {
        image.fillAmount = percent;
    }
}
