using UnityEngine;

public class Kamera : MonoBehaviour
{
    private float hiz = 1f;
    private float hizlanma = 0.2f;
    private float maxHiz = 3.2f;

    private float kolayHiz = 3.4f;
    private float normalHiz = 3.8f;
    private float zorHiz = 4.2f;

    [HideInInspector]
    public bool hareketliKamera;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (OyunTercihleri.GetirKolayZorlukDurumu() == 1)
        {
            maxHiz = kolayHiz;
        }

        if (OyunTercihleri.GetirNormalZorlukDurumu() == 1)
        {
            maxHiz = normalHiz;
        }

        if (OyunTercihleri.GetirYuksekZorlukDurumu() == 1)
        {
            maxHiz = zorHiz;
        }

        hareketliKamera = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (hareketliKamera)
        {
            HareketliKamera();
        }
    }

    void HareketliKamera()
    {
        Vector3 depo = transform.position;
        float eskiY = depo.y;
        float yeniY = depo.y - (hiz * Time.deltaTime);
        depo.y = Mathf.Clamp(depo.y, eskiY, yeniY);
        transform.position = depo;
        hiz += hizlanma * Time.deltaTime;
        if (hiz > maxHiz)
        {
            hiz = maxHiz;
        }
    }
}
