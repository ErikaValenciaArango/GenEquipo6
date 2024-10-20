using TMPro;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    Rigidbody2D rgbdPlayer;
    private int ammo = 0;
    public float jumpForce = 1000;
    private bool tocaSuelo;
    public float speed;
    public bool gameOver = false;
    public GameObject bullet;
    public GameObject pointShot;
    public float tiempoParaDisparar;
    public float tiempoActual;
    private Animator playerAnimator;
    public AudioClip jumpClip, launchClip;

    [SerializeField]TextMeshProUGUI textAmmo;

    void Start()
    {
        rgbdPlayer = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        playerAnimator.SetBool("bool_run", true);
    }

    // Update is called once per frame
    void Update()
    {
        tiempoActual += Time.deltaTime;

        //Salto del personaje
        if (Input.GetKeyDown(KeyCode.UpArrow) && tocaSuelo)
        {
            rgbdPlayer.velocity = Vector3.zero;
            rgbdPlayer.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
            tocaSuelo = false;
            playerAnimator.SetBool("bool_jump", true);
            AudioManager.Instance.PlaySFX(jumpClip);
        }

        //Disparar proyectil
        if (Input.GetKeyDown(KeyCode.Space) && tiempoActual >= tiempoParaDisparar && ammo>0)

        {
            Shot();
            ammo --;
            textAmmo.text = ammo.ToString();
            tiempoActual = 0;
        }

        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            GameManager.Instance.OptionsPanel();
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Evita saltar mas de una vez
        if (collision.gameObject.CompareTag("Suelo"))
        {
            tocaSuelo = true;
            playerAnimator.SetBool("bool_jump", false);

        }
        else if (collision.gameObject.CompareTag("Obstacle"))   //Detecta si colisiono el jugador para pasar a estado de muerto
        {
            playerAnimator.SetBool("bool_dead", true);
            Destroy(collision.gameObject);
            gameOver = true;
            GameManager.Instance.GameOverPanel();
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        //recoge los huesos del piso
        if(other.gameObject.CompareTag("Ammo")){
            ammo++;
            Destroy(other.gameObject);
            textAmmo.text = ammo.ToString();
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        //Evita saltar mas de una vez
        if (collision.gameObject.CompareTag("Suelo"))
        {
            tocaSuelo = false;
        }
    }

    private void Shot()
    {
        //Creacion de proyectiles
        Instantiate(bullet, pointShot.transform.position, Quaternion.identity);
        AudioManager.Instance.PlaySFX(launchClip);
    }
}
