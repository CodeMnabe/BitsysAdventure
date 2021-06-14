using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class IsMouseOverUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI seedText;
    [SerializeField] private string seedDescription;

    private bool IsMouseOverThis()
    {
        bool over = EventSystem.current.IsPointerOverGameObject();
        if (over)
        {
            PointerEventData pointerData = new PointerEventData(EventSystem.current)
            {
                pointerId = -1
            };

            pointerData.position = Input.mousePosition;

            List<RaycastResult> results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(pointerData, results);

            if (results.Count > 0)
            {
                for (int i = 0; i < results.Count; ++i)
                {
                    if (results[i].gameObject.name == gameObject.name) return true;
                }
            }
        }


        return false;
    }

    private void Update()
    {
        if (IsMouseOverThis())
        {
            seedText.gameObject.SetActive(true);
            seedText.text = seedDescription;
        }
    }
}
