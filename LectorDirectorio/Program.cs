// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

//using ;
string pathPedido;
bool existePath;

do
{
    Console.WriteLine("Ingrese el path de un directorio que desea analizar: ");
    pathPedido = Console.ReadLine();
    existePath = Directory.Exists(pathPedido);
    if (existePath)
    {
        foreach (var carpeta in Directory.GetDirectories(pathPedido))
        {
            string infoCarpeta = new DirectoryInfo(carpeta).Name;
            Console.WriteLine(infoCarpeta);
        }
        foreach (var archivo in Directory.GetFiles(pathPedido))
        {
            FileInfo info = new FileInfo(archivo);
            Console.WriteLine(info.Name + " - " + info.Length / 1024 + " KB");
        }

        string csv = pathPedido + @"\reporte_archivos.csv";

        if (!File.Exists(csv))
        {
           using (FileStream fs = File.Create(csv)) { }   // aca lo habia hecho distinto pero me da error porque me dice q no se cierra el archivo una vez abierto. Antes asi:  File.Create(csv);
        }

        FileInfo[] infoArchivos = new DirectoryInfo(pathPedido).GetFiles();

        using (StreamWriter sw = new(csv))
        {
            foreach (var info in infoArchivos)
            {
                sw.WriteLine(info.Name + "," + info.Length / 1024 + "," + info.LastWriteTime);
            }
        }
    }
    else
    {
        Console.WriteLine("el path o ruta al directorio no exite en el disco. Ingrese nuevamente una direccion valida.");
    }
} while(!existePath);
