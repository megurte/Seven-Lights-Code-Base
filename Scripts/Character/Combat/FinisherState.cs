namespace Character.Combat
{
    public class FinisherState : MeleeBaseState
    {
        public override void OnEnter(StateMachine combatStateMachine)
        {
            base.OnEnter(combatStateMachine);
            
            AttackIndex = 3;
            Duration = 0.5f;
            AttackDamage = Weapon.attacks.GetAttackDamageByAttackIndex(AttackIndex);
            Animator.SetTrigger("Attack"+AttackIndex);
        }
        
        public override void OnUpdate()
        {
            base.OnUpdate();

            if (FixedTime >= Duration)
            {
                StateMachineInstance.SetNextStateToMain();
            }
        }
    }
}