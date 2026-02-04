using UnityEngine;

public class PlayerKontrol : MonoBehaviour
{
    public float karakterHizi = 8f, maxSurat = 4f;
    private Rigidbody2D myRigidbody;
    private Animator myAnimator;

    private bool solaGit, sagaGit;

    void Awake()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if (solaGit)
        {
            SolaGit();
        }

        if (sagaGit)
        {
            SagaGit();
        }
    }

    public void AyarlaSolaGit(bool solaGit)
    {
        this.solaGit = solaGit;
        this.sagaGit = !solaGit;
    }

    public void HareketiDurdur()
    {
        solaGit = sagaGit = false;
        myAnimator.SetBool("run", false);
    }

    void SolaGit()
    {
        float Xdurdur = 0f;
        float surat = Mathf.Abs(myRigidbody.linearVelocity.x);

        if (surat < maxSurat)
        {
            Xdurdur = -karakterHizi;
        }

        Vector3 yon = transform.localScale;
        yon.x = -0.3f;
        transform.localScale = yon;

        myAnimator.SetBool("run", true);

        myRigidbody.AddForce(new Vector2(Xdurdur, 0));
    }

    void SagaGit()
    {
        float Xdurdur = 0f;
        float surat = Mathf.Abs(myRigidbody.linearVelocity.x);

        if (surat < maxSurat)
        {
            Xdurdur = karakterHizi;
        }

        Vector3 yon = transform.localScale;
        yon.x = 0.3f;
        transform.localScale = yon;

        myAnimator.SetBool("run", true);

        myRigidbody.AddForce(new Vector2(Xdurdur, 0));
    }
}
