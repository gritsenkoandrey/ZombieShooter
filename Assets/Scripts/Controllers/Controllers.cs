using Interfaces;


public sealed class Controllers : IInitialization, ICleanUp
{
    private readonly IExecute[] _executeControllers;
    private readonly ICleanUp[] _cleanUps;
    private readonly IInitialization[] _initializations;

    public int Length { get { return _executeControllers.Length; } }
    public IExecute this[int index] { get { return _executeControllers[index]; } }

    public Controllers()
    {
        _initializations = new IInitialization[0];

        _executeControllers = new IExecute[1];
        _executeControllers[0] = new InputController();

        _cleanUps = new ICleanUp[0];
    }

    public void Initialization()
    {
        for (var i = 0; i < _initializations.Length; i++)
        {
            var initialization = _initializations[i];
            initialization.Initialization();
        }

        for (var i = 0; i < _executeControllers.Length; i++)
        {
            var execute = _executeControllers[i];
            if (execute is IInitialization initialization)
            {
                initialization.Initialization();
            }
        }
    }

    public void Cleaner()
    {
        for (var index = 0; index < _cleanUps.Length; index++)
        {
            var cleanUp = _cleanUps[index];
            cleanUp.Cleaner();
        }
    }
}