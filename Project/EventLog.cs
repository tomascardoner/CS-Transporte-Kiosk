using System;
using System.Data;
using System.Data.SqlClient;

namespace CSTransporteKiosk
{
    static class EventLog
    {
        public const string TipoInformacion = "I";
        public const string TipoAviso = "A";
        public const string TipoError = "E";
        public const string TipoLoginExitoso = "S";
        public const string TipoLoginFallido = "F";

        public const string MensajeLoginExitoso = "La terminal ha iniciado sesión correctamente.";
        public const string MensajeLoginFallido = "La terminal falló al intentar iniciar sesión.";

        static public bool Agregar(CardonerSistemas.Database_ADO_SQLServer database, string tipo, byte idKiosko, string mensaje, string notas)
        {
            if (tipo == TipoInformacion | tipo == TipoAviso | tipo == TipoError | tipo == TipoLoginExitoso | tipo == TipoLoginFallido)
            {
                try
                {
                    SqlCommand command = new SqlCommand("usp_EventLog_Agregar", database.connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Tipo", tipo);
                    command.Parameters.AddWithValue("@IDKiosko", idKiosko);
                    command.Parameters.AddWithValue("@Mensaje", mensaje);
                    command.Parameters.AddWithValue("@Notas", notas);

                    command.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    CardonerSistemas.Error.ProcessError(ex, "Error al registrar el log del evento.");
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
