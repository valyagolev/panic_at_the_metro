using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SymptomsGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        List<BaseSymptomBehaviour> symptoms = new List<BaseSymptomBehaviour>();

        foreach (string item in ItemLibrary.Instance.ItemNames())
        {
            ItemSymptom s = gameObject.AddComponent<ItemSymptom>();
            s.item = item;
            s.good = Random.Range(0, 2) == 0;
            s.strength = Random.Range(10, 60);

            symptoms.Add(s);
        }

        TrainSymptom ts = gameObject.AddComponent<TrainSymptom>();
        ts.good = Random.Range(0, 2) == 0;
        ts.strength = Random.Range(1, 10);
        symptoms.Add(ts);

        PeopleSymptom ps = gameObject.AddComponent<PeopleSymptom>();
        ps.good = Random.Range(0, 2) == 0;
        ps.strength = Random.Range(1, 10);
        symptoms.Add(ps);

        TonnelSymptom tons = gameObject.AddComponent<TonnelSymptom>();
        tons.good = Random.Range(0, 3) == 0;
        tons.strength = Random.Range(1, 30);
        symptoms.Add(tons);

        PolitenessSymptom pps = gameObject.AddComponent<PolitenessSymptom>();
        pps.good = Random.Range(0, 2) == 0;
        pps.strength = Random.Range(1, 15);
        symptoms.Add(pps);

        GetComponent<Symptoms>().symptoms = Fisher_Yates_CardDeck_Shuffle(symptoms).ToArray();
    }

    public static List<T> Fisher_Yates_CardDeck_Shuffle<T>(List<T> aList)
    {

        System.Random _random = new System.Random();

        T myGO;

        int n = aList.Count;
        for (int i = 0; i < n; i++)
        {
            // NextDouble returns a random number between 0 and 1.
            // ... It is equivalent to Math.random() in Java.
            int r = i + (int)(_random.NextDouble() * (n - i));
            myGO = aList[r];
            aList[r] = aList[i];
            aList[i] = myGO;
        }

        return aList;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
