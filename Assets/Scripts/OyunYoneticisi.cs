using UnityEngine;
using UnityEngine.SceneManagement;

public class OyunYoneticisi : MonoBehaviour
{
    public static OyunYoneticisi ornek;

    [HideInInspector]
    public bool oyunAnaMenudenBaslatildi, oyunKarakterOlunceTekrarBaslatildi;

    [HideInInspector]
    public int skor, altinSkor, canSkor;

    public void OyunuMenudenBaslat()
    {
        oyunAnaMenudenBaslatildi = true;
        oyunKarakterOlunceTekrarBaslatildi = false;
    }

    void Awake()
    {
        TekYap();
    }

    void Start()
    {
        BaslangicDegiskenleri();
    }

    void OnLevelWasLoaded()
    {
        if (SceneManager.GetActiveScene().name == "oyunDort")
        {
            if (oyunKarakterOlunceTekrarBaslatildi)
            {
                OynanabilirlikKontrol.ornek.SkorHesapla(skor);
                OynanabilirlikKontrol.ornek.AltinHesapla(altinSkor);
                OynanabilirlikKontrol.ornek.CanHesapla(canSkor);

                PlayerSkor.skor = skor;
                PlayerSkor.altinSayisi = altinSkor;
                PlayerSkor.canSayisi = canSkor;
            }
            else if (oyunAnaMenudenBaslatildi)
            {
                PlayerSkor.skor = 0;
                PlayerSkor.altinSayisi = 0;
                PlayerSkor.canSayisi = 2;

                OynanabilirlikKontrol.ornek.SkorHesapla(0);
                OynanabilirlikKontrol.ornek.AltinHesapla(0);
                OynanabilirlikKontrol.ornek.CanHesapla(2);
            }
        }
    }

    void TekYap()
    {
        if (ornek != null)
        {
            Destroy(gameObject);
        }
        else
        {
            ornek = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void OyunDurumunuKontrolEt(int skor, int altinSkor, int canSkor)
    {
        if (canSkor < 0)
        {
            if (OyunTercihleri.GetirKolayZorlukDurumu() == 1)
            {
                int yuksekSkor = OyunTercihleri.GetirKolayZorlukYuksekSkor();
                int yuksekAltinSkor = OyunTercihleri.GetirKolayZorlukAltinSkor();

                if (yuksekSkor < skor)
                {
                    OyunTercihleri.AyarlaKolayZorlukYuksekSkor(skor);
                }

                if (yuksekAltinSkor < altinSkor)
                {
                    OyunTercihleri.AyarlaKolayZorlukAltinSkor(altinSkor);
                }
            }

            if (OyunTercihleri.GetirNormalZorlukDurumu() == 1)
            {
                int yuksekSkor = OyunTercihleri.GetirNormalZorlukYuksekSkor();
                int yuksekAltinSkor = OyunTercihleri.GetirNormalZorlukAltinSkor();

                if (yuksekSkor < skor)
                {
                    OyunTercihleri.AyarlaNormalZorlukYuksekSkor(skor);
                }

                if (yuksekAltinSkor < altinSkor)
                {
                    OyunTercihleri.AyarlaNormalZorlukAltinSkor(altinSkor);
                }
            }

            if (OyunTercihleri.GetirYuksekZorlukDurumu() == 1)
            {
                int yuksekSkor = OyunTercihleri.GetirYuksekZorlukYuksekSkor();
                int yuksekAltinSkor = OyunTercihleri.GetirYuksekZorlukAltinSkor();

                if (yuksekSkor < skor)
                {
                    OyunTercihleri.AyarlaYuksekZorlukYuksekSkor(skor);
                }

                if (yuksekAltinSkor < altinSkor)
                {
                    OyunTercihleri.AyarlaYuksekZorlukAltinSkor(altinSkor);
                }
            }

            oyunAnaMenudenBaslatildi = false;
            oyunKarakterOlunceTekrarBaslatildi = false;
            OynanabilirlikKontrol.ornek.OyunSonuPanelAc(skor, altinSkor);
        }
        else
        {
            this.skor = skor;
            this.altinSkor = altinSkor;
            this.canSkor = canSkor;

            oyunAnaMenudenBaslatildi = false;
            oyunKarakterOlunceTekrarBaslatildi = true;
            OynanabilirlikKontrol.ornek.KarakterOlunceOyunuYenidenBaslat();
        }
    }

    void BaslangicDegiskenleri()
    {
        if (!PlayerPrefs.HasKey("Oyun Baslatildi"))
        {
            OyunTercihleri.AyarlaKolayZorlukDurumu(0);
            OyunTercihleri.AyarlaKolayZorlukAltinSkor(0);
            OyunTercihleri.AyarlaKolayZorlukYuksekSkor(0);

            OyunTercihleri.AyarlaNormalZorlukDurumu(1);
            OyunTercihleri.AyarlaNormalZorlukAltinSkor(0);
            OyunTercihleri.AyarlaNormalZorlukYuksekSkor(0);

            OyunTercihleri.AyarlaYuksekZorlukDurumu(0);
            OyunTercihleri.AyarlaYuksekZorlukAltinSkor(0);
            OyunTercihleri.AyarlaYuksekZorlukYuksekSkor(0);

            OyunTercihleri.AyarlaMuzikDurumu(0);

            PlayerPrefs.SetInt("Oyun Baslatildi", 1234);
        }
    }
}
