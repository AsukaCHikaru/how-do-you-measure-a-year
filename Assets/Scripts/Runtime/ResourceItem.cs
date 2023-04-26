using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public struct ResourceTokenPair {
    public TokenObject tokenObject;
    public int cost;
}

public class ResourceItem : MonoBehaviour {
    [SerializeField] internal ResourceObject resourceObject;
    [SerializeField] internal float value;
    [SerializeField] internal float defaultValue;
    [SerializeField] internal float maxValue;
    [SerializeField] private TextMeshProUGUI valueText;
    [SerializeField] internal List<ResourceTokenPair> resourceToTokenMap;

    [SerializeField] private GameObject tokenPrefab;

    private Transform tokenParent;

    void Start() {
        value = defaultValue;
        tokenParent = GameObject.Find("Tokens").transform;
    }

    void LateUpdate () {
        UpdateUI();
    }

    internal void Consume() {
        Manipulate(resourceObject.consumptionPerDay * -1);
    }

    internal void Manipulate (float difference) {
        // Debug.Log($"{resourceObject.name} {difference}");
        value += difference;
        if (value > maxValue) {
            value = maxValue;
        }
        CheckTokenGeneration();
    }

    void CheckTokenGeneration () {
        Dictionary<string, int> tokenNumberMap = new Dictionary<string, int>();

        foreach (TokenItem tokenItem in tokenParent.GetComponentsInChildren<TokenItem>()) {
            int thisTokenCount = 0;
            tokenNumberMap.TryGetValue(tokenItem.tokenObject.name, out thisTokenCount);
            tokenNumberMap[tokenItem.tokenObject.name] = thisTokenCount + 1;
        }

        foreach(ResourceTokenPair pair in resourceToTokenMap) {
            int expectedTokenCount = (int)Mathf.Floor(value / pair.cost);
            if (expectedTokenCount < 0) expectedTokenCount = 0;
            int currentTokenCount = 0;
            tokenNumberMap.TryGetValue(pair.tokenObject.name, out currentTokenCount);
            
            if (expectedTokenCount > currentTokenCount) {
                for(int count = 0; count < expectedTokenCount - currentTokenCount; count++) {
                    GameObject newToken = Instantiate(tokenPrefab, Vector3.zero, Quaternion.identity);
                    newToken.transform.SetParent(tokenParent);
                    newToken.transform.name = pair.tokenObject.name;
                    newToken.GetComponent<TokenItem>().SetToken(pair.tokenObject);
                }
            }

            if (expectedTokenCount < currentTokenCount) {
                int countDiff = currentTokenCount - expectedTokenCount;
                int deleteCount = 0;
                foreach (TokenItem tokenItem in tokenParent.GetComponentsInChildren<TokenItem>()) {
                    if (tokenItem.tokenObject.name == pair.tokenObject.name && deleteCount < countDiff) {
                        Destroy(tokenItem.gameObject);
                        deleteCount++;
                    }
                }
            }
        }
    }

    void UpdateUI() {
        valueText.text = Mathf.Floor(value).ToString();
    }
}
