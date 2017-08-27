namespace NoteManager.Infrastructure.Constants
{
    public static class ExceptionConstants
    {
        public const string InvalidServer = "La dirección del Servicio Web no es válida.";
        public const string UnconfiguredServer = "No se ha configurado el servidor remoto.";
        public const string BadRequest = "La solicitud es inválida.";
        public const string ExpectationFailed = "Se perdió la sesión con el servidor.";
        public const string Forbidden = "Usuario sin permisos suficientes.";
        public const string InternalServer = "Ocurrió un error en el servidor remoto.";
        public const string MethodNotAllowed = "Método no permitido";
        public const string ServerNotFound = "No es posible conectar con el servidor remoto.";
        public const string InternetConnectivity = "Favor de conectarse a una red de Internet.";
        public const string SessionNotFound = "Favor de iniciar sesión.";
        public const string Conflict = "La solicitud no pudo ser procesada debido a un conflicto con el estado actual del recurso.";
    }
}