using UnityEngine;

public class ArkaplanYarat : MonoBehaviour
{
    private GameObject[] arkaplanlar;
    private float sonY;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SonArkaplanSonY();    
    }

    void SonArkaplanSonY()
    {
        arkaplanlar = GameObject.FindGameObjectsWithTag("Arkaplan");
        sonY = arkaplanlar[0].transform.position.y;
        for (int i = 1; i < arkaplanlar.Length; i++)
        {
            if (sonY > arkaplanlar[i].transform.position.y)
            {
                sonY = arkaplanlar[i].transform.position.y;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Arkaplan")
        {
            if (other.transform.position.y == sonY)
            {
                Vector3 depo = other.transform.position;
                float yukseklik = ((BoxCollider2D)other).size.y;

                for (int i = 0; i < arkaplanlar.Length; i++)
                {
                    if (!arkaplanlar[i].activeInHierarchy)
                    {
                        depo.y -= yukseklik;
                        sonY = depo.y;
                        arkaplanlar[i].transform.position = depo;
                        arkaplanlar[i].SetActive(true);
                    }
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
