using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyBulletCreateManager : MonoBehaviour {

    [System.Serializable]
    public struct CreateData
    {
        public CreateData(EnemyBulletCreator creator, int createFrame)
            : this()
        {
            this.creator = creator;
            this.createFrame = createFrame;
        }

        public EnemyBulletCreator creator ;
        public int createFrame;

    }

    [SerializeField]
    float nextPatternTime = 10.0f;

    [SerializeField]
    List<CreateData> createData = new List<CreateData>();

    int frame = 0;
    float nextTime = 0;

	// Use this for initialization
	void Start () {
        ChangeBehaviourType();
	}

	// Update is called once per frame
	void Update () {
        nextTime += Time.deltaTime;

        Create();
        
        if (nextTime >= nextPatternTime)
        {
            ChangeBehaviourType();
            nextTime = 0;
        }
	}

    void ChangeBehaviourType()
    {
        var type = Random.Range(0, 3);

        switch (type)
        { 
            case 0:
                SetSlantingBehaviour();
                break;
            case 1:
                SetVerticalBehaviour();
                break;
            case 2:
                SetRadiationBehaviour();
                break;
        }
    }

    void SetSlantingBehaviour()
    {
        foreach (var data in createData)
        {
            data.creator.SetSlantingBehaviour();
        }
    }

    void SetVerticalBehaviour()
    {
        foreach (var data in createData)
        {
            data.creator.SetVerticalBehaviour();
        }
    }

    void SetRadiationBehaviour()
    {
        foreach (var data in createData)
        {
            data.creator.SetRadiationBehaviour();
        }
    }


    void Create()
    {
        frame++;

        foreach (var data in createData)
        {
            if ((frame % data.createFrame) == 0)
            {
                data.creator.Create();
            }
        }
    }
}
