using UnityEngine;
using System.Collections;

public class RocketMovement : MonoBehaviour
{

    public float timeScale;
    public float moveSpeed;

    public GameObject Loveball;

    public AudioClip[] PokeballClips;

    private AudioSource pokeballAudio;
    private AudioSource ascendAudio;
    private AudioSource dieAudio;

    private Rigidbody2D rigidBody;

    private KeyCode wasPressed = KeyCode.None;

    void Awake()
    {
        Time.timeScale = 0;
    }

    // Use this for initialization
    void Start()
    {
        pokeballAudio = transform.FindChild("PokeballAudio").GetComponent<AudioSource>();
        ascendAudio = transform.FindChild("AscendAudio").GetComponent<AudioSource>();
        dieAudio = transform.FindChild("DeathAudio").GetComponent<AudioSource>();
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //Left button is clicked
        if (Input.GetMouseButton(0))
        {
            if ((GameState.State == GameStates.GameWaiting || GameState.State == GameStates.MainMenu))
            {
                GameState.State = GameStates.Playing;
                Time.timeScale = timeScale;
                return;
            }
        }

        if (GameState.State == GameStates.Playing && Input.GetKeyDown(KeyCode.Space) && wasPressed == KeyCode.None)
            wasPressed = KeyCode.Space;
        else if (Input.GetKeyUp(KeyCode.Space) && wasPressed == KeyCode.Space)
        {
            Instantiate(Loveball, transform.position, Quaternion.identity);
            if (!pokeballAudio.isPlaying)
            {
                pokeballAudio.clip = PokeballClips[Random.Range(0, PokeballClips.Length)];
                pokeballAudio.Play();
            }
            wasPressed = KeyCode.None;
        }

        if (Input.GetKeyDown(KeyCode.Escape) && wasPressed == KeyCode.None)
            wasPressed = KeyCode.Escape;
        else if (Input.GetKeyUp(KeyCode.Escape) && wasPressed == KeyCode.Escape)
        {
            wasPressed = KeyCode.None;
            GameState.State = GameStates.MainMenu;
            Application.LoadLevel("MainMenu");
        }

    }

    void FixedUpdate()
    {
        if (GameState.State == GameStates.Playing || GameState.State == GameStates.GameWaiting)
        {
            float distance = transform.position.z - Camera.main.transform.position.z;
            float mouseY = Input.mousePosition.y;
            mouseY = (mouseY - Screen.height / 2);
            mouseY = Screen.height/2 + (5 * mouseY);
            var mousePos = new Vector3(Input.mousePosition.x, mouseY, distance);
            var targetPos = new Vector3(transform.position.x, Camera.main.ScreenToWorldPoint(mousePos).y, transform.position.z);

            transform.position = Vector3.Lerp(transform.position, targetPos, moveSpeed);
        }
    }

    public void Die()
    {
        GameState.State = GameStates.Dying;

        rigidBody.velocity = Vector2.zero;
        rigidBody.AddForce(new Vector2(-50, 50));
        rigidBody.AddTorque(180);

        dieAudio.Play();

        Invoke("Restart", dieAudio.clip.length + 0.1f);
    }

    void Restart()
    {
        //Reset score
        ScoreKeeper.Score = 0;
        GameState.State = GameStates.GameWaiting;
        ScoreKeeper.AddDeath();
        PlayerPrefs.SetInt("deaths", ScoreKeeper.Deaths);
        Application.LoadLevel("scene_0");
    }
}
