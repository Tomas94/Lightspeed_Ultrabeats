public class Stamina
{
    int _maxStamina;
    public int _currentStamina;

    public Stamina(int maxStamina)
    {
        _maxStamina = maxStamina;
        _currentStamina = _maxStamina;
    }

    public void ConsumeStamina()
    {
        _currentStamina = _currentStamina <= 0 ? 0 : _currentStamina-1;
    }

    public void RechargeStamina()
    {
        _currentStamina = _currentStamina >= _maxStamina ? _maxStamina : _currentStamina+1;
    }

    public void RefillStamina()
    {
        _currentStamina = _maxStamina;
    }
}