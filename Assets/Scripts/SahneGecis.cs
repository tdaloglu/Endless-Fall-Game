using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SahneGecis : MonoBehaviour
{
    public static SahneGecis ornek;

    [SerializeField]
    private GameObject fadePanel;

    [SerializeField]
    private Animator fadeAnim;

    void Awake()
    {
        TekYap();
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

    public void LoadLevel(string bolum)
    {
        StartCoroutine(FadeInOut(bolum));
    }

    IEnumerator FadeInOut(string bolum)
    {
        fadePanel.SetActive(true);
        fadeAnim.Play("FadeIn");
        yield return StartCoroutine(YeniCoroutine.GercekZamaniBekle(1f));
        SceneManager.LoadScene(bolum);
        fadeAnim.Play("FadeOut");
        yield return StartCoroutine(YeniCoroutine.GercekZamaniBekle(.7f));
        fadePanel.SetActive(false);
    }
}
