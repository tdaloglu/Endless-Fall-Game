using UnityEngine;

public class PlayerAlan : MonoBehaviour
{
    private float minX, maxX;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MinveMaxAyarla();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < minX)
        {
            Vector3 depo = transform.position;
            depo.x = minX;
            transform.position = depo;
        }

        if (transform.position.x > maxX)
        {
            Vector3 depo = transform.position;
            depo.x = maxX;
            transform.position = depo;
        }
    }

    void MinveMaxAyarla()
    {
        Vector3 alan = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        maxX = alan.x;
        minX = -alan.x;
    }
}
