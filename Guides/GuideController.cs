using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Система показа подсказок на экране.
/// </summary>
public class GuideController : MonoBehaviour
{
    public GuideScenario[] scenarios;
    public GuideScreen lastScreen;
    public GuideScenario lastScenario;
    public Canvas canvas;
    public UnityEvent onFirstStart;
    public bool showGuideAtFirstStart = false;

    public static GuideController Instance;
    private void Awake()
    {
        Instance = this;
        canvas = transform.GetComponentInParent<Canvas>();
        scenarios = GetComponentsInChildren<GuideScenario>();
    }
    /// <summary>
    /// Показывает указанный экран указанного сценария.
    /// </summary>
    /// <param name="scenarioId">Индекс сценария</param>
    /// <param name="screenId">Индекс экрана</param>
    private void ShowScreen(int scenarioId, int screenId)
    {
        lastScenario = scenarios[scenarioId];
        HideAllScreens(scenarioId);
        lastScenario.gameObject.SetActive(true);
        lastScreen = lastScenario.ShowScreen(screenId);
    }
    /// <summary>
    /// Показывает указанный экран указанного сценария.
    /// </summary>
    /// <param name="scenarioName">Имя сценария (имя объекта сценария)</param>
    /// <param name="screenId">Индекс экрана</param>
    private void ShowScreen(string scenarioName, int screenId)
    {
        for (int i = 0; i < scenarios.Length; i++)
        {
            if (scenarios[i].name == scenarioName)
            {
                lastScenario = scenarios[i];
                HideAllScreens(i);
                lastScenario.gameObject.SetActive(true);
                lastScreen = lastScenario.ShowScreen(screenId);
            }
        }
    }
    /// <summary>
    /// Показывает первый экран указанного сценария.
    /// </summary>
    /// <param name="id">Индекс сценария</param>
    public void ShowScenario(int id)
    {
        HideAllScenarios();
        gameObject.SetActive(true);
        ShowScreen(id, 0);
    }
    /// <summary>
    /// Показывает первый экран указанного сценария.
    /// </summary>
    /// <param name="scenarioName">Имя сценария</param>
    public void ShowScenario(string scenarioName)
    {
        HideAllScenarios();
        gameObject.SetActive(true);
        for (int i = 0; i < scenarios.Length; i++)
        {
            if (scenarios[i].name == scenarioName)
            {
                ShowScreen(i, 0);
            }
        }
    }
    /// <summary>
    /// Закрывает все гайды.
    /// </summary>
    public void CloseGuide()
    {
        gameObject.SetActive(false);
    }
    /// <summary>
    /// Скрывает экраны всех сценариев.
    /// </summary>
    private void HideAllScenarios()
    {
        for (int i = 0; i < scenarios.Length; i++)
        {
            scenarios[i].gameObject.SetActive(false);
        }
    }
    /// <summary>
    /// Скрывает все экраны указанного сценария.
    /// </summary>
    /// <param name="scenarioId">Индекс сценария</param>
    private void HideAllScreens(int scenarioId)
    {
        foreach (var item in scenarios[scenarioId].screens)
        {
            item.Hide();
        }
    }
}
