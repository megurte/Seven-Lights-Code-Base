using UnityEngine;

namespace Character.Combat
{
    public abstract class State
    {
        public StateMachine StateMachineInstance;
        protected PlayerInputService PlayerInputService;
        protected float UpdateTime { get; set; }
        protected float FixedTime { get; set; }
        protected float LateTime { get; set; }

        public virtual void OnEnter(StateMachine stateMachineArg)
        {
            StateMachineInstance = stateMachineArg;
        }
        
        public virtual void OnUpdate()
        {
            UpdateTime += Time.deltaTime;
        }
        
        public virtual void OnFixedUpdate()
        {
            FixedTime += Time.deltaTime;
        }
        
        public virtual void OnLateUpdate()
        {
            LateTime += Time.deltaTime;
        }
        
        public virtual void OnExit()
        {
            
        }
        
        /// <summary>
        /// Removes a gameobject, component, or asset.
        /// </summary>
        /// <param name="obj">The type of Component to retrieve.</param>
        protected static void Destroy(Object obj)
        {
            Object.Destroy(obj);
        }

        /// <summary>
        /// Returns the component of type T if the game object has one attached, null if it doesn't.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        protected T GetComponent<T>() where T : Component { return StateMachineInstance.GetComponent<T>(); }

        /// <summary>
        /// Returns the component of Type <paramref name="type"/> if the game object has one attached, null if it doesn't.
        /// </summary>
        /// <param name="type">The type of Component to retrieve.</param>
        /// <returns></returns>
        protected Component GetComponent(System.Type type) { return StateMachineInstance.GetComponent(type); }

        /// <summary>
        /// Returns the component with name <paramref name="type"/> if the game object has one attached, null if it doesn't.
        /// </summary>
        /// <param name="type">The type of Component to retrieve.</param>
        /// <returns></returns>
        protected Component GetComponent(string type) { return StateMachineInstance.GetComponent(type); }
    }
}