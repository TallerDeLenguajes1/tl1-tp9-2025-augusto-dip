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
    if(!existePath)
    {
        Console.WriteLine("el path o ruta al directorio no exite en el disco. Ingrese nuevamente una direccion valida.");
    }
} while(!existePath);


