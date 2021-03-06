//////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////
//Alternis Kerbol project by NovaSilisko - Jool & Duna color maps by Winston//
//You may use this code for reference purposes, all I ask is that you       //
//include a small note in your readme if you use anything from here. If you //
//want to make a derivative mod, just PM me to let me know. I can help out  //
//with any problems (to an extent, I barely understand what's going on here)//
//////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////

using System.Collections;
using System;
using System.IO;
using UnityEngine;

namespace AlternisKerbol
{
    public class CometLogic : MonoBehaviour
    {
        public bool dustTail = false;
        public Orbit cometOrbit;
        public GameObject visual;
        public Transform target;
        public Transform sun;
        //private float reportsteps = 0;
        //private float stepsforreport = 5;
        //^debug crap
        private AnimationCurve ionOpacityCurve;
        private AnimationCurve dustOpacityCurve;
//        private float velocity;
        public float brightness = 1.0f; //Global brightness multiplier, for configuration on each object a comet tail is added to

        void Start()
        {
            print("CometLogic: Starting! Gameobject " + gameObject.name + ", parent " + transform.parent.gameObject.name);
            if (sun != null && target != null)
            {
                print("Sun and target are valid");
            }

            if (visual != null)
            {
                visual.layer = target.gameObject.layer;
                visual.renderer.material.shader = Shader.Find("Particles/Additive");
                visual.renderer.material.SetColor("_TintColor", Color.black);
            }
            else
            {
                print("SNAFU! Comet could not find visual object!");
            }

            //Set the curves for opacity of either type of tail

            ionOpacityCurve = new AnimationCurve();

            ionOpacityCurve.AddKey(600000, 0.3f);
            ionOpacityCurve.AddKey(5000000, 0.025f);
            ionOpacityCurve.AddKey(15000000, 0.0f);

            dustOpacityCurve = new AnimationCurve();

            dustOpacityCurve.AddKey(600000, 0.5f);
            dustOpacityCurve.AddKey(7000000, 0.025f);
            dustOpacityCurve.AddKey(35000000, 0.0f);

        }

        void LateUpdate()
        {
            /*reportsteps += Time.deltaTime;
            if (reportsteps >= stepsforreport)
            {
                print("CometLogic "+gameObject.name+": Running!");
                print(transform.position.ToString());
                print(target.gameObject.name);
                print(Vector3.Distance(sun.position, target.position));
                print(velocity);
                reportsteps = 0;
            }*/

            //^debug function for periodically spitting out status reports

            if (target != null && visual != null && sun != null)
            {
                if (dustTail)
                {
                    if (cometOrbit != null)
                    {
                        Vector3 orbitVector = (cometOrbit.getPositionAtUT(Planetarium.GetUniversalTime() + 1) - cometOrbit.getPositionAtUT(Planetarium.GetUniversalTime())) * 0.00001f;

                        //velocity = orbitVector.magnitude;
                        
                        Vector3 lookVector = Vector3.Normalize(orbitVector - (Vector3.Normalize(transform.position - sun.position) * 0.5f));
                        transform.LookAt(transform.position + lookVector * 100);

                        float opacity = dustOpacityCurve.Evaluate(Vector3.Distance(target.position, sun.position));
                        if (opacity > 0.001f)
                        {
                            visual.renderer.material.SetColor("_TintColor", new Color(0.16f, 0.15f, 0.135f, opacity * brightness));
                        }
                        else
                        {
                            visual.renderer.material.SetColor("_TintColor", Color.black);
                        }
                    }
                }
                else
                {
                    transform.LookAt(sun);

                    float opacity = ionOpacityCurve.Evaluate(Vector3.Distance(target.position, sun.position));
                    if (opacity > 0.001f)
                    {
                        visual.renderer.material.SetColor("_TintColor", new Color(0.06f, 0.09f, 0.2f, opacity * brightness));
                    }
                    else
                    {
                        visual.renderer.material.SetColor("_TintColor", Color.black);
                    }
                }
            }
        }
    }
}
