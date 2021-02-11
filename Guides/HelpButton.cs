using UnityEngine;
using UnityEngine.UI;

[SelectionBase]
public class HelpButton : MonoBehaviour
{
    public int scenarioId;
    public Button button;

    private void Start()
    {
        UpdateButton(scenarioId);
    }
    public void UpdateButton(int newScenarioId)
    {
        scenarioId = newScenarioId;
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(new UnityEngine.Events.UnityAction(() => { GuideController.Instance.ShowScenario(scenarioId); }));
    }
}
