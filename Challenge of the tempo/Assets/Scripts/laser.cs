using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using System;
using UnityEngine;
using UnityEditor;
//most of the code here is from third party source from unity store
//known as Hovel studio


public class laser : MonoBehaviour
{
    public float laserScale = 1;
    public Color laserColor = new Vector4(1, 1, 1, 1);
    public GameObject HitEffect;
    public GameObject FlashEffect;
    public float HitOffset = 0;
    public float MaxLength;

    public GameOverScreen gameOver;

    private bool UpdateSaver = false;
    private ParticleSystem laserPS;
    private ParticleSystem[] Flash;
    private ParticleSystem[] Hit;
    private Material laserMat;
    private int particleCount;
    private ParticleSystem.Particle[] particles;
    private Vector3[] particlesPositions;
    private float dissovleTimer = 0;
    private bool startDissovle = false;
    public RaycastHit hit;
     void Start()
    {
        laserPS = GetComponent<ParticleSystem>();
        laserMat = GetComponent<ParticleSystemRenderer>().material;
        Flash = FlashEffect.GetComponentsInChildren<ParticleSystem>();
        Hit = HitEffect.GetComponentsInChildren<ParticleSystem>();
        laserMat.SetFloat("_Scale", laserScale);
    }

   

     void Update()
    {
        if (laserPS != null && UpdateSaver == false)
        {
            //Set start laser point
            laserMat.SetVector("_StartPoint", transform.position);
            //Set end laser point
            

          
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, MaxLength))
            { 
                // set particle number depending on distance
                particleCount = Mathf.RoundToInt(hit.distance / (2 * laserScale));
                if (particleCount < hit.distance / (2 * laserScale))
                {
                    // increase particle number if laser became longer (laser is particles that appear every 2 units)
                    particleCount += 1;
                }
                particlesPositions = new Vector3[particleCount];
                AddParticles();

                // set tiling distance in the material
                laserMat.SetFloat("_Distance", hit.distance);
                // make laser invisible after end point because laser clusters is 2 units
                laserMat.SetVector("_EndPoint", hit.point); //end of the laser line stops once it hits any collision such as a wall or player

               

                //hit effects position when laser hits a wall or object
                if (Hit != null)
                {


                    HitEffect.transform.position = hit.point + hit.normal * HitOffset;
                    HitEffect.transform.LookAt(hit.point);
                    foreach (var AllHits in Hit)
                    {
                        if (!AllHits.isPlaying) AllHits.Play();
                    }
                    foreach (var AllFlashes in Flash)
                    {
                        if (!AllFlashes.isPlaying) AllFlashes.Play();
                    }
                }


                if (hit.transform.tag=="player")
                {
                    killPlayer();
                }
            }
            else
            {
                //End laser position if doesn't collide with object depending on MaxLength
                var EndPos = transform.position + transform.forward * MaxLength;
                var distance = Vector3.Distance(EndPos, transform.position);
                particleCount = Mathf.RoundToInt(distance / (2 * laserScale));
                if (particleCount < distance / (2 * laserScale))
                {
                    // increase particle number if laser is longer (laser is particles that appear every 1 unit)
                    particleCount += 1;
                }
                particlesPositions = new Vector3[particleCount];
                AddParticles();

                // set tiling distance in the material
                laserMat.SetFloat("_Distance", distance);
                // make laser invisible after end point because laser clusters is 2 units
                laserMat.SetVector("_EndPoint", EndPos);
                if (Hit != null)
                {
                    HitEffect.transform.position = EndPos;
                    foreach (var AllPs in Hit)
                    {
                        if (AllPs.isPlaying) AllPs.Stop();
                    }
                }
            }
        }

        if (startDissovle)
        {
            // set dissolve speed depending on dissovleTimer value
            dissovleTimer += Time.deltaTime;
            laserMat.SetFloat("_Dissolve", dissovleTimer * 5);
        }
    }

    //basic function to stop time and call the GameOver function
    void killPlayer()
    {
        Time.timeScale = 0;
        gameOver.GameOver();
    }


    void AddParticles()
    { 
        //number of particles depends on Raycast distance
        particles = new ParticleSystem.Particle[particleCount];

        for (int i = 0; i < particleCount; i++)
        {
            //calcalate distance for every next particle to set positions along the raycast
            particlesPositions[i] = new Vector3(0f, 0f, 0f) + new Vector3(0f, 0f, i * 2 * laserScale);
            particles[i].position = particlesPositions[i];
            particles[i].startSize3D = new Vector3(0.001f, 0.001f, 2 * laserScale);
            particles[i].startColor = laserColor;
        }
        //set distance for every next particle to set positions along the raycast
        laserPS.SetParticles(particles, particles.Length);
    }

    //check where the end laser position is at in the z axis
    public float GetEndLaserPosition()
    {
        return hit.point.z;
    }

    //start of laser position along the z axis
    public float GetStartLaserPosition()
    {
        return transform.position.z;
    }


}

