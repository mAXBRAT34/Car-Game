using UnityEngine;
using UnityEngine.EventSystems;

public class PlaceScript : MonoBehaviour, IDropHandler
{
    public ObjectScript objectScript; // Objektu skripts
    public string correctTag; //  Pareizais tags objektam
    private Vector3 originalScale; //  Oriģinālais mērogs

    public AudioSource audioSource; //  Skaņas atskaņotājs
    public AudioClip successSound;  //  Skaņa, ja objekts ievietots pareizi

    private float maxScaleDeviationPercent = 0.05f; //  Maksimālā mēroga novirze (5%)

    private void Start()
    {
        originalScale = transform.localScale;
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null) return;

        GameObject draggedCar = eventData.pointerDrag;
        RectTransform carRect = draggedCar.GetComponent<RectTransform>();

        if (carRect == null)
        {
            Debug.LogError($"`RectTransform` not found for {draggedCar.name}.");
            return;
        }

        if (!draggedCar.CompareTag(correctTag) || !IsScaleCloseEnough(draggedCar.transform.localScale))
        {
            Debug.Log($" {draggedCar.name} does not fit! Size mismatch.");
            draggedCar.GetComponent<RectTransform>().localPosition = objectScript.GetOriginalPosition(draggedCar);
            objectScript.rightPlace = false;
            return;
        }

        draggedCar.transform.localScale = originalScale;
        carRect.anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
        carRect.SetSiblingIndex(50);

        CanvasGroup canvasGroup = draggedCar.GetComponent<CanvasGroup>();
        if (canvasGroup != null)
        {
            canvasGroup.blocksRaycasts = false;
            canvasGroup.interactable = false;
        }

        objectScript.rightPlace = true;
        Debug.Log($"{draggedCar.name} placed correctly!");

        // Atskaņo skaņu, ja objekts ievietots pareizi
        if (audioSource != null && successSound != null)
        {
            audioSource.PlayOneShot(successSound);
        }
        else
        {
            Debug.LogWarning(" Sound does not play!");
        }

        GameTimer gameTimer = FindObjectOfType<GameTimer>();
        if (gameTimer != null)
        {
            gameTimer.OnCarPlaced();
        }
        else
        {
            Debug.LogError("no gametimer");
        }
    }

    private bool IsScaleCloseEnough(Vector3 carScale)
    {
        float xDeviation = Mathf.Abs((carScale.x - originalScale.x) / originalScale.x);
        float yDeviation = Mathf.Abs((carScale.y - originalScale.y) / originalScale.y);

        return xDeviation <= maxScaleDeviationPercent && yDeviation <= maxScaleDeviationPercent;
    }
}
