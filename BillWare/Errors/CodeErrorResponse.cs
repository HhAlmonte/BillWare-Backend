﻿namespace BillWare.API.Errors
{
    public class CodeErrorResponse
    {
        public int StatusCode { get; set; }
        public string? Message { get; set; }

        public CodeErrorResponse(int statusCode, string? message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }

        private string GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "El request enviado tiene errores.",
                401 => "No tienes autorización para este recurso.",
                404 => "No se encontró el recurso solicitado.",
                500 => "Se producieron errores en el servidor.",
                _ => string.Empty
            };
        }
    }
}
