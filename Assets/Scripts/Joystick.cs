using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    private PlayerKontrol playerHareket;

    void Start()
    {
        playerHareket = GameObject.Find("Player").GetComponent<PlayerKontrol>();
    }
    public void OnPointerDown(PointerEventData veri)
    {
        if (gameObject.name == "SolBtn")
        {
            playerHareket.AyarlaSolaGit(true);
        }
        else
        {
            playerHareket.AyarlaSolaGit(false);
        }
    }

    public void OnPointerUp(PointerEventData veri)
    {
        playerHareket.HareketiDurdur();
    }
}
