using System;

namespace BeautyGlam.Abstracciones.ModelosParaUI
{
    public class PasswordResetDto
    {
        public int id_Reset { get; set; }
        public int id_Usuario { get; set; }
        public DateTime fecha_Expira { get; set; }
        public bool usado { get; set; }
    }
}
