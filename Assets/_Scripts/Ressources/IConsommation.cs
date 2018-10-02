

public interface IConsommation  {
    int Conso { get; }
    int ConsoBoost { get; }
    bool BoostConso();
    bool StartConsommation();
    void StopConsommation();
    void FailConsommation();
}
