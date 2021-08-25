using Series.Classes;
using Series.Enums;
using System;

namespace Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while(opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("SELECIONE UMA OPÇÃO EXISTENTE NO MENU!");
                        opcaoUsuario = ObterOpcaoUsuario();
                        break;
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
            Serie serie = new Serie();
        }

        public static void ListarSeries()
        {
            Console.WriteLine("Listando séries");

            var lista = repositorio.Listar();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }
            else
            {
                foreach (var serie in lista)
                {
                    var excluido = serie.retornaExcluido();

                    var mostraExcluido = excluido ? "*EXCLUÍDA*" : "";
                    
                    Console.WriteLine($"#ID: {serie.retornaId()} - {serie.retornaTitulo()} {mostraExcluido}");
                    
                }
            }
        }

        public static void InserirSerie()
        {
            Console.WriteLine(Environment.NewLine + "Inserir série");

            var novaSerie = SolicitarDadosSerie(repositorio.ProximoId());

            try
            {
                repositorio.Inserir(novaSerie);
                Console.WriteLine(Environment.NewLine+"Série inserida com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Problemas ao inserir série. Erro: " + ex);
            }
        }

        public static void AtualizarSerie()
        {
            Console.WriteLine(Environment.NewLine + "Atualizar série");

            Console.WriteLine(Environment.NewLine+"Digite o ID da série:");
            int idSerie = int.Parse(Console.ReadLine());

            var atualizaSerie = SolicitarDadosSerie(idSerie);
            
            try
            {
                repositorio.Atualizar(idSerie, atualizaSerie);

                Console.WriteLine(Environment.NewLine + "Série Atualizada com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Problemas ao atualizar série. Erro: " + ex);
            }
        }

        public static void ExcluirSerie()
        {
            Console.WriteLine("Digite o ID da série que você deseja excluir:");
            int idSerie = int.Parse(Console.ReadLine());

            try
            {
                repositorio.Excluir(idSerie);
                Console.WriteLine("Série excluída com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Problemas ao excluir série. Erro: " + ex.Message);
                return;
            }
        }

        public static void VisualizarSerie()
        {
            Console.WriteLine("Visualizar série");

            Console.WriteLine("Digite o ID da série:");
            int idSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornarPorId(idSerie);

            Console.WriteLine(Environment.NewLine + serie);
        }
        public static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Séries a seu dispor!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1- Listar séries");
            Console.WriteLine("2- Inserir nova série");
            Console.WriteLine("3- Atualizar série");
            Console.WriteLine("4- Excluir série");
            Console.WriteLine("5- Visualizar série");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }

        public static Serie SolicitarDadosSerie(int idSerie)
        {
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine($"{i} : {Enum.GetName(typeof(Genero), i)}");
            }
            Console.WriteLine(Environment.NewLine + "Digite o gênero entre as opções acima: ");

            int entradaGenero = 0;
            int entradaAno = 0;

            while (entradaGenero == 0)
            {
                if (int.TryParse(Console.ReadLine(), out int genero))
                {
                    if (genero > 0 && genero <= Enum.GetNames(typeof(Genero)).Length)
                    {
                        entradaGenero = genero;
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Digite um número presente nas opções do menu!");
                    }
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Não digite letras ou símbolos! Use os números das opções presentes no menu.");
                }                
            }

            Console.WriteLine("Digite o titulo da série: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o ano de início da série: ");
            
            while (entradaAno == 0)
            {
                if(int.TryParse(Console.ReadLine(), out int ano))
                {
                    entradaAno = ano;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Digite um ano válido!");
                }
            }

            Console.WriteLine("Digite a descrição da série: ");
            string entradaDescricao = Console.ReadLine();

            Serie serie = new Serie
            (
                id: idSerie,
                genero: (Genero)entradaGenero,
                titulo: entradaTitulo,
                ano: entradaAno,
                descricao: entradaDescricao
            );

            return serie;
        }
    }
}
