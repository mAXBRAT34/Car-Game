using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour
{
    public Image winImage;
    public Sprite[] starSprites;
    public TMP_Text finalTimeText;
    public Button menuButton;
    public Button retryButton;
    public Button exitButton; //  POGA IZIEŠANAI UZ GALVENO IZVĒLNI

    public int totalCars = 12;

    private int placedCars = 0;
    private float startTime;
    private bool gameFinished = false;

    private void Start()
    {
        placedCars = 0;
        gameFinished = false;

        ResetUI();

        startTime = Time.time;

        menuButton.onClick.AddListener(GoToMenu);
        retryButton.onClick.AddListener(RetryLevel);
        exitButton.onClick.AddListener(ExitGame); //  Sasaiste ar pogu iziešanai
    }

    private void ResetUI()
    {
        winImage.gameObject.SetActive(false);
        finalTimeText.gameObject.SetActive(false);
        menuButton.gameObject.SetActive(false);
        retryButton.gameObject.SetActive(false);
        exitButton.gameObject.SetActive(false); //  Paslēpjam iziešanas pogu
    }

    public void OnCarPlaced()
    {
        if (gameFinished) return;

        placedCars++;

        if (placedCars >= totalCars)
        {
            ShowWinScreen();
            gameFinished = true;
        }
    }

    private void ShowWinScreen()
    {
        gameFinished = true;
        float elapsedTime = Time.time - startTime;
        int stars = CalculateStars(elapsedTime);

        if (stars >= 1 && stars <= starSprites.Length)
        {
            winImage.sprite = starSprites[stars - 1];
        }

        int hours = Mathf.FloorToInt(elapsedTime / 3600); // Aprēķinām stundas
        int minutes = Mathf.FloorToInt((elapsedTime % 3600) / 60); // Аprēķinām minūtes pēc stundu atņemšanas
        int seconds = Mathf.FloorToInt(elapsedTime % 60); //Atlikušie sekundes

        string formattedTime = $"Time: {hours:D2}:{minutes:D2}:{seconds:D2}"; // Formāts HH:MM:SS

        finalTimeText.text = formattedTime;
        finalTimeText.alignment = TextAlignmentOptions.Center;

        winImage.gameObject.SetActive(true);
        finalTimeText.gameObject.SetActive(true);
        menuButton.gameObject.SetActive(true);
        retryButton.gameObject.SetActive(true);
        exitButton.gameObject.SetActive(true); // Parādam iziešanas pogu
    }

    private int CalculateStars(float time)
    {
        if (time < 15) return 4;
        if (time < 30) return 3;
        if (time < 45) return 2;
        return 1;
    }

    private void GoToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private void RetryLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void ExitGame()
    {
        Debug.Log("Iziešana uz galveno izvēlni!");
        SceneManager.LoadScene("MainMenu");
    }
}
