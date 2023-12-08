public class Stamina
{
    public int _maxStamina;
    public int _currentStamina;

    public Stamina(int maxStamina)
    {
        _maxStamina = maxStamina;
        _currentStamina = _maxStamina;
    }

    public int ConsumeStamina()
    {
        return _currentStamina = _currentStamina <= 0 ? 0 : _currentStamina-1;
    }

    public int RechargeStamina()
    {
       return _currentStamina = _currentStamina >= _maxStamina ? _maxStamina : _currentStamina+1;
    }

    public int RefillStamina()
    {
        return _currentStamina = _maxStamina;
    }
}