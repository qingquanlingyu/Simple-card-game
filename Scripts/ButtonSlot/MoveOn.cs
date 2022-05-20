using UnityEngine;
using UnityEngine.EventSystems;

public class MoveOn : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Font font;
    public int fontSize = 10;
    [Multiline]//允许多行输入
    public string text = "显示的文本";

    private bool showText = false;
    private GUIStyle style;

    public void Start()
    {
        style = new GUIStyle("box");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        showText = true;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        showText = false;
    }
    public void OnGUI()
    {
        style.font = font;
        style.fontSize = fontSize;
        var vt = style.CalcSize(new GUIContent(text));
        if (showText)
            GUI.Box(new Rect(Input.mousePosition.x + 25, Screen.height - Input.mousePosition.y + 25, vt.x, vt.y), text, style);
    }
}