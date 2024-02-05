using UnityEditor;
using UnityEngine;
 
[InitializeOnLoad]
public class BetterEditorCamera
{
    private const float CAMERA_SPEED = -0.25f;
 
    private static bool rmbDown = false;
 
    static BetterEditorCamera()
    {
        SceneView.beforeSceneGui -= OnScene;
        SceneView.beforeSceneGui += OnScene;
    }
 
    private static void OnScene( SceneView scene )
    {
        Event e = Event.current;
        if( e.isMouse && e.button == 1 )
        {
            if( e.type == EventType.MouseDown )
                rmbDown = true;
            else if( e.type == EventType.MouseUp )
                rmbDown = false;
        }
     
        if( e.isScrollWheel && rmbDown )
        {
            Vector3 pivot = scene.pivot;
            pivot += scene.camera.transform.forward * ( e.delta.y * CAMERA_SPEED );
            scene.pivot = pivot;
 
            e.Use();
        }
    }
}

/* I made the script found in the forum below into a VPM package.
Please contact me if you have any problems
https://forum.unity.com/threads/new-editor-camera-controls-in-2019-1-are-great-but.664378/ */
