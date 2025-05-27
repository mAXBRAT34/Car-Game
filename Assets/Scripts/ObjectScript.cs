using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScript : MonoBehaviour
{
    public GameObject[] cars; //  Mašīnu masīvs
    public Transform[] carPlaces; //  Masīvs, kur mašīnas jānovieto
    public AudioSource audioSource; //  Skaņas atskaņotājs
    public AudioClip[] audioClip; //  Skaņas efekti

    public bool rightPlace = false; //  Vai objekts ir pareizajā vietā?
    public GameObject lastDragged = null; //  Pēdējais pārvietotais objekts
    private Vector2[] savedPositions; //  Saglabātās pozīcijas
    internal Vector2 originalSize; //  Oriģinālais izmērs
    internal object placeSound; // Skaņa, kad objekts ir pareizā vietā

    private void Start()
    {
        savedPositions = new Vector2[cars.Length]; //  Saglabā sākotnējās pozīcijas

        for (int i = 0; i < cars.Length; i++)
        {
            if (cars[i] != null && carPlaces[i] != null)
            {
                savedPositions[i] = carPlaces[i].GetComponent<RectTransform>().localPosition;
            }
            else
            {
                Debug.LogError($"Car {i} or its place is NOT knowmn!");
            }
        }
    }

    public Vector2 GetOriginalPosition(GameObject car)
    {
        for (int i = 0; i < cars.Length; i++)
        {
            if (cars[i] == car)
            {
                return savedPositions[i]; 
            }
        }
        return Vector2.zero;
    }
}
