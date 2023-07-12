public interface IAttackable
{

    public void StartMove();
    public void Move();
    public void StartAttack();
    public void Attack();

    public bool CanAttack(float startAttackDistance);
}
