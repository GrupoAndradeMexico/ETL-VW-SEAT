using FTPDescargaArchivos.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FTPDescargaArchivos
{
    class Program
    {
        static void Main(string[] args)
        {
            new Program().CopiaArchivos();            
        }
        public void CopiaArchivos()
        {
            System.DateTime moment = System.DateTime.Now;
            string carpeta = moment.Year.ToString("D4") + moment.Month.ToString("D2") + moment.Day.ToString("D2");
            string pathProcesamiento = @"C:\\Inforserveis\\Nuevos\\" + carpeta;
            new Program().StartInsert(pathProcesamiento);
            //Console.WriteLine("Presione una tecla para salir...");
            //Console.ReadKey();
        }

        public void StartInsert(string directory)
        {
            //directory = directory + @"\\VTANUE01.txt";
            //Console.WriteLine("Se procesa la siguiente ruta: {0}", directory);

            string FileToReadVTANUE01 = directory + @"\\VTANUE01.txt";
            Console.WriteLine("VTANUE01");
            string[] contenidoVTANUE01 = File.ReadAllLines(FileToReadVTANUE01);
            new ProcesaContenido().GuardarVentaUnidad(contenidoVTANUE01, 22, 65);

            string FileToReadVTANUE02 = directory + @"\\VTANUE02.txt";
            Console.WriteLine("VTANUE02");
            string[] contenidoVTANUE02 = File.ReadAllLines(FileToReadVTANUE02);
            new ProcesaContenido().GuardarVentaUnidad(contenidoVTANUE02, 122, 66);


            string FileToReadINVNUE01 = directory + @"\\INVNUE01.txt";
            Console.WriteLine("INVNUE01");
            string[] contenidoINVNUE01 = File.ReadAllLines(FileToReadINVNUE01);
            new ProcesaContenido().GuardarInventarioUnidad(contenidoINVNUE01, 22, 65);

            string FileToReadINVNUE02 = directory + @"\\INVNUE02.txt";
            Console.WriteLine("INVNUE02");
            string[] contenidoINVNUE02 = File.ReadAllLines(FileToReadINVNUE02);
            new ProcesaContenido().GuardarInventarioUnidad(contenidoINVNUE02, 122, 66);

            string FileToReadINVNUE06 = directory + @"\\VTAUSA01.txt";
            Console.WriteLine("VTAUSA01");
            string[] contenidoINVNUE06 = File.ReadAllLines(FileToReadINVNUE06);
            new ProcesaContenido().GuardarVentaUnidadUsado(contenidoINVNUE06, 22, 65);

            string FileToReadINVNUE03 = directory + @"\\INVUSA01.txt";
            Console.WriteLine("INVUSA01");
            string[] contenidoINVNUE03 = File.ReadAllLines(FileToReadINVNUE03);
            new ProcesaContenido().GuardarInventarioUnidadUsado(contenidoINVNUE03, 22, 65);

            string FileToReadINVNUE07 = directory + @"\\VTAUSA02.txt";
            Console.WriteLine("VTAUSA02");
            string[] contenidoINVNUE07 = File.ReadAllLines(FileToReadINVNUE07);
            new ProcesaContenido().GuardarVentaUnidadUsado(contenidoINVNUE07, 122, 66);

            string FileToReadINVNUE08 = directory + @"\\INVUSA02.txt";
            Console.WriteLine("INVUSA02");
            string[] contenidoINVNUE08 = File.ReadAllLines(FileToReadINVNUE08);
            new ProcesaContenido().GuardarInventarioUnidadUsado(contenidoINVNUE08, 122, 66);

            //SERVTA
            string FileToReadSERVTA = directory + @"\\SERVTA01.TXT";
            Console.WriteLine("SERVTA01");
            string[] contenidoSERVTA = File.ReadAllLines(FileToReadSERVTA);
            new ProcesaContenido().GuardarInventarioServicio(contenidoSERVTA, 22, 65, 1);


            FileToReadSERVTA = directory + @"\\SERVTA02.TXT";
            Console.WriteLine("SERVTA02");
            contenidoSERVTA = File.ReadAllLines(FileToReadSERVTA);
            new ProcesaContenido().GuardarInventarioServicio(contenidoSERVTA, 122, 66, 2);

            //SEROEP
            string FileToReadSEROEP = directory + @"\\SEROEP01.TXT";
            Console.WriteLine("SEROEP01");
            string[] contenidoSEROEP = File.ReadAllLines(FileToReadSEROEP);
            new ProcesaContenido().GuardarInventarioSEROEP(contenidoSEROEP, 22, 65, 1);

            FileToReadSEROEP = directory + @"\\SEROEP02.TXT";
            Console.WriteLine("SEROEP02");
            contenidoSEROEP = File.ReadAllLines(FileToReadSEROEP);
            new ProcesaContenido().GuardarInventarioSEROEP(contenidoSEROEP, 122, 66, 2);

            //REFVTAS
            string FileToReadREFVTA = directory + @"\\REFVTA01.TXT";
            Console.WriteLine("REFVTA01");
            string[] contenidoREFVTA = File.ReadAllLines(FileToReadREFVTA);
            new ProcesaContenido().GuardarInventarioREFVTA(contenidoREFVTA, 22, 65, 1);

            FileToReadREFVTA = directory + @"\\REFVTA02.TXT";
            Console.WriteLine("REFVTA02");
            contenidoREFVTA = File.ReadAllLines(FileToReadREFVTA);
            new ProcesaContenido().GuardarInventarioREFVTA(contenidoREFVTA, 122, 66, 2);

            //REFSER 
            string FileToReadREFSER = directory + @"\\REFSER01.TXT";
            Console.WriteLine("REFSER01");
            string[] contenidoREFSER = File.ReadAllLines(FileToReadREFSER);
            new ProcesaContenido().GuardarInventarioREFSER(contenidoREFSER, 22, 65, 1);

            FileToReadREFSER = directory + @"\\REFSER02.TXT";
            Console.WriteLine("REFSER02");
            contenidoREFSER = File.ReadAllLines(FileToReadREFSER);
            new ProcesaContenido().GuardarInventarioREFSER(contenidoREFSER, 122, 66, 2);

            //REFINV
            string FileToReadREFINV = directory + @"\\REFINV01.TXT";
            Console.WriteLine("REFINV01");
            string[] contenidoREFINV = File.ReadAllLines(FileToReadREFINV);
            new ProcesaContenido().GuardarInventarioREFINV(contenidoREFINV, 22, 65);

            FileToReadREFINV = directory + @"\\REFINV02.TXT";
            Console.WriteLine("REFINV02");
            contenidoREFINV = File.ReadAllLines(FileToReadREFINV);
            new ProcesaContenido().GuardarInventarioREFINV(contenidoREFINV, 122, 66);


        }


    }
}
