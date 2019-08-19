using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GoogleVR.Beta;

public class SeeThroughCamera : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

        bool supported = GvrBetaSettings.IsFeatureSupported(GvrBetaFeature.SeeThrough);
        bool enabled = GvrBetaSettings.IsFeatureEnabled(GvrBetaFeature.SeeThrough);
        if (supported && !enabled)
        {
            GvrBetaFeature[] features = new GvrBetaFeature[] { GvrBetaFeature.SeeThrough };
            GvrBetaSettings.RequestFeatures(features, null);
        }
        

    }

    // Update is called once per frame
    void Update()
    {

        GvrBetaSeeThroughCameraMode camMode = GvrBetaSeeThroughCameraMode.RawImage;
        GvrBetaSeeThroughSceneType sceneType = GvrBetaSeeThroughSceneType.Augmented;
        GvrBetaHeadset.SetSeeThroughConfig(camMode, sceneType);

    }

    private void OnDestroy()
    {
        // Disable see-through when this scene ends.
        GvrBetaHeadset.SetSeeThroughConfig(GvrBetaSeeThroughCameraMode.Disabled,
                                           GvrBetaSeeThroughSceneType.Virtual);
    }

}
