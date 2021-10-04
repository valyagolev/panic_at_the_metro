using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Symptoms : MonoBehaviour
{
    public Text symptomText;
    public Color goodColor, badColor, unknownColor;

    public BaseSymptomBehaviour[] symptoms;

    Text[] symptomTexts;

    // Start is called before the first frame update
    void Start()
    {

    }

    void CreateTexts(int count)
    {
        if (symptomTexts != null)
        {
            if (symptomTexts.Length == count) return;

            foreach (Text t in symptomTexts)
            {
                Destroy(t.gameObject);
            }
        }

        List<Text> texts = new List<Text>();

        Vector2 origPos = symptomText.GetComponent<RectTransform>().anchoredPosition;
        float origHeight = symptomText.GetComponent<RectTransform>().rect.height;

        for (var i = 0; i < count; i++)
        {
            Text t = GameObject.Instantiate(symptomText, symptomText.transform.parent);

            t.GetComponent<RectTransform>().anchoredPosition = new Vector2(origPos.x, origPos.y - (origHeight * 1.5f * i));

            t.gameObject.SetActive(true);

            texts.Add(t);
        }

        symptomTexts = texts.ToArray();
    }

    // Update is called once per frame
    void Update()
    {
        CreateTexts(symptoms.Length);

        for (var i = 0; i < symptoms.Length; i++)
        {
            if (!symptoms[i].known)
            {
                symptomTexts[i].text = "???";
                symptomTexts[i].color = unknownColor;
            }
            else
            {
                symptomTexts[i].text = symptoms[i].Description();
                symptomTexts[i].color = symptoms[i].good ? goodColor : badColor;
            }

        }
    }
}
