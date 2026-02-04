using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OynanabilirlikKontrol : MonoBehaviour
{
    public static OynanabilirlikKontrol ornek;

    [SerializeField]
    private GameObject durdurPanel, oyunSonuPanel;

    [SerializeField]
    private Text skorText, altinText, canText, oyunSonuSkorText, oyunSonuAltinText;

    [SerializeField]
    private GameObject hazirBtn;

    void Awake()
    {
        OrnekYap();
    }

    void OrnekYap()
    {
        if (ornek == null)
        {
            ornek = this;
        }
    }

    void Start()
    {
        Time.timeScale = 0f;
    }

    public void OyunuDurdur()
    {
        Time.timeScale = 0;
        durdurPanel.SetActive(true);
    }

    public void OyunuSurdur()
    {
        Time.timeScale = 1f;
        durdurPanel.SetActive(false);
    }

    public void OyunuKapat()
    {
        Time.timeScale = 1f;
        SahneGecis.ornek.LoadLevel("MainMenu");
    }

    public void SkorHesapla(int skor)
    {
        skorText.text = "x" + skor;
    }

    public void AltinHesapla(int altinSkor)
    {
        altinText.text = "x" + altinSkor;
    }

    public void CanHesapla(int canSkor)
    {
        canText.text = "x" + canSkor;
    }

    public void OyunSonuPanelAc(int sonSkor, int sonAltinSkor)
    {
        oyunSonuPanel.SetActive(true);
        oyunSonuSkorText.text = sonSkor.ToString();
        oyunSonuAltinText.text = sonAltinSkor.ToString();
        StartCoroutine(OyunSonuPanelYukle());
    }

    IEnumerator OyunSonuPanelYukle()
    {
        yield return new WaitForSeconds(3f);
        SahneGecis.ornek.LoadLevel("MainMenu");
    }

    public void KarakterOlunceOyunuYenidenBaslat()
    {
        StartCoroutine(KarakterOlunceYenidenBaslat());
    }

    IEnumerator KarakterOlunceYenidenBaslat()
    {
        yield return new WaitForSeconds(1f);
        SahneGecis.ornek.LoadLevel("oyunDort");
    }

    public void OyunuBaslat()
    {
        Time.timeScale = 1f;
        hazirBtn.SetActive(false);
    }
}
