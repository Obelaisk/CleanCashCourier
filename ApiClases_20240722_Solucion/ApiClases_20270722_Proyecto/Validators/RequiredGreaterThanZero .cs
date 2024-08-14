﻿namespace ApiClases_20270722_Proyecto.Validators;

public class RequiredGreaterThanZero : ValidationAttribute{
   
    public override bool IsValid(object value) {
        //HOLAAAAAAAAA
        return value != null && double.TryParse(value.ToString(), out double i) && i > 0.0;
    }
}