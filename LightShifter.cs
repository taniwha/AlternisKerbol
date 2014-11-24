﻿//////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////
//Alternis Kerbol project by NovaSilisko - Jool & Duna color maps by Winston//
//You may use this code for reference purposes, all I ask is that you       //
//include a small note in your readme if you use anything from here. If you //
//want to make a derivative mod, just PM me to let me know. I can help out  //
//with any problems (to an extent, I barely understand what's going on here)//
//////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////

using System.Collections.Generic;
using System.Collections;
using System;
using System.IO;
using UnityEngine;

namespace AlternisKerbol
{
    [KSPAddon(KSPAddon.Startup.EveryScene, false)]
    public class LightShifter : MonoBehaviour
    {
        void Start()
        {
            //The lights are instantiated on each scene startup, unlike planets which instantiate at the beginning of the game
            //so a more specific check has to be performed
            if (HighLogic.LoadedScene == GameScenes.TRACKSTATION || HighLogic.LoadedScene == GameScenes.SPACECENTER || HighLogic.LoadedScene == GameScenes.FLIGHT)
            {
                GameObject sunLight = GameObject.Find("SunLight");
                GameObject scaledSunLight = GameObject.Find("Scaledspace SunLight");

                if (sunLight != null)
                {
                    print("LightShifter: Found sunlight and scaled sunlight, shifting...");

                    sunLight.light.color = new Color(1f, 0.92f, 0.85f);
                    sunLight.light.intensity = 0.825f;
                    sunLight.light.shadowStrength = 0.95f;
                    scaledSunLight.light.color = new Color(1f, 0.92f, 0.85f);
                    scaledSunLight.light.intensity = 0.825f;
                }
                else
                {
                    print("LightShifter: Couldn't find either sunlight or scaled sunlight");
                }

                if (HighLogic.LoadedScene == GameScenes.FLIGHT)
                {
                    GameObject IVASun = GameObject.Find("IVASun");

                    if (IVASun != null)
                    {
                        print("LightShifter: Found IVA sun, shifting...");
                        IVASun.light.color = new Color(1f, 0.92f, 0.85f);
                        IVASun.light.intensity = 0.825f;
                    }
                    else
                    {
                        print("LightShifter: No IVA sun found.");
                    }
                }

                LensFlare sunLightFlare = sunLight.gameObject.GetComponent<LensFlare>();

                if (sunLightFlare != null)
                {
                    print("LightShifter: Shifting LensFlare");
                    sunLightFlare.color = new Color(1f, 0.85f, 0.75f, 1f);
                }

                DynamicAmbientLight ambientLight = FindObjectOfType(typeof(DynamicAmbientLight)) as DynamicAmbientLight;

                //Funny story behind locating this one. When I was typing "Light l" in the foreach function earlier, one of the suggestions
                //from the autocomplete was DynamicAmbientLight. Saved me a lot of trial and error looking for it to be sure.

                if (ambientLight != null)
                {
                    print("LightShifter: Found DynamicAmbientLight. Shifting...");
                    ambientLight.vacuumAmbientColor = Color.black;
                }
                else
                {
                    print("LightShifter: Couldn't find DynamicAmbientLight");
                }
            }
        }
    }
}