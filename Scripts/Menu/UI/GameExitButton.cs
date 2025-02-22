using UnityEngine;
using UnityEngine.UI;

public class GameExitButton : MonoBehaviour
{
    private Button _exitBtn;

    private void Start()
    {
        _exitBtn = GetComponent<Button>();

        _exitBtn.onClick.AddListener(() =>
        {
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            return;
            #endif

            Application.Quit();
        });
    }
}
