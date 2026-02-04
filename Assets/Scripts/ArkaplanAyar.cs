using UnityEngine;

public class ArkaplanAyar : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpriteRenderer mySprite = GetComponent<SpriteRenderer>();
        Vector3 skala = transform.localScale;

        float width = mySprite.sprite.bounds.size.x;

        float dunyaYukseklik = Camera.main.orthographicSize * 2f;

        float dunyaGenislik = dunyaYukseklik / Screen.height * Screen.width;

        skala.x = dunyaGenislik / width;
        transform.localScale = skala;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
