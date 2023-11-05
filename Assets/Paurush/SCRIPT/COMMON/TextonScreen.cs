using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextonScreen : MonoBehaviour
{
    public ExamineManager examineManager;
    [Tooltip("id=1 for instruction, 2 for description")]
    public int idTextonScreen;
    private void OnEnable()
    {
        examineManager.DisPlayTextOnScreen(idTextonScreen);
    }
}
