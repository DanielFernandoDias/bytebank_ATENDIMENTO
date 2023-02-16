using bytebank.Modelos.Conta;
using bytebank_ATENDIMENTO.bytebank.Atendimento;
using bytebank_ATENDIMENTO.bytebank.Util;

#region Exemplos Arrays
//TestaBuscarPalavra();
//TestaidadesInt();

void TestaidadesInt()
{
    int[] idades = new int[5]; // Declaro um idades
    idades[0] = 30;
    idades[1] = 40;
    idades[2] = 17;
    idades[3] = 21;
    idades[4] = 18;
    Console.WriteLine($"Tamanho do idades {idades.Length}");

    int acumulador = 0;
    for (int i = 0; i < idades.Length; i++)
    {
        int idade = idades[i];
        Console.WriteLine($"Índice [{i}] = {idade}");
        acumulador += idade;

    }
    int media = acumulador / idades.Length;
    Console.WriteLine($"Média de idades = {media}");
}
void TestaBuscarPalavra()
{
    string[] arrayDePalavras = new string[5];

    for (int i = 0; i < arrayDePalavras.Length; i++)
    {
        Console.WriteLine($"Digite {i + 1}º Palavra");
        arrayDePalavras[i] = Console.ReadLine();
    }

    Console.WriteLine("Digite a Palavra a ser encontrada");
    var busca = Console.ReadLine();

    foreach (string item in arrayDePalavras)
    {
        if (item.Equals(busca))
        {
            Console.WriteLine($"Palavra encontrada {item}");
            break; // Quebra o Foreache e para sua execução
        }
    }
}

Array amostra = Array.CreateInstance(typeof(double), 5); // Outra forma de criar um ARRAY, a partir da classe array
// SetValue, seto valores para um array, sendo o valor para o primeiro paramentro e a posição no segundo
amostra.SetValue(5.9, 0);
amostra.SetValue(1.8, 1);
amostra.SetValue(7.1, 2);
amostra.SetValue(10, 3);
amostra.SetValue(6.9, 4);

//testaMediana(amostra);
void testaMediana(Array array)
{
    if ((array == null) || (array.Length == 0))
    {
        Console.WriteLine("Array para calculo mediano está vazio ou Nulo");
    }
    // Clono o meu Array para outro, assim criando uma nova referencia
    double[] numerosOrdenados = (double[])array.Clone();
    Array.Sort(numerosOrdenados);

    int tamanho = numerosOrdenados.Length;
    int meio = tamanho / 2;
    double mediana = (tamanho % 2 != 0) ? numerosOrdenados[meio] :
        (numerosOrdenados[meio] + numerosOrdenados[meio - 1]) / 2;

    Console.WriteLine($"Com base na amostra a mediana = {mediana}");
}

// ARRAY de OBJETOS
//testaArrayDeContasCorrentes();
void testaArrayDeContasCorrentes()
{
    ListaDeContasCorrentes listaDeContas = new ListaDeContasCorrentes();
    listaDeContas.Adicionar(new ContaCorrente(874, "5653093-A"));
    listaDeContas.Adicionar(new ContaCorrente(874, "3838373-B"));
    listaDeContas.Adicionar(new ContaCorrente(874, "7566455-C"));
    listaDeContas.Adicionar(new ContaCorrente(874, "7566455-C"));
    listaDeContas.Adicionar(new ContaCorrente(874, "7566455-C"));
    listaDeContas.Adicionar(new ContaCorrente(874, "7566455-C"));

    var contaDoAndre = new ContaCorrente(963, "123456-X");
    //listaDeContas.Adicionar(contaDoAndre);
    //listaDeContas.ExibeLista();
    //Console.WriteLine("=============================================");
    //listaDeContas.Remover(contaDoAndre);
    //listaDeContas.ExibeLista();

    for (int i = 0; i < listaDeContas.Tamanho; i++)
    {
        ContaCorrente conta = listaDeContas[i];
        Console.WriteLine($"Indice [{i}] = {conta.Conta}/{conta.Numero_agencia}");
    }
}
#endregion
#region Exemplos do uso do List<>
//generica<int> Teste1 = new generica<int>();
//Teste1.MostrarMensagem(10);
//public class generica<T>
//{
//    public void MostrarMensagem(T t)
//    {
//        Console.WriteLine(t);
//    }
//}

//List<ContaCorrente> _listaDeContas2 = new List<ContaCorrente>()
//{
//    new ContaCorrente(874, "5679787-A"),
//    new ContaCorrente(874, "4456668-B"),
//    new ContaCorrente(874, "7781438-C")
//};

//List<ContaCorrente> _listaDeContas3 = new List<ContaCorrente>()
//{
//    new ContaCorrente(951, "5679787-E"),
//    new ContaCorrente(321, "4456668-F"),
//    new ContaCorrente(719, "7781438-G")
//};

//_listaDeContas2.AddRange(_listaDeContas3);
//_listaDeContas2.Reverse();
//for (int i = 0; i < _listaDeContas2.Count; i++)
//{
//    Console.WriteLine($"Indice[{i}] = Conta [{_listaDeContas2[i].Conta}]");
//}

//Console.WriteLine("\n\n");

//var range = _listaDeContas3.GetRange(0,1); // Funciona como o Splice
//for (int i = 0; i < range.Count; i++)
//{
//    Console.WriteLine($"Indice[{i}] = Conta [{range[i].Conta}]");
//}

//Console.WriteLine("\n\n");

//_listaDeContas3.Clear();
//for (int i = 0; i < _listaDeContas3.Count; i++)
//{
//    Console.WriteLine($"Indice[{i}] = Conta [{_listaDeContas3[i].Conta}]");
//}
#endregion

Console.WriteLine("Boas Vindas ao ByteBank, Atendimento.");

new ByteBankAtendimento().AtendimentoCliente();