using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Сценарий гайда. Содержит в себе набор экранов.
/// </summary>
public class GuideScenario : MonoBehaviour
{
    public GuideScreen[] screens;
    public UnityEvent onScenarioEnd;
    public UnityEvent onScenarioStart;

    private int currScreen = 0;
    private void Awake()
    {
        screens = transform.GetComponentsInChildren<GuideScreen>(true);
    }
    /// <summary>
    /// Показывает следующий экран сценария.
    /// </summary>
    public void NextScreen()
    {
        screens[currScreen].Hide();
        currScreen++;
        if (currScreen > screens.Length - 1)
        {
            OnScenarioEnd();
        }
        else
        {
            screens[currScreen].Show();
        }
    }
    /// <summary>
    /// Закрывает гайд.
    /// </summary>
    public void CloseGuide()
    {
        GuideController.Instance.CloseGuide();
    }
    /// <summary>
    /// Вызывается, когда был закрыт последний экран сценария.
    /// </summary>
    private void OnScenarioEnd()
    {
        onScenarioEnd.Invoke();
    }
    /// <summary>
    /// Показывает экран.
    /// </summary>
    /// <param name="id">Индекс экрана</param>
    /// <returns>Экран, который был открыт</returns>
    public GuideScreen ShowScreen(int id)
    {
        if (currScreen >= 0 && currScreen < screens.Length) screens[currScreen].Hide();
        screens[id].Show();
        currScreen = id;
        return screens[id];
    }
    /// <summary>
    /// Запускает сценарий с первого экрана.
    /// </summary>
    public void StartScenario()
    {
        currScreen = 0;
        onScenarioStart.Invoke();
        screens[currScreen].Show();
    }
}
