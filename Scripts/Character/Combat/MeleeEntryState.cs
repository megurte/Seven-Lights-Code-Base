namespace Character.Combat
{
    public class MeleeEntryState : State
    {
        public override void OnEnter(StateMachine stateMachine)
        {
            base.OnEnter(stateMachine);

            var nextStateTest = (State)new EntryState();
            StateMachineInstance.SetNextState(nextStateTest);
        }
    }
}