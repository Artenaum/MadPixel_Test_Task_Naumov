using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.CubeNS {
    public class BaseCube :MonoBehaviour {

        protected Rigidbody rigidbody;
        [SerializeField] protected CubeView cubeView;

        public int currentNumber;
        public int currentIndexOfArray;

        public int maxRandomStartInt = 2;
        [Space]
        [Header("Move")]
        private float horizontalSpeed = 1300;
        private float verticalSpeed = 300;
        [Header("Music")]
        [SerializeField] AudioSource dropAudio;

        private void Awake() {
            rigidbody = GetComponent<Rigidbody>();
        }

        public virtual void Init() {
            cubeView.Init();

            GenerateNum();
            SetNewParam();
        }

        protected void GenerateNum() =>
            currentIndexOfArray = Random.Range(0, maxRandomStartInt);

        public void SetNewParam() {
            cubeView.SetNewParam(currentIndexOfArray);
            currentNumber = (int)Mathf.Pow(2, currentIndexOfArray + 1);
        }

        public virtual void MoveForward() {
            Move(Vector3.forward, horizontalSpeed);
            dropAudio.Play();
        }

        public void MoveToSide(Vector3 vector) => rigidbody.velocity = vector;

        public Vector3 Position {
            get { return transform.position; }
        }

        protected void MoveUp() => Move(Vector3.up, verticalSpeed);

        protected void Move(Vector3 vector, float speed) => rigidbody.AddForce(vector * speed);

        public bool IsCollision {
            set { isCollision = value; }
        }

        private bool isCollision = false;
		
        protected virtual void OnCollisionEnter(Collision collision) {
            if (collision.gameObject.TryGetComponent<Cube>(out Cube otherCube)) {
                if (otherCube.currentIndexOfArray == currentIndexOfArray && !isCollision) {
                    if (isCollision) return;
                    isCollision = true;
                    rigidbody.constraints = RigidbodyConstraints.None;
                    SetValueToManagerList();
                    MoveUp();
                }
            }
        }

        protected virtual void SetValueToManagerList() { }
    }
}