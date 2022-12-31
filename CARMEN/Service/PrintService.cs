using CARMEN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CARMEN.Service
{
    public class PrintService
    {

        public String FormatPrint(String namePrint)
        {
            String ticket = @"{
                    " + "\n" +
                                @"    ""operaciones"": [
                    " + "\n" +
                                @"        {
                    " + "\n" +
                                @"            ""nombre"": ""Operación que no existe"",
                    " + "\n" +
                                @"            ""argumentos"": []
                    " + "\n" +
                                @"        },
                    " + "\n" +
                                @"        {
                    " + "\n" +
                                @"            ""nombre"": ""EstablecerAlineacion"",
                    " + "\n" +
                                @"            ""argumentos"": [
                    " + "\n" +
                                @"                1
                    " + "\n" +
                                @"            ]
                    " + "\n" +
                                @"        },
                    " + "\n" +
                                @"        {
                    " + "\n" +
                                @"            ""nombre"": ""EscribirTexto"",
                    " + "\n" +
                                @"            ""argumentos"": [
                    " + "\n" +
                                @"                ""Hola mundo desde Postman!\nUn barcode:\n""
                    " + "\n" +
                                @"            ]
                    " + "\n" +
                                @"        },
                    " + "\n" +
                                @"        {
                    " + "\n" +
                                @"            ""nombre"": ""ImprimirCodigoDeBarrasCode39"",
                    " + "\n" +
                                @"            ""argumentos"": [
                    " + "\n" +
                                @"                ""123"",
                    " + "\n" +
                                @"                true,
                    " + "\n" +
                                @"                true,
                    " + "\n" +
                                @"                100,
                    " + "\n" +
                                @"                320,
                    " + "\n" +
                                @"                0
                    " + "\n" +
                                @"            ]
                    " + "\n" +
                                @"        },
                    " + "\n" +
                                @"        {
                    " + "\n" +
                                @"            ""nombre"": ""Iniciar"",
                    " + "\n" +
                                @"            ""argumentos"": []
                    " + "\n" +
                                @"        },
                    " + "\n" +
                                @"        {
                    " + "\n" +
                                @"            ""nombre"": ""Feed"",
                    " + "\n" +
                                @"            ""argumentos"": [
                    " + "\n" +
                                @"                2
                    " + "\n" +
                                @"            ]
                    " + "\n" +
                                @"        }
                    " + "\n" +
                                @"    ],
                    " + "\n" +
                                @"    ""nombreImpresora"": 
                      " + "\n" +
                                @"    ""EPSON TM-U220 Facturas"",
                    " + "\n" +
                                @"    ""serial"": """"
                    " + "\n" +
                                @"}";

            return ticket;
        }
    }
}