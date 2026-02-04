using UnityEngine;

public class PlayerSkor : MonoBehaviour
{
    [SerializeField]
    private AudioClip altinSes, canSes;

    private Kamera kameraScript;
    private Vector3 oncekiKonum;
    private bool skorDurum;

    public static int skor;
    public static int canSayisi;
    public static int altinSayisi;

    void Awake()
    {
        kameraScript = Camera.main.GetComponent<Kamera>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        oncekiKonum = transform.position;
        skorDurum = true;
    }

    // Update is called once per frame
    void Update()
    {
        Skor();
    }

    void Skor()
    {
        if (skorDurum)
        {
            if (transform.position.y < oncekiKonum.y)
            {
                skor++;
            }
            oncekiKonum = transform.position;
            OynanabilirlikKontrol.ornek.SkorHesapla(skor);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Altin")
        {
            altinSayisi++;
            skor += 200;
            OynanabilirlikKontrol.ornek.SkorHesapla(skor);
            OynanabilirlikKontrol.ornek.AltinHesapla(altinSayisi);
            AudioSource.PlayClipAtPoint(altinSes, transform.position);
            other.gameObject.SetActive(false);
        }

        if (other.tag == "Can")
        {
            canSayisi++;
            skor += 300;
            OynanabilirlikKontrol.ornek.SkorHesapla(skor);
            OynanabilirlikKontrol.ornek.CanHesapla(canSayisi);
            AudioSource.PlayClipAtPoint(canSes, transform.position);
            other.gameObject.SetActive(false);
        }

        if (other.tag == "Sinirlar")
        {
            kameraScript.hareketliKamera = false;
            skorDurum = false;
            canSayisi--;
            transform.position = new Vector3(500, 500, 0);
            OyunYoneticisi.ornek.OyunDurumunuKontrolEt(skor, altinSayisi, canSayisi);
        }

        if (other.tag == "Engel")
        {
            kameraScript.hareketliKamera = false;
            skorDurum = false;
            canSayisi--;
            transform.position = new Vector3(500, 500, 0);
            OyunYoneticisi.ornek.OyunDurumunuKontrolEt(skor, altinSayisi, canSayisi);
        }
    }
}
