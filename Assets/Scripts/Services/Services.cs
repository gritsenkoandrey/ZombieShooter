using System;


public sealed class Services
{
    private static readonly Lazy<Services> _instance = new Lazy<Services>();

    public Services()
    {
        Initialize();
    }

    public static Services Instance => _instance.Value;

    public CameraServices CameraServices { get; private set; }
    public ITimeService TimeService { get; private set; }

    private void Initialize()
    {
        CameraServices = new CameraServices();
        TimeService = new TimeService();
    }
}