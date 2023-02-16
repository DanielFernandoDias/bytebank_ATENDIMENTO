using bytebank.Modelos.Conta;
using bytebank_ATENDIMENTO.bytebank.Exceptions;

namespace bytebank_ATENDIMENTO.bytebank.Atendimento
{
    internal class ByteBankAtendimento
    {


        private List<ContaCorrente> _listaDeContas = new List<ContaCorrente>
        {
            new ContaCorrente(95, "123456-X") {Saldo=100, Titular = new Cliente{Cpf = "11111", Nome = "Henrique"} },
            new ContaCorrente(95, "951258-X") {Saldo=200, Titular = new Cliente{Cpf = "22222", Nome = "Pedro"}},
            new ContaCorrente(94, "987321-W") {Saldo=60, Titular = new Cliente{Cpf = "33333", Nome = "Marisa"}}
        };
        public void AtendimentoCliente()
        {
            try
            {
                char opcao = '0';
                while (opcao != '6')
                {
                    Console.Clear();
                    Console.WriteLine("=================================");
                    Console.WriteLine("====        Atendimento      ====");
                    Console.WriteLine("====1 - Cadastrar Contas     ====");
                    Console.WriteLine("====2 - Listar Contas        ====");
                    Console.WriteLine("====3 - Remover Contas       ====");
                    Console.WriteLine("====4 - Ordenar Contas       ====");
                    Console.WriteLine("====5 - Pesquisar Contas     ====");
                    Console.WriteLine("====6 - Sair do sistema      ====");
                    Console.WriteLine("=================================");
                    Console.WriteLine("\n"); // Quebra de linha
                    Console.Write("Digite a Opção Desejada: ");
                    try
                    {
                        opcao = Console.ReadLine()[0]; // O Readline retornar uma string, string é como se fosse um array/vetor de caracteres e o indexador [0] retorna a primeira letra que o usuario digitar
                    }
                    catch (Exception excessao)
                    {

                        throw new ByteBanckException(excessao.Message);
                    }
                    switch (opcao)
                    {
                        case '1':
                            CadastrarConta();
                            break;
                        case '2':
                            ListarContas();
                            break;
                        case '3':
                            RemoverContas();
                            break;
                        case '4':
                            ordenarContas();
                            break;
                        case '5':
                            PesquisarContas();
                            break;
                        case '6':
                            EncerrarAplicacao();
                            break;
                        default:
                            Console.WriteLine("Opção Não implementada");
                            break;

                    }
                }
            }
            catch (ByteBanckException excecao)
            {

                Console.WriteLine($"{excecao.Message}");
            }
        }

        private void EncerrarAplicacao()
        {
            Console.WriteLine("Encerrando a Aplicação");
            Console.WriteLine("Aperte Qualquer tecla para encerrar a Aplicação");
            Console.ReadKey();
        }

        private void PesquisarContas()
        {
            Console.Clear();
            Console.WriteLine("===============================");
            Console.WriteLine("===    PESQUISAR CONTAS     ===");
            Console.WriteLine("===============================");
            Console.WriteLine("\n");
            Console.Write("Deseja pesquisar por (1)NUMERO DA CONTA ou (2)CPF TITULAR ou (3)Numero Agencia ? ");
            switch (int.Parse(Console.ReadLine()))
            {
                case 1:
                    {
                        Console.WriteLine("Informe o número da Conta: ");
                        string _numeroConta = Console.ReadLine();
                        ContaCorrente consultaConta = ConsultaPorNumeroConta(_numeroConta);
                        Console.WriteLine(consultaConta.ToString());
                        Console.ReadKey();
                        break;
                    }
                case 2:
                    {
                        Console.Write("Informe o CPF do Titular: ");
                        string _cpf = Console.ReadLine();
                        ContaCorrente consultaCpf = ConsultaPorCPFTitular(_cpf);
                        Console.WriteLine(consultaCpf.ToString());
                        Console.ReadKey();
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("Informe o Nº da Agencia");
                        int _numeroAgencia = int.Parse(Console.ReadLine());
                        List<ContaCorrente> contasPorAgencia = consultaPorAgencia(_numeroAgencia);
                        ExibirListaDeContas(contasPorAgencia);

                        Console.ReadKey();
                        break;
                    }
                default:
                    Console.WriteLine("Opção não implementada.");
                    break;
            }
        }

        private void ExibirListaDeContas(List<ContaCorrente> contasPorAgencia)
        {
            if (contasPorAgencia == null)
            {
                Console.WriteLine("... A consulta não retornou Dados ...");
            }
            else
            {
                foreach (ContaCorrente item in contasPorAgencia)
                {
                    Console.WriteLine(item.ToString());
                }
            }
        }

        private List<ContaCorrente> consultaPorAgencia(int numeroAgencia)
        {
            var consulta = (
                    from conta in _listaDeContas
                    where conta.Numero_agencia == numeroAgencia
                    select conta
                ).ToList();
            return consulta;
        }

        private ContaCorrente ConsultaPorCPFTitular(string cpf)
        {
            //Usando o Where, ele passa por cada objeto em uma lista e chama-o de conta e depois faz uma verificação, caso encontre ele retorna conforme determinado no FirstOrDefault
            return _listaDeContas.Where(conta => conta.Titular.Cpf == cpf).FirstOrDefault();
        }

        private ContaCorrente ConsultaPorNumeroConta(string numeroConta)
        {
            return _listaDeContas.Where(conta => conta.Conta == numeroConta).FirstOrDefault();
        }

        private void ordenarContas()
        {
            _listaDeContas.Sort();
            Console.WriteLine("... Lista de Contas Ordenadas ...");
            Console.ReadKey();
        }

        private void RemoverContas()
        {
            Console.Clear();
            Console.WriteLine("=================================");
            Console.WriteLine("====     Remover Contas      ====");
            Console.WriteLine("=================================");
            Console.WriteLine("\n");
            Console.WriteLine("Informe o Numero da conta: ");
            string numeroConta = Console.ReadLine();
            ContaCorrente conta = null;
            foreach (var item in _listaDeContas)
            {
                if (item.Conta.Equals(numeroConta))
                {
                    conta = item;
                }
            }
            if (conta != null)
            {
                _listaDeContas.Remove(conta);
                Console.WriteLine($"... A conta {conta.Conta} foi removida com sucesso ...");
            }
            else
            {
                Console.WriteLine("... conta para remoção não encontrada ...");
            }
            Console.ReadKey();
        }

        private void ListarContas()
        {
            Console.Clear();
            Console.WriteLine("=================================");
            Console.WriteLine("====    Lista de Contas      ====");
            Console.WriteLine("=================================");
            Console.WriteLine("\n");
            if (_listaDeContas.Count < 1)
            {
                Console.WriteLine("... Não há contas Cadastradas ...");
                Console.ReadKey();
                return;
            }
            foreach (ContaCorrente contas in _listaDeContas)
            {
                Console.WriteLine(contas.ToString());
                Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>");
            }
            Console.ReadKey();
        }

        private void CadastrarConta()
        {
            Console.Clear();
            Console.WriteLine("=================================");
            Console.WriteLine("====   Cadastro de Contas    ====");
            Console.WriteLine("=================================");
            Console.WriteLine("\n");
            Console.WriteLine("==== Informe dados da Conta  ====");
            Console.Write("Número da Agência: ");
            int numeroAgencia = int.Parse(Console.ReadLine());

            ContaCorrente conta = new ContaCorrente(numeroAgencia);
            Console.WriteLine($"O numero da conta gerada é: {conta.Conta}");

            Console.Write("Informe o Saldo inicial: ");
            conta.Saldo = double.Parse(Console.ReadLine());

            Console.Write("Infrome nome do Titular: ");
            conta.Titular.Nome = Console.ReadLine();

            Console.Write("Informe CPF do Titular: ");
            conta.Titular.Cpf = Console.ReadLine();

            Console.Write("Informe Profissão do Titular: ");
            conta.Titular.Profissao = Console.ReadLine();

            _listaDeContas.Add(conta);
            Console.WriteLine("... Conta Criada com sucesso! ...");
            Console.ReadKey();
        }

    }
}
