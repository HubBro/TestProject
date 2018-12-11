using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplaySystem : MonoBehaviour {

    private const int bufferFrames = 1000;
    private MyKeyFrame[] keyFrames = new MyKeyFrame[bufferFrames];

    private Rigidbody rigidBody;
    private GameManager gameManager;
    private int timeFire;
    private int startFrame = 0;
    private bool isStart = true;
	// Use this for initialization
	void Start () {

        rigidBody = GetComponent <Rigidbody>();
        gameManager = GameObject.FindObjectOfType<GameManager>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(gameManager.recording)
        {
            startFrame = 0;
            isStart = true;
            Record();
           
        }
        else
        {
            if (isStart)
            {
                startFrame = (Time.frameCount % bufferFrames) ;
            }
            PlayBack();

        }
        
    }

   public void PlayBack()
    {
        isStart = false;
        print("Start " + startFrame);
        rigidBody.isKinematic = true;
        int frame = (Time.frameCount-1) % (startFrame);
        print("Reading frame " + frame);
       
            transform.position = keyFrames[frame].pos;
            transform.rotation = keyFrames[frame].rot;
        
    }

    public void Record()
    {
       
        rigidBody.isKinematic = false;
        int frame = (Time.frameCount-1) % bufferFrames;
        float time = Time.time;
        print("Writing frame " + frame);
        keyFrames[frame] = new MyKeyFrame(time, transform.position, transform.rotation);
    }

}

public struct MyKeyFrame
{
    public Vector3 pos;
    public Quaternion rot;
    public float time;

    public MyKeyFrame( float myTime, Vector3 myPos, Quaternion myRot)
    {
        time = myTime;
        pos = myPos;
        rot = myRot;
    }

    
}
