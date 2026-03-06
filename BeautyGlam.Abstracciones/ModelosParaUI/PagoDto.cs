using BeautyGlam.Abstracciones.ModelosParaUI;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
public class PagoDto
{
    [Required(ErrorMessage = "Debe seleccionar un método de pago")]
    public string metodo_Pago { get; set; }
}
