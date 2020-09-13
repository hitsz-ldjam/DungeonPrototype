using System;
using System.Collections.Generic;
using ThisGame.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace ThisGame.Status {
    public class StatusBarControl : MonoBehaviour {
        public GameObject statusImagePrefab;

        public Action<StatusDescription> OnStatusAdded, OnStatusRemoved;

        private Transform horiLayout;
        private Dictionary<StatusDescription, StatusDescriptionHolder> currStatus;


        public void AddStatus(StatusDescription desc, bool continuous = true) {
            currStatus.TryGetValue(desc, out var holder);
            if(holder == null) {
                var image = Instantiate(statusImagePrefab, horiLayout, false);
                holder = image.GetComponent<StatusDescriptionHolder>();
                currStatus.Add(desc, holder);

                image.GetComponent<Image>().sprite = desc.statusSprite;
                holder.Desc = desc;
                holder.ReqCount = 0;

                OnStatusAdded(desc);
            }
            if(continuous)
                ++holder.ReqCount;
        }


        public bool RemoveStatus(StatusDescription desc, bool rmall = false) {
            currStatus.TryGetValue(desc, out var holder);
            if(holder == null)
                return false;

            if(rmall || --holder.ReqCount <= 0) {
                Destroy(holder.gameObject);
                currStatus.Remove(desc);
                OnStatusRemoved(desc);
                return true;
            }
            return false;
        }


        private void Awake() {
            horiLayout = transform.GetChild(0);
            currStatus = new Dictionary<StatusDescription, StatusDescriptionHolder>();

            GetComponent<Canvas>().worldCamera = InSceneObjRef.Instance.MainCamera;
        }
    }
}
