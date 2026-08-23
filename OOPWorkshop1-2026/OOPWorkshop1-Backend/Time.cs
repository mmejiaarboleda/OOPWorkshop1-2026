namespace OOPWorkshop_1.Backend;

public class Time
{
    // Fields 

    private int _hour;
    private int _millisecond;
    private int _minute;
    private int _second;

    // Constructors

    //Without Parameters 
    public Time()
    {
        _hour = 0;
        _millisecond = 0;
        _minute = 0;
        _second = 0;
    }

    //With Hours 
    public Time(int hour)
    {
        Hour = hour;
    }

    //with hours and minutes 
    public Time(int hour, int minute)
    {
        Hour = hour;
        Minute = minute;
    }

    //with hours, minutes and seconds 
    public Time(int hour, int minute, int second)
    {
        Hour = hour;
        Minute = minute;
        Second = second;
    }

    //with hours, minutes, seconds and milliseconds 

    public Time(int hour, int minute, int second, int millisecond)
    {
        Hour = hour;
        Minute = minute;
        Second = second;
        Millisecond = millisecond;
    }


    // Properties
    public int Hour
    {
        get => _hour;
        set => _hour = ValidHour(value);
    }
    public int Millisecond
    {
        get => _millisecond;
        set => _millisecond = ValidMillisecond(value);
    }
    public int Minute
    {
        get => _minute;
        set => _minute = ValidMinute(value);
    }
    public int Second
    {
        get => _second;
        set => _second = ValidSecond(value);
    }

    //Method ToString
    public override string ToString()
    {
        int hour12 = _hour;

        if (hour12 > 12)
            hour12 = hour12 - 12;

        if (hour12 == 0)
            hour12 = 12;

        string period = "AM";

        if (_hour >= 12)
            period = "PM";

        return $"{hour12:D2}:{_minute:D2}:{_second:D2}.{_millisecond:D3} {period}";
    }

    //Method ToMilliseconds
    public int ToMilliseconds()
    {
        if (_hour < 0 || _hour > 23 ||
            _minute < 0 || _minute > 59 ||
            _second < 0 || _second > 59 ||
            _millisecond < 0 || _millisecond > 999)
            return 0;

        return (_hour * 3600000) +
               (_minute * 60000) +
               (_second * 1000) +
               _millisecond;
    }

    //Method ToSeconds
    public int ToSeconds()
    {
        if (_hour < 0 || _hour > 23 ||
            _minute < 0 || _minute > 59 ||
            _second < 0 || _second > 59)
            return 0;

        return (_hour * 3600) +
               (_minute * 60) +
               _second;
    }

    //Method ToMinutes
    public int ToMinutes()
    {
        if (_hour < 0 || _hour > 23 ||
            _minute < 0 || _minute > 59)
            return 0;

        return (_hour * 60) +
               _minute;
    }

    //Method IsOtherDay
    public bool IsOtherDay(Time other)
    {
        int totalMilliseconds = this.ToMilliseconds() + other.ToMilliseconds();

        int millisecondsPerDay = 24 * 60 * 60 * 1000;

        if (totalMilliseconds >= millisecondsPerDay)
            return true;
        else
            return false;
    }

    //Method Add
    public Time Add(Time other)
    {
        // Sumar milisegundos de ambos tiempos
        int totalMilliseconds = this.ToMilliseconds() + other.ToMilliseconds();

        // Milisegundos que tiene un día completo
        int millisecondsPerDay = 24 * 60 * 60 * 1000;

        // Si se pasa del día, ajustamos
        totalMilliseconds = totalMilliseconds % millisecondsPerDay;

        // Convertimos nuevamente a horas, minutos, segundos y milisegundos

        int hour = totalMilliseconds / 3600000;
        totalMilliseconds = totalMilliseconds % 3600000;

        int minute = totalMilliseconds / 60000;
        totalMilliseconds = totalMilliseconds % 60000;

        int second = totalMilliseconds / 1000;
        int millisecond = totalMilliseconds % 1000;

        return new Time(hour, minute, second, millisecond);
    }


    //Property validations

    private int ValidHour(int value)
    {
        if (value < 0 || value > 23)
            throw new ArgumentException($"The hour: {value}, is not valid.");

        return value;
    }

    private int ValidMillisecond(int value)
    {
        if (value < 0 || value > 999)
            throw new ArgumentOutOfRangeException(nameof(value), "Millisecond must be between 0 and 999.");

        return value;
    }

    private int ValidMinute(int value)
    {
        if (value < 0 || value > 59)
            throw new ArgumentOutOfRangeException(nameof(value), "Minute must be between 0 and 59.");

        return value;
    }

    private int ValidSecond(int value)
    {
        if (value < 0 || value > 59)
            throw new ArgumentOutOfRangeException(nameof(value), "Second must be between 0 and 59.");

        return value;
    }


}

