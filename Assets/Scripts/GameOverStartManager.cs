using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverStartManager : MonoBehaviour
{
    [SerializeField] public GameObject GameOverPanel;   // PascalCase
    [SerializeField] public GameObject GameOverText;
    [SerializeField] public GameObject ReplayButton;
    [SerializeField] public GameObject TitleButton;
    [SerializeField] public GameObject TotalScoreText;
    [SerializeField] public GameObject BestScoreText;
    [SerializeField] public GameObject NewBestText;
    [SerializeField] public GameObject TitleMenu;
    [SerializeField] public GameObject ModeSelectMenu;
    [SerializeField] public GameObject PauseScreen;
    [SerializeField] public GameObject CountdownManager;
    [SerializeField] public GameObject CountDownCanvas;

    private RainManager rainManager;
    private SFX_Manager SFX;
    private CountDown countDown;
    private ScoreBoardCanvas scoreBoard;// camelCase
    private ModeSelectScreenSlide msScreen_Slide;
    private TitleScreenSlide titleScreen_Slide;
    
    //private ButtonUIHover BUH;

    public static bool isReplay = false;
    public static bool Classic = false;
    public bool classic = false;
    public static bool Hard = false;
    public bool hard = false;
    public bool GameStarted = false;
    public bool IsPausing = false;


    private Coroutine afterContinueCountRoutine;
    private void TIMESCALE()
    {

        BestScoreIndicator BSI = FindFirstObjectByType<BestScoreIndicator>();
        RainDestroyer BSC = FindFirstObjectByType<RainDestroyer>();

        GameOverPanel.SetActive(true);
        GameOverText.SetActive(true);
        ReplayButton.SetActive(true);
        TotalScoreText.SetActive(true);
        BestScoreText.SetActive(true);
        TitleButton.SetActive(true);
        scoreBoard.DropPanel();
        Time.timeScale = 0.0f;

        if (BSC.ScoreCount > BSI.BestScore)
        {
            //Debug.Log("NBT Activated");
            NewBestText.SetActive(true);
            BSI.IndicateNewBestScoreGUI();
        }
    }
    private void Start()
    {
        rainManager = FindFirstObjectByType<RainManager>();
        SFX = FindFirstObjectByType<SFX_Manager>();
        countDown = FindFirstObjectByType<CountDown>(FindObjectsInactive.Include);
        scoreBoard = FindFirstObjectByType<ScoreBoardCanvas>(FindObjectsInactive.Include);
        titleScreen_Slide = FindFirstObjectByType<TitleScreenSlide>(FindObjectsInactive.Include);
        msScreen_Slide = FindFirstObjectByType<ModeSelectScreenSlide>(FindObjectsInactive.Include);
        //BUH = FindFirstObjectByType<ButtonUIHover>(FindObjectsInactive.Include);
        
        GameOverPanel.SetActive(false);
        GameOverText.SetActive(false);
        ReplayButton.SetActive(false);
        TotalScoreText.SetActive(false);
        BestScoreText.SetActive(false);
        NewBestText.SetActive(false);
        //ModeSelectMenu.SetActive(false);
        TitleButton.SetActive(false);
        PauseScreen.SetActive(false);
        CountdownManager.SetActive(false);

        

        if (isReplay==false)
        {
            TitleMenu.SetActive(true);
            ModeSelectMenu.SetActive(true);
            Time.timeScale = 0.0f;
        }
        else
        {
            if(Classic==true)
            {
                TitleMenu.SetActive(false);
                ModeSelectMenu.SetActive(false);
                Time.timeScale = 1.0f;
                isReplay = false;
                Classic = true;
                classic = true;
                Hard = false;
                hard = false;
                Invoke("Classic_Mode", 0f);
                Physics2D.IgnoreLayerCollision(
                        LayerMask.NameToLayer("Rain3"),
                        LayerMask.NameToLayer("Ground"),
                        false);
                Physics2D.IgnoreLayerCollision(
                       LayerMask.NameToLayer("Rain3_Hard"),
                       LayerMask.NameToLayer("Ground"),
                       false);
            }
            if(Hard==true)
            {
                TitleMenu.SetActive(false);
                Time.timeScale = 1.0f;
                isReplay = false;
                Hard = true;
                hard = true;
                Classic = false;
                classic = false;
                Invoke("Hard_Mode", 0f);
                Physics2D.IgnoreLayerCollision(
                        LayerMask.NameToLayer("Rain3"),
                        LayerMask.NameToLayer("Ground"),
                        false);
                Physics2D.IgnoreLayerCollision(
                       LayerMask.NameToLayer("Rain3_Hard"),
                       LayerMask.NameToLayer("Ground"),
                       false);
            }
        }
    }

    private void Update()
    {
        if(GameStarted==true)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Invoke("Pause_Game", 0f);
            }            
        }
        //Debug.Log(Hard);
        //Debug.Log(IsPausing);
    }

    public void GameOver()
    {
        //SFX.Player_Dead();
        //SFX.Stop_GameBGM();
        Invoke("TIMESCALE", 2.0f);
        BestScoreIndicator BSI = FindFirstObjectByType<BestScoreIndicator>();
        RainDestroyer BSC = FindFirstObjectByType<RainDestroyer>();

        //Debug.Log("BSC: " + BSC);
        //Debug.Log("BSI: " + BSI);
        //Debug.Log("ScoreCount: " + BSC.ScoreCount);
        //Debug.Log("BestScore: " + BSI.BestScore);
        
        BSI.SaveBestSocre();
        BSI.UpdateBestScoreGUI();
    }

    public void ReplayGame()
    {        
        if (classic==true)
        {
            Debug.Log("Restart");
            Time.timeScale = 1.0f;
            isReplay = true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            SFX.GameBGM();
            SFX.Stop_TitleBGM();
            
        }
        if(hard==true)
        {            
            Time.timeScale = 1.0f;
            isReplay = true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            SFX.GameBGM();
            SFX.Stop_TitleBGM();
        }
       
        SFX.Button_Down();
        GameStarted = true;
    }

    public void GotoSelection()
    {        
        //TitleMenu.SetActive(false);
        //BUH.rectTransform.localScale = BUH.OriginalScale;
       // ModeSelectMenu.SetActive(true);
        msScreen_Slide.SlideScreen();
        titleScreen_Slide.SlideScreen();
        SFX.Button_Down();
        
    }

    public void GotoTitle()
    {
        Time.timeScale = 0f;
        TitleMenu.SetActive(true);
        //BUH.rectTransform.localScale = BUH.OriginalScale;
        PauseScreen.SetActive(false);
        Classic = false;
        classic = false;
        Hard = false;
        hard = false;
        isReplay = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Physics2D.IgnoreLayerCollision(
                LayerMask.NameToLayer("Rain3"),
                LayerMask.NameToLayer("Ground"),
                false);
        Physics2D.IgnoreLayerCollision(
                LayerMask.NameToLayer("Rain3_Hard"),
                LayerMask.NameToLayer("Ground"),
                false);
        SFX.TitleBGM();
        SFX.Stop_GameBGM();
        SFX.Button_Down();
        GameStarted = false;
    }


    public void CountDownST_Classic()
    {
        CountdownManager.SetActive(true);
        countDown.CountDownStart();
        ModeSelectMenu.SetActive(false);
        TitleMenu.SetActive(false);
        SFX.Stop_TitleBGM();
        SFX.Button_Down();
        Time.timeScale = 1.0f;
        Invoke("Classic_Mode", 1.5f);
    }

    public void CountDownST_hard()
    {
        CountdownManager.SetActive(true);
        countDown.CountDownStart();
        ModeSelectMenu.SetActive(false);
        TitleMenu.SetActive(false);
        SFX.Stop_TitleBGM();
        SFX.Button_Down();
        Time.timeScale = 1.0f;
        Invoke("Hard_Mode", 1.5f);
    }
    public void Classic_Mode()
    {
        CountdownManager.SetActive(false);
        CountDownCanvas.SetActive(false);
        Classic = true;
        classic = true;
        Hard = false;
        hard = false;                       
        rainManager.StartingRain();
        GameStarted = true;
        
        //BUH.rectTransform.localScale = BUH.OriginalScale;

        SFX.GameBGM();
        SFX.Stop_TitleBGM();              
    }

    public void Hard_Mode()
    {
        CountdownManager.SetActive(false);
        CountDownCanvas.SetActive(false);
        //countDown.CountDownStart();
        Hard = true;
        hard = true;
        Classic = false;
        classic = false;
        
        rainManager.StartingRain();
        GameStarted = true;

        //BUH.rectTransform.localScale = BUH.OriginalScale;

        SFX.GameBGM();
        SFX.Stop_TitleBGM();                
    }

    public void Back()
    {
       // TitleMenu.SetActive(true);
        //ModeSelectMenu.SetActive(false);
        //BUH.rectTransform.localScale = BUH.OriginalScale;
        msScreen_Slide.BackScreen();
        titleScreen_Slide.BackScreen();
        SFX.Button_Down();
       
    }

    public void QuitGame()
    {
        
        SFX.Button_Down();
        //BUH.rectTransform.localScale = BUH.OriginalScale;
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void AfterContinueCount()
    {
        //PauseScreen.SetActive(false);
        //CountdownManager.SetActive(true);
        //countDown.CountDownStart();
        //SFX.Button_Down();

        //Invoke("ContinueGame", 3.0f);

        afterContinueCountRoutine = StartCoroutine(AfterContinueCountRoutine());
    }
    public void Pause_Game()
    {
        IsPausing = true;
        PauseScreen.SetActive(true);
        Time.timeScale = 0f;
        //BUH.rectTransform.localScale = BUH.OriginalScale;
        SFX.Pause_GameBGM();
        SFX.Button_Down();

        if(afterContinueCountRoutine != null)
        {
            StopCoroutine(afterContinueCountRoutine);
            afterContinueCountRoutine = null;
        }
        
    }

    IEnumerator AfterContinueCountRoutine()
    {
        PauseScreen.SetActive(false);
        CountdownManager.SetActive(true);
        CountDownCanvas.SetActive(true);
        countDown.CountDownStart();
        SFX.Button_Down();

        yield return new WaitForSecondsRealtime(1.5f);

        ContinueGame();
    }

    public void ContinueGame()
    {
        IsPausing = false;
        Time.timeScale = 1.0f;
        //BUH.rectTransform.localScale = BUH.OriginalScale;
        SFX.UnPause_GameBGM();              
    }

    
} 
