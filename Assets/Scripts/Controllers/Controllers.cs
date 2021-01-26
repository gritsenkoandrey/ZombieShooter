using Interfaces;


public sealed class Controllers : IInitialization, ICleanUp
{
    private readonly IExecute[] _executeControllers;
    private readonly IFixExecute[] _fixExecuteControllers;
    private readonly ILateExecute[] _lateExecuteControllers;
    private readonly ICleanUp[] _cleanUps;
    private readonly IInitialization[] _initializations;

    public byte FixLength { get { return (byte)_fixExecuteControllers.Length; } }
    public short LateLength { get { return (short)_lateExecuteControllers.Length; } }
    public int ExeLength { get { return _executeControllers.Length; } }

    public IFixExecute this[byte index] { get { return _fixExecuteControllers[index]; } }
    public ILateExecute this[short index] { get { return _lateExecuteControllers[index]; } }
    public IExecute this[int index] { get { return _executeControllers[index]; } }

    public Controllers()
    {
        _initializations = new IInitialization[2];
        _initializations[0] = new InputController();
        _initializations[1] = new CameraController();

        _executeControllers = new IExecute[3];
        _executeControllers[0] = new InputController();
        _executeControllers[1] = new TimeRemainingController();
        _executeControllers[2] = new LevelController();

        _fixExecuteControllers = new IFixExecute[1];
        _fixExecuteControllers[0] = new InputController();

        _lateExecuteControllers = new ILateExecute[1];
        _lateExecuteControllers[0] = new CameraController();

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

        for (var i = 0; i < _fixExecuteControllers.Length; i++)
        {
            var fix = _fixExecuteControllers[i];
            if (fix is IInitialization initialization)
            {
                initialization.Initialization();
            }
        }

        for (int i = 0; i < _lateExecuteControllers.Length; i++)
        {
            var late = _lateExecuteControllers[i];
            if (late is IInitialization initialization)
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