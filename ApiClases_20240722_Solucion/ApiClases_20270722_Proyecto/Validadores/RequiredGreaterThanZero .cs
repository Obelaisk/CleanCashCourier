namespace ApiClases_20270722_Proyecto.Validadores;

public class RequiredGreaterThanZero : ValidationAttribute
{

    public override bool IsValid(object value) {
        return value != null && double.TryParse(value.ToString(), out double i) && i > 0.0;
    }
}