using UnityEngine;

public class TransformScript : MonoBehaviour
{
    public ObjectScript objectScript;

    private Vector3 originalScale;
    private float minScaleFactor = 0.8f;
    private float maxScaleFactor = 1.2f;

    private void Start()
    {
        originalScale = transform.localScale;
    }

    void Update()
    {
        if (objectScript.lastDragged != null)
        {
            Transform carTransform = objectScript.lastDragged.transform;

            if (Input.GetKey(KeyCode.Z))
                carTransform.Rotate(0, 0, Time.deltaTime * 12f);

            if (Input.GetKey(KeyCode.X))
                carTransform.Rotate(0, 0, -Time.deltaTime * 12f);

            if (Input.GetKey(KeyCode.UpArrow))
                AdjustScale(carTransform, new Vector3(0, 0.001f, 0));

            if (Input.GetKey(KeyCode.DownArrow))
                AdjustScale(carTransform, new Vector3(0, -0.001f, 0));

            if (Input.GetKey(KeyCode.LeftArrow))
                AdjustScale(carTransform, new Vector3(-0.001f, 0, 0));

            if (Input.GetKey(KeyCode.RightArrow))
                AdjustScale(carTransform, new Vector3(0.001f, 0, 0));
        }
    }

    private void AdjustScale(Transform carTransform, Vector3 scaleAdjustment)
    {
        Vector3 newScale = carTransform.localScale + scaleAdjustment;

        newScale.x = Mathf.Clamp(newScale.x, originalScale.x * minScaleFactor, originalScale.x * maxScaleFactor);
        newScale.y = Mathf.Clamp(newScale.y, originalScale.y * minScaleFactor, originalScale.y * maxScaleFactor);

        carTransform.localScale = newScale;
    }
}
