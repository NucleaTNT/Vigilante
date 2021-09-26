namespace Dev.NucleaTNT.Vigilante.Interfaces
{
    public interface IHealth
    {
        // Granted, these two methods do almost the same thing and could be combined
        // into one single method, however I feel it's more clear like this
        void Heal(int amount);
        void TakeDamage(int amount);
    }
}