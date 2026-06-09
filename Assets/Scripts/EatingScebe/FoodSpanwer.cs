using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public GameObject[] foodPrefabs;

    public float spawnInterval = 1f;

    public float spawnX = 8f;
    public float spawnY = 6f;

    float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            timer = 0;

            SpawnFood();
        }
    }

    void SpawnFood()
    {
        int index =
            Random.Range(0, foodPrefabs.Length);

        Vector3 pos =
            new Vector3(
                Random.Range(-spawnX, spawnX),
                spawnY,
                0);

        Instantiate(
            foodPrefabs[index],
            pos,
            Quaternion.identity);
    }
}