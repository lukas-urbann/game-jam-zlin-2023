using UnityEngine;

public class ErrorReporter : MonoBehaviour
{
    //Tohle je jen fancy způsob jak si můžeme posílat chyby, nic víc
    public static void ReportError(GameObject obj, string msg, Component cmp, string custom)
    {
        Debug.LogError("CHYBA! '" + obj.name + "' hlásí chybu '" + msg + "' ve skriptu '" + cmp.name + "'. Vlastní popis: " + custom + ".");
    }
}