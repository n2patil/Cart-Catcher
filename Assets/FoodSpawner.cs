using UnityEngine;
using System.Collections;

public class FoodSpawner : MonoBehaviour {

    public Object[] foodOptions;

    public float xStart;

    public float yBottom;

    public float yTop;

    public float spawnDelay;

    public float xEnd;

    public float floatDuration;

    // Use this for initialization
    void Start () {
        StartCoroutine(SpawnFood());
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0))
        {

            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.forward);

            if (hit != null)
            {
                Debug.Log("Hit!");

                if (hit.collider && hit.collider.GetComponent<Food>())
                {
                    Debug.Log("Hit Food");

                    hit.collider.GetComponent<Food>().Fall();
                }
            }
        }

    }

    public IEnumerator SpawnFood()
    {


        while (true)
        {
            float ypos = Random.Range(yBottom, yTop);

            Vector2 newSpawnPos = new Vector2(xStart, ypos);

            int randomFood = Random.Range(0, foodOptions.Length);

            GameObject spawnedFood = GameObject.Instantiate(foodOptions[randomFood], newSpawnPos, Quaternion.identity) as GameObject;

            spawnedFood.GetComponent<Food>().StartFloat(xEnd, floatDuration);

            yield return new WaitForSeconds(spawnDelay);


        }


    }


}
