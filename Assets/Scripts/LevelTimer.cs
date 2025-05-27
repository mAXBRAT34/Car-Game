using UnityEngine;
using TMPro;

public class LevelTimer : MonoBehaviour
{
    private TMP_Text timerText;
    private float startTime;
    private bool isRunning = true;

    private void Start()
    {
        startTime = Time.time; // Sākam taimeri
        isRunning = true;
        CreateTimerText();
    }

    private void CreateTimerText()
    {
        GameObject timerObject = new GameObject("TimerText");
        timerObject.transform.SetParent(GameObject.Find("Canvas").transform, false);

        timerText = timerObject.AddComponent<TextMeshProUGUI>();
        timerText.fontSize = 36;
        timerText.alignment = TextAlignmentOptions.Left;
        timerText.color = Color.white;

        RectTransform textRect = timerObject.GetComponent<RectTransform>();
        textRect.anchorMin = new Vector2(0, 1);
        textRect.anchorMax = new Vector2(0, 1);
        textRect.anchoredPosition = new Vector2(50, -50); // Iestatām pozīciju
    }

    private void Update()
    {
        if (!isRunning) return;

        float elapsedTime = Time.time - startTime;
        int hours = Mathf.FloorToInt(elapsedTime / 3600);
        int minutes = Mathf.FloorToInt((elapsedTime % 3600) / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);

        timerText.text = $"{hours:D2}:{minutes:D2}:{seconds:D2}"; // Laika formāts HH:MM:SS
    }

    public void StopTimer()
    {
        isRunning = false; // Apturam taimeri

        RectTransform textRect = timerText.GetComponent<RectTransform>();
        textRect.anchorMin = new Vector2(0.5f, 0.5f);
        textRect.anchorMax = new Vector2(0.5f, 0.5f);
        textRect.anchoredPosition = Vector2.zero; // Centrējam

        timerText.fontSize = 60; // Teksts kļūst lielāks
        timerText.alignment = TextAlignmentOptions.Center; // Teksta izlīdzināšana centrā

        Debug.Log($"🏁 Gala laiks: {timerText.text}");
    }
}
