using UnityEngine;

public class FoodFall : MonoBehaviour
{
    public float fallSpeed = 3f;

    void Update()
    {
        transform.Translate(
            Vector3.down *
            fallSpeed *
            Time.deltaTime);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}