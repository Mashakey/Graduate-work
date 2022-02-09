using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.Events;


public class ControllerResourse : MonoBehaviour, ITrackableEventHandler
{
    public string AssetName;
    private GameObject mBundleInstance = null;
    [SerializeField]
    string assetBundleLink = "";
    private bool mAttached = false;
    private TrackableBehaviour mTrackableBehaviour;


    void Start()
    {
        
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }
    }

    IEnumerator DownloadAndCache()
    {
        while (!Caching.ready)
            yield return null;

        Debug.Log("dfdfd");

        using (WWW www = WWW.LoadFromCacheOrDownload(assetBundleLink, 1))
        {
            yield return www;
            if (www.error != null)
                throw new UnityException("WWW Download had an error: " + www.error);

            AssetBundle bundle = www.assetBundle;

            if (AssetName == "")
            {
                mBundleInstance = Instantiate(bundle.mainAsset) as GameObject;
            }
            else
            {
                mBundleInstance = Instantiate(bundle.LoadAsset(AssetName)) as GameObject;
            }
        }
    }

    public void OnTrackableStateChanged(
     TrackableBehaviour.Status previousStatus,
     TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            if (!mAttached && mBundleInstance)
            {

                Debug.Log("masha");
                StartCoroutine(DownloadAndCache());
                // if bundle has been loaded, let's attach it to this trackable
                mBundleInstance.transform.parent = this.transform;
                //mBundleInstance.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
                //mBundleInstance.transform.localPosition = new Vector3(0.0f, 0.15f, 0.0f);
                mBundleInstance.transform.gameObject.SetActive(true);
                mAttached = true;
            }
        }
    }
}