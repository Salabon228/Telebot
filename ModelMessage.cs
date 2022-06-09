public struct ModelMessage
{
    public string Index; // Индекс
    public string City; // Город
    public string DtTxT; // Прогнозируемое время и дата
    public string Description;  // Описание "переменная облачность"
    public string Temp; // Температура
    public string Humidity; // Влажность
    public string WindSpeed;    // скорость ветра
    public string WindDeg;  // Направление ветра в градусах
    public string WindGust; // Порывы ветра
    public string Visibility; // Средняя видимость
    public string Pop; // Вероятность осадков от 0 (0)% до 1 (100%)
    
    

    public override string ToString()
    {
        return $"{FirstName} {MessageText}";
    }
}