using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AnaMenuKontrol : MonoBehaviour
{
    [SerializeField]
    private Button muzikBtn;

    [SerializeField]
    private Sprite[] muzikAcikKapali;

    void Start()
    {
        KontrolMuzik();
    }

    void KontrolMuzik()
    {
        if (OyunTercihleri.GetirMuzikDurumu() == 1)
        {
            MuzikKontrol.ornek.OynatMuzik(true);
            muzikBtn.image.sprite = muzikAcikKapali[1];
        }
        else
        {
            MuzikKontrol.ornek.OynatMuzik(false);
            muzikBtn.image.sprite = muzikAcikKapali[0];
        }
    }

    public void OyunuBaslat()
    {
        OyunYoneticisi.ornek.oyunAnaMenudenBaslatildi = true;
        SahneGecis.ornek.LoadLevel("oyunDort");
    }

    public void HighScore()
    {
        SceneManager.LoadScene("YuksekSkor");
    }

    public void Options()
    {
        SceneManager.LoadScene("Ayarlar");
    }

    public void MuzikButton()
    {
        if (OyunTercihleri.GetirMuzikDurumu() == 0)
        {
            OyunTercihleri.AyarlaMuzikDurumu(1);
            MuzikKontrol.ornek.OynatMuzik(true);
            muzikBtn.image.sprite = muzikAcikKapali[1];
        }
        else if (OyunTercihleri.GetirMuzikDurumu() == 1)
        {
            OyunTercihleri.AyarlaMuzikDurumu(0);
            MuzikKontrol.ornek.OynatMuzik(false);
            muzikBtn.image.sprite = muzikAcikKapali[0];
        }
    }
}
