using UnityEngine;
using UnityEngine.UI;
using System.Text;
using WiimoteApi;

public class ControllerPointer : MonoBehaviour
{
    public Wiimote wiimote;

    void Start()
    {
        Debug.Log("Search Wiimote");
        WiimoteManager.FindWiimotes();
        if (WiimoteManager.Wiimotes.Count > 0)
        {
            wiimote = WiimoteManager.Wiimotes[0];
            wiimote.SetupIRCamera(IRDataType.EXTENDED);
            wiimote.SendPlayerLED(true, false, false, false);
            Debug.Log("Found Wiimote: " + wiimote.hidapi_path);
        }
        else
        {
            Debug.Log("No Wiimote found");
        }
    }

    void Update()
    {
        int ret;
        do
            ret = wiimote.ReadWiimoteData();
        while (ret > 0);

        if (wiimote != null)
        {
            // float[,] ir = wiimote.Ir.GetProbableSensorBarIR();
            // float x = (float)ir[0, 0] / 1023f;
            // float y = (float)ir[0, 1] / 767f;
            var ir = wiimote.Ir.GetPointingPosition();
            if (ir[0] != -1 && ir[1] != -1)
                transform.localPosition = new Vector3((float)(ir[0] - 0.5f) * 5.0f, (float)(ir[1] - 0.5f) * 5.0f + 2.0f, -7.463f);
            Debug.Log("IR: " + ir[0] + ", " + ir[1]);
        }
    }

    void OnApplicationQuit()
    {
        if (wiimote != null)
        {
            WiimoteManager.Cleanup(wiimote);
            wiimote = null;
        }
    }
}