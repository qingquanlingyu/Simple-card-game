using UnityEngine;
using UnityEngine.UI;

public class TestButton : Button
{
    public string str;
    enum Selection  
    {
        Normal,
        Highlighted,
        Pressed,
        Disabled
    }
    Selection selection;

    protected override void DoStateTransition(SelectionState state, bool instant)
    {
        base.DoStateTransition(state, instant);
        switch (state)
        {
            //ËÄÖÖ×´Ì¬
            case SelectionState.Normal:
                selection = Selection.Normal;
                break;
            case SelectionState.Highlighted:
                selection = Selection.Highlighted;
                break;
            case SelectionState.Pressed:
                selection = Selection.Pressed;
                break;
            case SelectionState.Disabled:
                selection = Selection.Disabled;
                break;
            default:
                break;
        }
    }

    private void OnGUI()
    {
        GUI.skin.box.fontSize = 10;
        switch (selection)
        {
            case Selection.Pressed:
                GUI.Label(new Rect(Input.mousePosition.x, Screen.height - Input.mousePosition.y, 100, 50), str);
                break;
            default:
                break;
        }
    }
}