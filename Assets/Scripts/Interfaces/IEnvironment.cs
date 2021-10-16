using Dev.NucleaTNT.Vigilante.Utilities;

namespace Dev.NucleaTNT.Vigilante.Interfaces
{
    public interface IEnvironment
    {
        void EnvironmentUpdate(EnvironmentType environmentType, bool isEntering);
    }
}