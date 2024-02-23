using SistemaReservaHotel;
using System;
using System.Collections.Generic;

namespace SistemaReservaHotel
{
    internal class Program
    {
        static List<Pessoa> pessoas = new List<Pessoa>();
        static List<Suite> suites = new List<Suite>();
        static List<Reserva> reservas = new List<Reserva>();

        static void Main(string[] args)
        {
            bool sair = false;
            do
            {
                Console.WriteLine("== HOTEL JEFF´S ==");
                Console.WriteLine("=== MENU ===");
                Console.WriteLine("1. Cadastrar");
                Console.WriteLine("2. Consultar");
                Console.WriteLine("3. Listar");
                Console.WriteLine("4. Sair");
                Console.Write("Escolha uma opção: ");
                string opcao = Console.ReadLine();
                Console.WriteLine();

                switch (opcao)
                {
                    case "1":
                        MenuCadastro();
                        break;
                    case "2":
                        MenuConsultar();
                        break;
                    case "3":
                        MenuListar();
                        break;
                    case "4":
                        sair = true;
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }

            } while (!sair);
        }

        static void MenuCadastro()
        {
            Console.WriteLine("=== CADASTRO ===");
            Console.WriteLine("1. Hospede");
            Console.WriteLine("2. Suite");
            Console.WriteLine("3. Reserva");
            Console.Write("Escolha uma opção: ");
            string opcao = Console.ReadLine();
            Console.WriteLine();

            switch (opcao)
            {
                case "1":
                    CadastrarHospede();
                    break;
                case "2":
                    CadastrarSuite();
                    break;
                case "3":
                    RealizarReserva();
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }

        static void MenuConsultar()
        {
            Console.WriteLine("=== CONSULTAR ===");
            Console.WriteLine("1. Hospede");
            Console.WriteLine("2. Suite");
            Console.WriteLine("3. Reserva");
            Console.Write("Escolha uma opção: ");
            string opcao = Console.ReadLine();
            Console.WriteLine();

            switch (opcao)
            {
                case "1":
                    ConsultarHospede();
                    break;
                case "2":
                    ConsultarSuite();
                    break;
                case "3":
                    ConsultarReserva();
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }

        static void MenuListar()
        {
            Console.WriteLine("=== LISTAR ===");
            Console.WriteLine("1. Hospedes");
            Console.WriteLine("2. Suites");
            Console.WriteLine("3. Reservas");
            Console.Write("Escolha uma opção: ");
            string opcao = Console.ReadLine();
            Console.WriteLine();

            switch (opcao)
            {
                case "1":
                    ListarHospedes();
                    break;
                case "2":
                    ListarSuites();
                    break;
                case "3":
                    ListarReservas();
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }

        static void CadastrarHospede()
        {
            Console.WriteLine("=== CADASTRO DE HOSPEDE ===");
            Console.Write("Nome: ");
            string nome = Console.ReadLine();
            Console.Write("Idade: ");
            int idade = int.Parse(Console.ReadLine());
            Console.Write("Gênero: ");
            string genero = Console.ReadLine();
            Console.Write("Profissão: ");
            string profissao = Console.ReadLine();

            Pessoa pessoa = new Pessoa(nome, idade, genero, profissao);
            pessoas.Add(pessoa);
            Console.WriteLine("Hospede cadastrado com sucesso!\n");
        }

        static void CadastrarSuite()
        {
            Console.WriteLine("=== CADASTRO DE SUITE ===");
            Console.Write("Capacidade: ");
            int capacidade = int.Parse(Console.ReadLine());
            Console.Write("Valor da Diária: ");
            double valorDiaria = double.Parse(Console.ReadLine());

            Suite suite = new Suite(capacidade, valorDiaria);
            suites.Add(suite);
            Console.WriteLine("Suite cadastrada com sucesso!\n");
        }

        static void RealizarReserva()
        {
            Console.WriteLine("=== REALIZAR RESERVA ===");
            Console.WriteLine("Hospedes disponíveis:");
            for (int i = 0; i < pessoas.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {pessoas[i].Nome}");
            }
            Console.Write("Escolha o número correspondente ao hospede: ");
            int indexPessoa = int.Parse(Console.ReadLine()) - 1;

            Console.WriteLine("\nSuites disponíveis:");
            for (int i = 0; i < suites.Count; i++)
            {
                Console.WriteLine($"{i + 1}. Capacidade: {suites[i].Capacidade}, Valor Diária: {suites[i].ValorDiaria:C}");
            }
            Console.Write("Escolha o número correspondente à suite: ");
            int indexSuite = int.Parse(Console.ReadLine()) - 1;

            Console.Write("Data Inicio da Reserva (dd/mm/yyyy): ");
            DateTime dataInicio = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
            Console.Write("Data Fim da Reserva (dd/mm/yyyy): ");
            DateTime dataFim = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

            Reserva reserva = new Reserva(pessoas[indexPessoa], suites[indexSuite], dataInicio, dataFim);
            reservas.Add(reserva);
            Console.WriteLine("Reserva realizada com sucesso!\n");
        }

        static void ConsultarHospede()
        {
            Console.WriteLine("=== CONSULTA DE HOSPEDE ===");
            Console.Write("Digite o nome do hospede: ");
            string nome = Console.ReadLine();
            Pessoa pessoa = pessoas.Find(p => p.Nome == nome);
            if (pessoa != null)
            {
                Console.WriteLine($"Nome: {pessoa.Nome}, Idade: {pessoa.Idade}, Gênero: {pessoa.Genero}, Profissão: {pessoa.Profissao}\n");
            }
            else
            {
                Console.WriteLine("Hospede não encontrado.\n");
            }
        }

        static void ConsultarSuite()
        {
            Console.WriteLine("=== CONSULTA DE SUITE ===");
            Console.Write("Digite a capacidade da suite: ");
            int capacidade = int.Parse(Console.ReadLine());
            Suite suite = suites.Find(s => s.Capacidade == capacidade);
            if (suite != null)
            {
                Console.WriteLine($"Capacidade: {suite.Capacidade}, Valor Diária: {suite.ValorDiaria:C}\n");
            }
            else
            {
                Console.WriteLine("Suite não encontrada.\n");
            }
        }

        static void ConsultarReserva()
        {
            Console.WriteLine("=== CONSULTA DE RESERVA ===");
            Console.Write("Digite o nome do hospede: ");
            string nome = Console.ReadLine();
            Reserva reserva = reservas.Find(r => r.Hospede.Nome == nome);
            if (reserva != null)
            {
                Console.WriteLine($"Hospede: {reserva.Hospede.Nome}, Suite: Capacidade: {reserva.Suite.Capacidade}, Valor Diária: {reserva.Suite.ValorDiaria:C}, Data Inicio: {reserva.DataInicio.ToShortDateString()}, Data Fim: {reserva.DataFim.ToShortDateString()}, Valor Total: {reserva.CalcularValorTotal():C}\n");
            }
            else
            {
                Console.WriteLine("Reserva não encontrada.\n");
            }
        }

        static void ListarHospedes()
        {
            Console.WriteLine("=== LISTA DE HOSPEDES ===");
            foreach (var pessoa in pessoas)
            {
                Console.WriteLine($"Nome: {pessoa.Nome}, Idade: {pessoa.Idade}, Gênero: {pessoa.Genero}, Profissão: {pessoa.Profissao}");
            }
            Console.WriteLine();
        }

        static void ListarSuites()
        {
            Console.WriteLine("=== LISTA DE SUITES ===");
            foreach (var suite in suites)
            {
                Console.WriteLine($"Capacidade: {suite.Capacidade}, Valor Diária: {suite.ValorDiaria:C}");
            }
            Console.WriteLine();
        }

        static void ListarReservas()
        {
            Console.WriteLine("=== LISTA DE RESERVAS ===");
            foreach (var reserva in reservas)
            {
                Console.WriteLine($"Hospede: {reserva.Hospede.Nome}, Suite: Capacidade: {reserva.Suite.Capacidade}, Valor Diária: {reserva.Suite.ValorDiaria:C}, Data Inicio: {reserva.DataInicio.ToShortDateString()}, Data Fim: {reserva.DataFim.ToShortDateString()}, Valor Total: {reserva.CalcularValorTotal():C}");
            }
            Console.WriteLine();
        }
    }
}

