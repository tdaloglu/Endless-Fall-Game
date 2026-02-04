using UnityEngine;


public class Player : MonoBehaviour
{
    public float karakterHizi = 8f, maxSurat = 6f;
    private Rigidbody2D myRigidbody;
    private Animator myAnimator;

    void Awake()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }

    void Start()
    {

    }

    void FixedUpdate()
    {
        KlavyeHareketleri();
    }

    void KlavyeHareketleri()
    {
        float Xdurdur = 0f;
        float surat = Mathf.Abs(myRigidbody.linearVelocity.x);
        float yatay = Input.GetAxisRaw("Horizontal");

        if (yatay > 0)
        {
            if (surat < maxSurat)
            {
                Xdurdur = karakterHizi;
            }

            Vector3 yon = transform.localScale;
            yon.x = 0.3f;
            transform.localScale = yon;
            myAnimator.SetBool("run", true);
        }
        else if (yatay < 0)
        {
            if (surat < maxSurat)
            {
                Xdurdur = -karakterHizi;
            }

            Vector3 yon = transform.localScale;
            yon.x = -0.3f;
            transform.localScale = yon;
            myAnimator.SetBool("run", true);
        }
        else
        {
            myAnimator.SetBool("run", false);
            myRigidbody.linearVelocity = Vector2.zero;
        }

        myRigidbody.AddForce(new Vector2(Xdurdur, 0));
    }
}
