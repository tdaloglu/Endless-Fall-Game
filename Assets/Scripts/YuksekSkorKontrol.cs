using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class YuksekSkorKontrol : MonoBehaviour
{
    [SerializeField]
    private Text skorTxt, altinSkorTxt;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AyarlaZorlukSeviyesineGoreSkor();
    }

    void SkorAyarla(int skor, int altinSkor)
    {
        skorTxt.text = skor.ToString();
        altinSkorTxt.text = altinSkor.ToString();
    }

    void AyarlaZorlukSeviyesineGoreSkor()
    {
        if (OyunTercihleri.GetirKolayZorlukDurumu() == 1)
        {
            SkorAyarla(OyunTercihleri.GetirKolayZorlukYuksekSkor(), OyunTercihleri.GetirKolayZorlukAltinSkor());
        }

        if (OyunTercihleri.GetirNormalZorlukDurumu() == 1)
        {
            SkorAyarla(OyunTercihleri.GetirNormalZorlukYuksekSkor(), OyunTercihleri.GetirNormalZorlukAltinSkor());
        }

        if (OyunTercihleri.GetirYuksekZorlukDurumu() == 1)
        {
            SkorAyarla(OyunTercihleri.GetirYuksekZorlukYuksekSkor(), OyunTercihleri.GetirYuksekZorlukAltinSkor());
        } 
    }

    public void AnaMenuyeDon()
    {
        SceneManager.LoadScene("MainMenu");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
