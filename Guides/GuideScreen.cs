using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GuideScreen : MonoBehaviour
{
    [Header("Texts")]
    public Text[] texts;
    [Header("Images")]
    public Image[] images;
    public Image highlighterImage;
    [Header("Buttons")]
    public Button skipButton;
    public Button closeButton;
    [Header("Other components")]
    public RectTransform highlighterTarget;
    public GuideScenario guideScenario;
    public float animationDuration = 0.5f;
    [Header("Events")]
    public UnityEvent onShowScreen;
    public UnityEvent onScreenShowed;
    public UnityEvent onCloseScreen;

    private IEnumerator highlighterRoutine;

    public void SetText(int id, string text)
    {
        texts[id].text = text;
    }
    public void SetMainImage(int id, Sprite sprite)
    {
        images[id].sprite = sprite;
    }

    public void Show()
    {
        onShowScreen.Invoke();
        foreach (var item in texts)
        {
            item.gameObject.SetActive(false);
        }
        highlighterImage.rectTransform.sizeDelta = new Vector2(1000000f, 1000000f);
        Vector2 targetSD = highlighterTarget.rect.size * 204.8f;
        highlighterImage.rectTransform.position = highlighterTarget.position;
        gameObject.SetActive(true);
        CoroutinesHelper.RenewCoroutine
            (
            this,
            ref highlighterRoutine,
            CoroutinesHelper.AnimateSizeDelta(highlighterImage.rectTransform, targetSD, animationDuration,
            () =>
            {
                foreach (var item in texts)
                {
                    item.gameObject.SetActive(true);
                }
                onScreenShowed.Invoke();
            })
            );
    }
    public void Hide()
    {
        onCloseScreen.Invoke();
        gameObject.SetActive(false);
    }
    public void CloseGuide()
    {
        guideScenario.CloseGuide();
    }
    public void NextScreen()
    {
        guideScenario.NextScreen();
    }
}
