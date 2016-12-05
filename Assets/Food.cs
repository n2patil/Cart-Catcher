using UnityEngine;
using System.Collections;

public class Food : MonoBehaviour {

    public bool hasFiber;
    public bool hasVitaminA;
    public bool hasCalcium;
    public bool hasProtein;
	public bool hasAntiOxidents;
	public bool hasPotassium;

    public float xEnd;
    public float floatDuration;

    bool floating = true;

	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    void Update() {


    }

    public void StartFloat(float xEnd, float floatDuration)
    {
        this.xEnd = xEnd;
        this.floatDuration = floatDuration;

        StartCoroutine(Float());


    }

    public void Fall()
    {
        Debug.Log("Falling");

        floating = false;
        this.gameObject.AddComponent<Rigidbody2D>();
    }

    public IEnumerator Float()
    {

        Vector3 startPos = transform.position;
        Vector3 endPos = startPos;
        endPos.x = xEnd;

        for (float i = 0; i < floatDuration; i += Time.deltaTime)
        {

            if (floating)
            {

                float interpolant = i / floatDuration;
                transform.position = Vector3.Lerp(startPos, endPos, interpolant);

                yield return null;
            }

        }
        if (floating)
        {
            Destroy(this.gameObject);
        }

    }
}
