using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
public static class GameMouseToSceneView
{
    static GameMouseToSceneView()
    {
        SceneView.duringSceneGui += OnSceneGUI;
    }

    private static void OnSceneGUI(SceneView sceneView)
    {
        if (!Application.isPlaying)
            return;

        Camera gameCam = Camera.main;
        if (gameCam == null)
            return;

        Vector3 mouse = Input.mousePosition;

        
        float z = Mathf.Abs(gameCam.transform.position.z);

        Vector3 worldPos = gameCam.ScreenToWorldPoint(new Vector3(mouse.x, mouse.y, z));
        worldPos.z = 0f;

        Handles.color = Color.black;
        Handles.DrawWireDisc(worldPos, Vector3.forward, 0.2f);
        Handles.DrawLine(worldPos + Vector3.left * 0.25f, worldPos + Vector3.right * 0.25f);
        Handles.DrawLine(worldPos + Vector3.up * 0.25f, worldPos + Vector3.down * 0.25f);

        sceneView.Repaint();
    }
}

