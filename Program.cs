using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;


namespace NinjaDeveloperTestFelipeGraf
{
    class Program
    {
        //------- PROPRIEDADES DA CLASSE ----------//
        private static string menuPrincipal { get; set; }
        private static string subMenu { get; set; }
        private static int opcaoFinal { get; set; }
        //------------------------------------------//


        static void Main(string[] args)
        {
            exibirMenu();
        }


        //------------- MENU PRINCIPAL---------------//
        public static void exibirMenu()
        {
            bool validarEntrada = false;
            do
            {
                Console.Clear();
                consoleCabecalho();
                Console.WriteLine("|         M E N U  P R I N C I P A L         |");
                Console.WriteLine("----------------------------------------------");
                Console.WriteLine("| 1- Cadastro de Aluno                       |");
                Console.WriteLine("| 2- Cadastro de Matéria                     |");
                Console.WriteLine("| 3- Cadastro de Nota                        |");
                Console.WriteLine("| 4- Visualização de Notas do Aluno          |");
                Console.WriteLine("----------------------------------------------");
                Console.Write("Digite a opção desejada: ");
                menuPrincipal = Console.ReadLine();
                if (ValidarStrNumero(menuPrincipal) == true && String.IsNullOrEmpty(menuPrincipal) != true || menuPrincipal == "1" || menuPrincipal == "2" || menuPrincipal == "3" || menuPrincipal == "4")
                {
                    validarEntrada = true;
                    switch (menuPrincipal)
                    {
                        case "1":
                            exibirCadastroAluno();
                            break;

                        case "2":
                            exibirCadastroMateria();
                            break;

                        case "3":
                            exibirCadastroNota();
                            break;

                        case "4":
                            exibirVisualizarNota();
                            break;
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Opção inválida! Tente novamente.");
                    Console.WriteLine("Aperte qualquer tecla para voltar.");
                    Console.ReadLine();
                    validarEntrada = false;
                }
            } while (validarEntrada == false);

        }
        //------------------------------------------//


        //-------- OPÇÕES MENU PRINCIPAL ----------//
        //Opções do Menu Principal para o Switch
        public static void exibirCadastroAluno()
        {
            String nome, sobrenome, dtNascimento, cpf, curso;
            bool ok;
            Console.Clear();
            consoleCabecalho();
            Console.WriteLine("|       C A D A S T R O  DE  A L U N O       |");
            Console.WriteLine("----------------------------------------------");
            //NOME
            do
            {
                Console.Write("Nome: ");
                nome = Console.ReadLine();

                if (ValidarNome(nome.ToLower()))
                {
                    ok = true;
                }
                else
                {
                    Console.WriteLine("Verifique o nome e tente novamente.");
                    ok = false;
                }
            } while (ok == false);
            //
            //SOBRENOME
            do
            {
                Console.Write("Sobrenome: ");
                sobrenome = Console.ReadLine();

                if (String.IsNullOrEmpty(sobrenome.ToLower()))
                {
                    Console.WriteLine("Verifique seu sobrenome e tente novamente.");
                    ok = false;
                }
                else
                {
                    ok = true;
                }
            } while (ok == false);
            //
            //DATA DE NASCIMENTO          
            do
            {
                Console.Write("Data de Nascimento [DD/MM/YYYY]: ");
                dtNascimento = Console.ReadLine();

                if (ValidarData(dtNascimento))
                {
                    ok = true;
                }
                else
                {
                    Console.WriteLine("Digite uma data valida.");
                    ok = false;
                }
            } while (ok == false);
            //
            //CPF
            do
            {
                Console.Write("CPF: ");
                cpf = Console.ReadLine();
                if (ValidarCpf(cpf))
                {
                    ok = true;
                }
                else
                {
                    Console.WriteLine("Digite apenas números e tente novamente.");
                    ok = false;
                }
            } while (ok == false);
            //
            //CURSO
            do
            {
                Console.Write("Curso: ");
                curso = Console.ReadLine();
                if (String.IsNullOrEmpty(curso))
                {
                    Console.WriteLine("Verifique seu curso e tente novamente.");
                    ok = false;
                }
                else
                {
                    ok = true;
                }
            } while (ok == false);
            //

            consoleSwitchSubMenu();
            subMenu = Console.ReadLine();
            bool verificarSubMenu = true;
            do
            {
                if (subMenu == "1" || subMenu == "2" || subMenu == "3")
                {
                    switchSubMenuCadastroAluno(nome.ToLower(), sobrenome.ToLower(), dtNascimento, cpf, curso);
                }
                else
                {
                    verificarSubMenu = false;
                    consoleSwitchSubMenu();
                    subMenu = Console.ReadLine();
                }
            } while (verificarSubMenu == false);


        }
        public static void exibirCadastroMateria()
        {
            String descricao, situacao, dtCadastro;
            bool ok;
            Console.Clear();
            consoleCabecalho();
            Console.WriteLine("|     C A D A S T R O  DE  M A T É R I A     |");
            Console.WriteLine("----------------------------------------------");
            //DESCRIÇÃO
            do
            {
                Console.Write("Descrição/Matéria: ");
                descricao = Console.ReadLine();

                if (ValidarNome(descricao.ToLower()))
                {
                    ok = true;
                }
                else
                {
                    Console.WriteLine("Verifique e tente novamente.");
                    ok = false;
                }
            } while (ok == false);
            //
            //DATA DE CADASTRO
            do
            {
                Console.Write("Data de Cadastro [DD/MM/YYYY]: ");
                dtCadastro = Console.ReadLine();

                if (ValidarDataDeCadastro(dtCadastro))
                {
                    ok = true;
                }
                else
                {
                    Console.WriteLine("Digite uma data valida.");
                    ok = false;
                }
            } while (ok == false);
            //
            //SITUACAO
            do
            {
                Console.Write("Situação: ");
                situacao = Console.ReadLine();
                if (situacao.ToLower() == "ativo" || situacao.ToLower() == "inativo")
                {
                    ok = true;
                }
                else
                {
                    Console.WriteLine("Informe apenas se está 'Ativo' ou 'Inativo'");
                    ok = false;
                }
            } while (ok == false);
            //
            bool verificarSubMenu = true;
            consoleSwitchSubMenu();
            subMenu = Console.ReadLine();
            do
            {
                if (subMenu == "1" || subMenu == "2" || subMenu == "3")
                {
                    switchSubMenuCadastroMateria(descricao.ToLower(), dtCadastro, situacao.ToLower());
                }
                else
                {
                    verificarSubMenu = false;
                    consoleSwitchSubMenu();
                    subMenu = Console.ReadLine();
                }
            } while (verificarSubMenu == false);
        }
        public static void exibirCadastroNota()
        {
            String aluno = " ", line;
            bool ok = true;
            Console.Clear();
            consoleCabecalho();
            Console.WriteLine("|        C A D A S T R O  DE  N O T A        |");
            Console.WriteLine("----------------------------------------------");
            bool alunoExiste = false;
            //ALUNO
            while (alunoExiste == false)
            {
                Console.Write("Aluno (Nome e Sobrenome): ");
                aluno = Console.ReadLine();
                if (File.Exists("DadosAluno.txt"))
                {
                    System.IO.StreamReader file = new System.IO.StreamReader("DadosAluno.txt");
                    while ((line = file.ReadLine()) != null)
                    {
                        if (line.Contains(aluno.ToLower()) && aluno.Length >= 5)
                        {
                            alunoExiste = true;
                            break;
                        }
                    }
                    file.Close();
                    if (!alunoExiste)
                    {
                        alunoExiste = false;
                        break;
                    }
                    else
                    {
                        alunoExiste = true;
                        break;
                    }
                }
                else
                {
                    alunoExiste = false;
                    break;
                }
            }
            //
            string materia = "";
            bool materiaExiste = false;
            //MATÉRIA
            if (alunoExiste == false)
            { }
            else
            {
                while (materiaExiste == false)
                {
                    Console.Write("Matéria: ");
                    materia = Console.ReadLine();
                    if (File.Exists("DadosMateria.txt"))
                    {
                        System.IO.StreamReader file = new System.IO.StreamReader("DadosMateria.txt");
                        while ((line = file.ReadLine()) != null)
                        {
                            if (line.Contains(materia.ToLower()))
                            {
                                materiaExiste = true;
                                break;
                            }
                        }
                        file.Close();
                        if (!materiaExiste)
                        {
                            materiaExiste = false;
                            break;
                        }
                        else
                        {
                            materiaExiste = true;
                            break;
                        }
                    }
                    else
                    {
                        materiaExiste = false;
                        break;
                    }
                }
            }

            //

            //NOTA
            int nota = 0;
            if (materiaExiste == false || alunoExiste == false)
            {
                Console.WriteLine("Verifique os dados e tente novamente.");
            }

            else
            {
                do
                {
                    Console.Write("Nota: ");
                    nota = int.Parse(Console.ReadLine());
                    if (nota >= 0 && nota <= 100)
                    {
                        ok = true;
                    }
                    else
                    {
                        Console.WriteLine("Informe uma Nota de 0 a 100, apenas.");
                        ok = false;
                    }

                } while (ok == false);
            }
            //
            bool verificarSubMenu = true;
            consoleSwitchSubMenu();
            subMenu = Console.ReadLine();
            do
            {
                if (subMenu == "1" || subMenu == "2" || subMenu == "3")
                {
                    switchSubMenuCadastroNota(aluno, materia, nota);
                }
                else
                {
                    verificarSubMenu = false;
                    consoleSwitchSubMenu();
                    subMenu = Console.ReadLine();
                }
            } while (verificarSubMenu == false);
        }
        public static void exibirVisualizarNota()
        {
            string aluno;
            Console.Clear();
            consoleCabecalho();
            Console.WriteLine("|        V I S U A L I Z A R   N O T A       |");
            Console.WriteLine("----------------------------------------------");

            bool alunoExiste = false;
            string line;
            do
            {
                Console.WriteLine();
                Console.Write("Aluno (Nome e Sobrenome): ");
                aluno = Console.ReadLine();
                Console.WriteLine();
                if (File.Exists("DadosAluno.txt"))
                {

                    System.IO.StreamReader file = new System.IO.StreamReader("DadosAluno.txt");
                    while ((line = file.ReadLine()) != null)
                    {
                        if (line.Contains(aluno.ToLower()) && aluno.ToLower().Length >= 5)
                        {
                            alunoExiste = true;
                            break;
                        }
                    }

                }
                if (alunoExiste == false)
                {
                    Console.WriteLine("Aluno não cadastrado!");
                    break;
                }

            } while (alunoExiste == false);
            bool verificarSubMenu = true;
            do
            {
                consoleSwitchVisualizarNotas();
                subMenu = Console.ReadLine();
                if (subMenu == "1" || subMenu == "2")
                {
                    switchSubMenuVisualizarNota(aluno);
                    break;
                }
                else
                {
                    verificarSubMenu = false;
                }
            } while (verificarSubMenu == false);
        }
        //------------------------------------------//


        //---------------- SWITCHS ------------------//
        //Switch das Opções do Menu Principal 
        public static void switchSubMenuCadastroAluno(String nome, String sobrenome, String dtNascimento, String cpf, String curso)
        {
            bool verificar = true;
            do
            {

                if (String.IsNullOrEmpty(subMenu) || subMenu == "1" || subMenu == "2" || subMenu == "3")
                {
                    switch (subMenu)
                    {
                        case "1":
                            Console.Clear();
                            exibirMenu();
                            break;
                        case "2":
                            Console.Clear();
                            consoleCabecalho();
                            Console.WriteLine("|       C A D A S T R O  DE  A L U N O       |");
                            Console.WriteLine("----------------------------------------------");
                            string line;
                            bool alunoExiste = false;
                            if (File.Exists("DadosAluno.txt"))
                            {

                                System.IO.StreamReader file = new System.IO.StreamReader("DadosAluno.txt");
                                while ((line = file.ReadLine()) != null)
                                {
                                    if (line.Contains(nome.ToLower()) && line.Contains(sobrenome.ToLower()) || line.Contains(cpf))
                                    {
                                        alunoExiste = true;
                                        break;
                                    }
                                }
                                file.Close();
                                if (!alunoExiste)
                                {
                                    Console.Clear();
                                    gravarDadosDoAluno(nome, sobrenome, dtNascimento, cpf, curso);
                                    consoleCabecalho();
                                    consoleCadastroRealizado();
                                }
                                else
                                {
                                    Console.Clear();
                                    consoleCabecalho();
                                    Console.WriteLine("|              Aluno já Existe               |");
                                    Console.WriteLine("----------------------------------------------");
                                }
                            }
                            else
                            {
                                Console.Clear();
                                gravarDadosDoAluno(nome, sobrenome, dtNascimento, cpf, curso);
                                consoleCabecalho();
                                consoleCadastroRealizado();
                            }
                            consoleSwitchFinal();
                            opcaoFinal = int.Parse(Console.ReadLine());
                            switchFinal();
                            break;

                        case "3":
                            Console.Clear();
                            consoleCabecalho();
                            alunoExiste = false;
                            if (File.Exists("DadosAluno.txt"))
                            {

                                System.IO.StreamReader file = new System.IO.StreamReader("DadosAluno.txt");
                                while ((line = file.ReadLine()) != null)
                                {
                                    if (line.Contains(nome.ToLower()) && line.Contains(sobrenome.ToLower()) || line.Contains(cpf))
                                    {
                                        alunoExiste = true;
                                        break;
                                    }
                                }
                                file.Close();
                                if (!alunoExiste)
                                {
                                    alunoExiste = false;
                                }
                                else
                                {
                                    alunoExiste = true;
                                }
                            }
                            else
                            {
                                alunoExiste = false;
                            }

                            if (File.Exists("DadosAluno.txt") && alunoExiste == true)
                            {
                                var fileContent = File.ReadAllLines("DadosAluno.txt").ToList();
                                int index = 0;
                                foreach (var linha in fileContent)
                                {
                                    if (linha.Contains(nome))
                                    {
                                        break;
                                    }

                                    index++;
                                }
                                if (index <= fileContent.Count)
                                {
                                    fileContent.RemoveAt(index);
                                    File.WriteAllText("DadosAluno.txt", string.Join("\n" + "\n", fileContent));
                                    consoleRegistroExcluido();
                                }
                            }
                            else
                            {
                                Console.WriteLine("|       Não foram encontrado registros       |");
                            }
                            consoleSwitchFinal();
                            opcaoFinal = int.Parse(Console.ReadLine());
                            switchFinal();
                            break;
                    }
                }
                else
                {
                    verificar = false;
                    Console.Write("Digite um valor válido: ");
                    subMenu = Console.ReadLine();
                }
            } while (verificar == false);
        }
        public static void switchSubMenuCadastroMateria(String descricao, String dtCadastro, String situacao)
        {
            bool verificar = true;
            do
            {
                if (String.IsNullOrEmpty(subMenu) || subMenu == "1" || subMenu == "2" || subMenu == "3")
                {
                    switch (subMenu)
                    {
                        case "1":
                            Console.Clear();
                            exibirMenu();
                            break;

                        case "2":
                            Console.Clear();
                            consoleCabecalho();
                            Console.WriteLine("|     C A D A S T R O  DE  M A T E R I A     |");
                            Console.WriteLine("----------------------------------------------");
                            string line;
                            bool materiaExiste = false;
                            if (File.Exists("DadosMateria.txt"))
                            {
                                System.IO.StreamReader file = new System.IO.StreamReader("DadosMateria.txt");
                                while ((line = file.ReadLine()) != null)
                                {
                                    if (line.Contains(descricao.ToLower()))
                                    {
                                        materiaExiste = true;
                                        break;
                                    }
                                }
                                file.Close();
                                if (materiaExiste == false)
                                {
                                    Console.Clear();
                                    gravarDadosDaMateria(descricao, dtCadastro, situacao);
                                    consoleCabecalho();
                                    consoleCadastroRealizado();
                                }
                                else
                                {
                                    Console.Clear();
                                    consoleCabecalho();
                                    Console.WriteLine("|             Matéria já Existe              |");
                                    Console.WriteLine("----------------------------------------------");
                                }
                            }
                            else
                            {
                                Console.Clear();
                                gravarDadosDaMateria(descricao, dtCadastro, situacao);
                                consoleCabecalho();
                                consoleCadastroRealizado();
                            }
                            consoleSwitchFinal();
                            opcaoFinal = int.Parse(Console.ReadLine());
                            switchFinal();
                            break;

                        case "3":
                            Console.Clear();
                            consoleCabecalho();
                            materiaExiste = false;
                            if (File.Exists("DadosMateria.txt"))
                            {

                                System.IO.StreamReader file = new System.IO.StreamReader("DadosMateria.txt");
                                while ((line = file.ReadLine()) != null)
                                {
                                    if (line.Contains(descricao.ToLower()))
                                    {
                                        materiaExiste = true;
                                        break;
                                    }
                                }
                                file.Close();
                                if (materiaExiste == false)
                                {
                                    materiaExiste = false;
                                }
                                else
                                {
                                    materiaExiste = true;
                                }
                            }
                            else
                            {
                                materiaExiste = false;
                            }
                            if (File.Exists("DadosMateria.txt") && materiaExiste == true)
                            {
                                var fileContent = File.ReadAllLines("DadosMateria.txt").ToList();
                                int index = 0;
                                foreach (var linha in fileContent)
                                {
                                    if (linha.Contains(descricao.ToLower()))
                                    {
                                        break;
                                    }

                                    index++;
                                }
                                if (index <= fileContent.Count)
                                {
                                    fileContent.RemoveAt(index);
                                    File.WriteAllText("DadosMateria.txt", string.Join("\n" + "\n", fileContent));
                                    consoleRegistroExcluido();
                                }
                            }
                            else
                            {
                                Console.WriteLine("|       Não foram encontrado registros       |");
                                consoleSwitchFinal();
                                opcaoFinal = int.Parse(Console.ReadLine());
                                switchFinal();


                            }
                            break;
                    }
                }
                else
                {
                    verificar = false;
                    Console.Write("Digite um valor válido: ");
                    subMenu = Console.ReadLine();
                }
            } while (verificar == false);
        }
        public static void switchSubMenuCadastroNota(String aluno, String materia, int nota)
        {
            bool verificar = true;
            do
            {
                if (String.IsNullOrEmpty(subMenu) || subMenu == "1" || subMenu == "2" || subMenu == "3")
                {

                    switch (subMenu)
                    {
                        case "1":
                            Console.Clear();
                            exibirMenu();
                            break;

                        case "2":
                            Console.Clear();
                            receberNota(aluno.ToLower(), materia.ToLower(), nota);
                            consoleCabecalho();
                            consoleCadastroRealizado();
                            consoleSwitchFinal();
                            opcaoFinal = int.Parse(Console.ReadLine());
                            switchFinal();
                            break;
                        case "3":
                            Console.Clear();
                            consoleCabecalho();
                            consoleRegistroExcluido();
                            if (File.Exists("nota-" + materia.ToLower() + "-" + aluno.ToLower() + ".txt"))
                            {
                                File.Delete("nota-" + materia.ToLower() + "-" + aluno.ToLower() + ".txt");
                            }
                            else
                            {
                                Console.WriteLine("Nota de Aluno para essa matéria não encontrada");
                            }
                            consoleSwitchFinal();
                            opcaoFinal = int.Parse(Console.ReadLine());
                            switchFinal();
                            break;
                    }
                }
                else
                {
                    verificar = false;
                    Console.Write("Digite um valor válido: ");
                    subMenu = Console.ReadLine();
                }
            } while (verificar == false);
        }
        public static void switchSubMenuVisualizarNota(String aluno)
        {
            bool verificar = true;
            do
            {
                if (String.IsNullOrEmpty(subMenu) || subMenu == "1" || subMenu == "2")
                {
                    switch (subMenu)
                    {
                        case "1":
                            Console.Clear();
                            exibirMenu();
                            break;

                        case "2":
                            string path = Directory.GetCurrentDirectory();
                            string[] arquivos = Directory.GetFiles(path, "*.txt", SearchOption.AllDirectories);
                            Console.Clear();
                            consoleCabecalho();
                            Console.WriteLine("|        V I S U A L I Z A R   N O T A       |");
                            Console.WriteLine("----------------------------------------------");
                            Console.WriteLine();
                            Console.WriteLine("Aluno: " + aluno);
                            Console.WriteLine();

                            foreach (string arq in arquivos)
                            {
                                if (arq.Contains(aluno.ToLower()))
                                {


                                    String imprimirNotas = File.ReadAllText(arq);
                                    Console.WriteLine(imprimirNotas);
                                }
                            }
                            consoleSwitchFinal();
                            opcaoFinal = int.Parse(Console.ReadLine());
                            switchFinal();
                            break;
                    }
                }
                else
                {
                    verificar = false;
                    Console.Write("Digite um valor válido: ");
                    subMenu = Console.ReadLine();
                }
            } while (verificar == false);
        }
        public static void switchFinal()
        {
            switch (opcaoFinal)
            {
                case 1:
                    exibirMenu();
                    break;

                case 2:
                    Console.Clear();
                    consoleCabecalho();
                    Console.WriteLine("|             SESSÃO ENCERRADA               |");
                    Console.WriteLine("----------------------------------------------");
                    break;
            }
        }
        //------------------------------------------//


        //--------------- VALIDAÇÕES ---------------//
        //Validar se String possui apenas letras.
        public static bool ValidarNome(string nome)
        {
            return Regex.IsMatch(nome, @"^[a-zA-Z]+$");
        }

        //Validar CPF
        public static bool ValidarCpf(string cpf)
        {
            return cpf.Length == 11 && Regex.IsMatch(cpf, @"^[0-9]+$");
        }

        //Validar Apenas Numero
        public static bool ValidarStrNumero(string num)
        {
            return Regex.IsMatch(num, @"^[0-9]+$");
        }

        //Validar Data
        public static bool ValidarData(string data)
        {
            return DateTime.TryParse(data, out DateTime dt) && dt <= DateTime.Parse("01/01/2002");
        }

        //Validar Data de Cadastro
        public static bool ValidarDataDeCadastro(string data)
        {
            return DateTime.TryParse(data, out DateTime dt) && dt <= DateTime.Today.Date;
        }
        //------------------------------------------//


        //----------- GRAVAÇÕES DE DADOS -----------//
        //Gravar Dados do Aluno
        public static void gravarDadosDoAluno(String nome, String sobrenome, String dtNascimento, String cpf, String curso)
        {
            Stream dadosDoAluno = File.Open("DadosAluno.txt", FileMode.Append);
            StreamWriter escritor = new StreamWriter(dadosDoAluno);


            escritor.Write(nome.ToLower() + " ");
            escritor.Write(sobrenome.ToLower() + " ");
            escritor.Write(dtNascimento.ToLower() + " ");
            escritor.Write(cpf.ToLower() + " ");
            escritor.Write(curso.ToLower() + " ");
            escritor.WriteLine(" ");

            escritor.Close();
            dadosDoAluno.Close();
        }

        //Gravar Dados da Matéria
        public static void gravarDadosDaMateria(String descricao, String dtCadastro, String situacao)
        {
            Stream dadosDaMateria = File.Open("DadosMateria.txt", FileMode.Append);
            StreamWriter escritor = new StreamWriter(dadosDaMateria);
            escritor.Write(descricao.ToLower() + " ");
            escritor.Write(dtCadastro.ToLower() + " ");
            escritor.Write(situacao.ToLower() + " ");
            escritor.WriteLine(" ");
            escritor.Close();
            dadosDaMateria.Close();
        }

        //Gravar Receber Notas
        public static void receberNota(String nome, String materia, int nota)
        {
            Stream dadosNotaAluno = File.Open("nota-" + materia.ToLower() + "-" + nome.ToLower() + ".txt", FileMode.Create);
            StreamWriter escritor = new StreamWriter(dadosNotaAluno);
            escritor.WriteLine("----------------------------------------------");
            escritor.WriteLine("Matéria: " + materia.ToLower());
            escritor.WriteLine("Nota: " + nota);
            escritor.WriteLine("----------------------------------------------");
            escritor.Close();
            dadosNotaAluno.Close();
        }
        //------------------------------------------//


        //--------------- CONSOLES -----------------//
        //Console Switch Final
        public static void consoleSwitchFinal()
        {
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("|        1- Menu Principal | 2- Sair         |");
            Console.WriteLine("----------------------------------------------");
            Console.Write("Digite a opção desejada: ");
        }

        //Console Switch Sub Menu
        public static void consoleSwitchSubMenu()
        {
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("| 1- Menu Principal | 2- Salvar | 3- Excluir |");
            Console.WriteLine("----------------------------------------------");
            Console.Write("Digite a opção desejada: ");
        }

        //Console Switch Sub Menu Visualizar Notas
        public static void consoleSwitchVisualizarNotas()
        {
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("|         1- Voltar | 2- Visualizar          |");
            Console.WriteLine("----------------------------------------------");
            Console.Write("Digite a opção desejada: ");
        }

        //Conosole Cabeçalho
        public static void consoleCabecalho()
        {
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("| Universidade Tecnológica do Sítio do Caqui |");
            Console.WriteLine("----------------------------------------------");
        }

        //Console Cadastro Realizado
        public static void consoleCadastroRealizado()
        {
            Console.WriteLine("|             Registro Realizado             |");
            Console.WriteLine("----------------------------------------------");
        }

        //Console Registro Excluido
        public static void consoleRegistroExcluido()
        {
            Console.WriteLine("|             Registro Excluido              |");
            Console.WriteLine("----------------------------------------------");
        }
        //------------------------------------------//
    }
}
