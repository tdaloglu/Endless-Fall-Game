using UnityEngine;

public class NesneYarat : MonoBehaviour
{
    [SerializeField]
    private GameObject[] nesneler;
    private float nesneMesafesi = 3f;
    private float minX, maxX;
    private float enSonNesneKonumuY;
    private float duzenleyiciX;
    private GameObject karakter;
    [SerializeField]
    private GameObject[] toplayicilar;

    void Awake()
    {
        duzenleyiciX = 0;
        MinVeMaxAyarla();
        NesneOlustur();
        karakter = GameObject.Find("Player");

        for (int i = 0; i < toplayicilar.Length; i++)
        {
            toplayicilar[i].SetActive(false);
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        KarakterinKonumu();
    }

    void MinVeMaxAyarla()
    {
        Vector3 alan = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        maxX = alan.x - 0.5f;
        minX = -alan.x + 0.5f;
    }

    void Karistir(GameObject[] karistirilacakDizi)
    {
        for (int i = 0; i < karistirilacakDizi.Length; i++)
        {
            GameObject depo = karistirilacakDizi[i];
            int rastgele = Random.Range(i, karistirilacakDizi.Length);
            karistirilacakDizi[i] = karistirilacakDizi[rastgele];
            karistirilacakDizi[rastgele] = depo;
        }
    }

    void NesneOlustur()
    {
        Karistir(nesneler);
        Karistir(toplayicilar);
        float konumY = 0f;

        for (int i = 0; i < nesneler.Length; i++)
        {
            Vector3 depo = nesneler[i].transform.position;
            depo.y = konumY;
            if (duzenleyiciX == 0)
            {
                depo.x = Random.Range(0.0f, maxX);
                duzenleyiciX = 1;
            }
            else if (duzenleyiciX == 1)
            {
                depo.x = Random.Range(0.0f, minX);
                duzenleyiciX = 2;
            }
            else if (duzenleyiciX == 2)
            {
                depo.x = Random.Range(1.0f, maxX);
                duzenleyiciX = 3;
            }
            else if (duzenleyiciX == 3)
            {
                depo.x = Random.Range(-1.0f, minX);
                duzenleyiciX = 0;
            }
            enSonNesneKonumuY = konumY;
            nesneler[i].transform.position = depo;
            konumY -= nesneMesafesi;
        }
    }

    void KarakterinKonumu()
    {
        GameObject[] engeller = GameObject.FindGameObjectsWithTag("Engel");
        GameObject[] destekler = GameObject.FindGameObjectsWithTag("Destek");

        for (int i = 0; i < engeller.Length; i++)
        {
            if (engeller[i].transform.position.y == 0)
            {
                Vector3 t = engeller[i].transform.position;
                engeller[i].transform.position = new Vector3(destekler[0].transform.position.x, destekler[0].transform.position.y, destekler[0].transform.position.z);
                destekler[0].transform.position = t;
            }
        }

        Vector3 depo = destekler[0].transform.position;
        for (int i = 1; i < destekler.Length; i++)
        {
            if (depo.y < destekler[i].transform.position.y)
            {
                depo = destekler[i].transform.position;
            }
        }

        depo.y += 0.8f;
        karakter.transform.position = depo;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Destek" || other.tag == "Engel")
        {
            if (other.transform.position.y == enSonNesneKonumuY)
            {
                Karistir(nesneler);
                Karistir(toplayicilar);
                Vector3 depo = other.transform.position;

                for (int i = 0; i < nesneler.Length; i++)
                {
                    if (!nesneler[i].activeInHierarchy)
                    {
                        if (duzenleyiciX == 0)
                        {
                            depo.x = Random.Range(0.0f, maxX);
                            duzenleyiciX = 1;
                        }
                        else if (duzenleyiciX == 1)
                        {
                            depo.x = Random.Range(0.0f, minX);
                            duzenleyiciX = 2;
                        }
                        else if (duzenleyiciX == 2)
                        {
                            depo.x = Random.Range(1.0f, maxX);
                            duzenleyiciX = 3;
                        }
                        else if (duzenleyiciX == 3)
                        {
                            depo.x = Random.Range(-1.0f, minX);
                            duzenleyiciX = 0;
                        }

                        depo.y -= nesneMesafesi;

                        enSonNesneKonumuY = depo.y;
                        nesneler[i].transform.position = depo;
                        nesneler[i].SetActive(true);

                        int rastgele = Random.Range(0, toplayicilar.Length);

                        if (nesneler[i].tag != "Engel")
                        {
                            if (!toplayicilar[rastgele].activeInHierarchy)
                            {
                                Vector3 depo2 = nesneler[i].transform.position;

                                depo2.y += 0.7f;

                                if (toplayicilar[rastgele].tag == "Can")
                                {
                                    if (PlayerSkor.canSayisi < 2)
                                    {
                                        toplayicilar[rastgele].transform.position = depo2;
                                        toplayicilar[rastgele].SetActive(true);
                                    }
                                }
                                else
                                {
                                    toplayicilar[rastgele].transform.position = depo2;
                                    toplayicilar[rastgele].SetActive(true);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
