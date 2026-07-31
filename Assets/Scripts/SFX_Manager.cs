using UnityEngine;

public class SFX_Manager : MonoBehaviour
{
    [SerializeField] private AudioSource title_bgm;
    [SerializeField] private AudioSource playerdash;
    [SerializeField] private AudioSource playerjump;
    [SerializeField] private AudioSource buttondown;
    [SerializeField] private AudioSource rain3landing;
    [SerializeField] private AudioSource playerslash;
    [SerializeField] private AudioSource buttonhover;
    [SerializeField] private AudioSource game_bgm;
    [SerializeField] private AudioSource playerhit;
    [SerializeField] private AudioSource rain2falling;
    [SerializeField] private AudioSource playerdead;
    [SerializeField] private AudioSource itemget;
    [SerializeField] private AudioSource playerheal;

    public AudioClip Title_BGM;
    public AudioClip PlayerDash;
    public AudioClip PlayerJump;
    public AudioClip ButtonDown;
    public AudioClip Rain3Landing;
    public AudioClip PlayerSlash;
    public AudioClip ButtonHover;
    public AudioClip Game_BGM;
    public AudioClip Player_Hit;
    public AudioClip Rain2Falling;
    public AudioClip PlayerDead;
    public AudioClip ItemGet;
    public AudioClip PlayerHeal;

    private void Start()
    {
        //playerdash = GetComponent<AudioSource>();
        //playerjump = GetComponent<AudioSource>();
        //buttondown = GetComponent<AudioSource>();
        //rain3landing = GetComponent<AudioSource>();
        //playerslash = GetComponent<AudioSource>();
        title_bgm.clip = Title_BGM;
        title_bgm.volume = 0.1f;
        title_bgm.pitch = 1.0f;
        title_bgm.Play();
        title_bgm.loop = true;
    }
    
    public void Player_Dash()
    {
        playerdash.volume = 0.2f;
        playerdash.pitch = 2;
        playerdash.PlayOneShot(PlayerDash);
    }

    public void Player_Jump()
    {
        playerjump.volume = 0.15f;
        playerjump.pitch = 2;
        playerjump.PlayOneShot(PlayerJump);
    }

    public void PlayerHit()
    {
        playerhit.volume = 0.5f;
        playerhit.pitch = 0.5f;
        playerhit.PlayOneShot(Player_Hit);
    }

    public void Player_Heal()
    {
        playerheal.volume = 0.5f;
        playerheal.pitch = 1f;
        playerheal.PlayOneShot(PlayerHeal);
    }

    public void Player_Dead()
    {
        playerdead.volume = 0.5f;
        playerdead.pitch = 1;
        playerdead.PlayOneShot(PlayerDead);
    }

    public void Button_Down()
    {
        buttondown.volume = 1;
        buttondown.pitch = 1.5f;
        buttondown.PlayOneShot(ButtonDown);
    }

    public void Item_Get()
    {
        itemget.volume = 0.5f;
        itemget.pitch = 1f;
        itemget.PlayOneShot(ItemGet);
    }

    public void Rain2_Falling()
    {
        rain2falling.volume=0.1f;
        rain2falling.pitch = 1f;
        rain2falling.PlayOneShot(Rain2Falling);
    }

    public void Rain3_Landing()
    {
        rain3landing.volume = 0.3f;
        rain3landing.pitch = 0.5f;
        rain3landing.PlayOneShot(Rain3Landing);
    }

    public void Player_Slash()
    {
        playerslash.volume = 0.3f;
        playerslash.pitch = 0.5f;
        playerslash.PlayOneShot(PlayerSlash);
    }

    public void Button_Hover()
    {
        buttonhover.volume = 0.3f;
        buttonhover.pitch = 1.2f;
        buttonhover.PlayOneShot(ButtonHover);
    }

    public void TitleBGM()
    {
        title_bgm.clip = Title_BGM;
        title_bgm.playOnAwake = true;
        title_bgm.volume = 0.8f;
        title_bgm.pitch = 1.0f;
        title_bgm.Play();
        title_bgm.loop = true;
    }
    public void GameBGM()
    {
        game_bgm.clip = Game_BGM;
        game_bgm.playOnAwake = true;
        game_bgm.volume = 0.15f;
        game_bgm.pitch = 1f;
        game_bgm.Play();
        game_bgm.loop = true;
    }

    public void Stop_GameBGM()
    {
        game_bgm.Stop();
        game_bgm.playOnAwake = false;
    }

    public void Pause_GameBGM()
    {
        game_bgm.Pause();
    }

    public void UnPause_GameBGM()
    {
        game_bgm.UnPause();
    }

    public void Stop_TitleBGM()
    {
        title_bgm.Stop();
        title_bgm.playOnAwake = false;
    }

    
}
