using UnityEngine;

public class PlateController : MonoBehaviour
{
    public float speed = 10f;

    void Update()
    {
        float move = Input.GetAxisRaw("Horizontal");

        transform.Translate(
            Vector3.right *
            move *
            speed *
            Time.deltaTime
        );

        Vector3 pos = transform.position;

        pos.x = Mathf.Clamp(pos.x, -8f, 8f);

        transform.position = pos;
    }

   
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Åöµ½£º" + other.name);

        FoodItem food = other.GetComponent<FoodItem>();

        if (food == null)
            return;

        MealManager.instance.AddFood(food);

        Destroy(other.gameObject);
    }
}