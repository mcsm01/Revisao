using System;

namespace Revisao
{
    class Program
    {
        static void Main(string[] args)
        {
            Aluno[] alunos = new Aluno[5];
            var indiceAluno = 0;
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        Console.WriteLine("Informe o nom do aluno: ");
                        var aluno = new Aluno();
                        aluno.Nome = Console.ReadLine();

                        Console.WriteLine("Informe nota do aluno: ");

                        if (decimal.TryParse(Console.ReadLine(), out decimal nota))
                        {
                            aluno.Nota = nota;
                        }
                        else{
                            throw new ArgumentException("Valor da nota deve se decimal");
                        }

                        alunos[indiceAluno] = aluno;
                        indiceAluno++;
 
                        break;
                    case "2":
                        foreach(var a in alunos)
                        {
                            if (String.IsNullOrEmpty(a.Nome))
                            {
                                Console.WriteLine($"ALUNO: {a.Nome} - NOTA: {a.Nota}");
                            }
                            
                        }

                        break;
                    case "3":
                        decimal notaTotal = 0;
                        var nrAluno = 0;

                        for (int i=0; i < alunos.Length; i++)
                        {
                            if (!string.IsNullOrEmpty(alunos[i].Nome))
                            {
                                notaTotal = notaTotal + alunos[i].Nota;
                                nrAluno++;
                            }
                        }

                        var mediaGeral = notaTotal / nrAluno;
                        Conceito conceitoGeral;

                        if (mediaGeral< 2)
                        {
                            conceitoGeral = Conceito.E;
                        }
                        else if (mediaGeral< 4)
                        {
                            conceitoGeral = Conceito.D;
                        }
                        else if (mediaGeral< 6)
                        {
                            conceitoGeral = Conceito.C;
                        }
                        else if (mediaGeral< 8)
                        {
                            conceitoGeral = Conceito.B;
                        }
                        else
                        {
                            conceitoGeral = Conceito.A;
                        }

                        Console.WriteLine($"MÈDIA GERAL: {mediaGeral} - CONCEITO:{conceitoGeral}");

                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

            }

            opcaoUsuario = ObterOpcaoUsuario();


        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine("informe a opção desejada: ");
            Console.WriteLine("1- Inserir novo aluno");
            Console.WriteLine("2- Listar alunos");
            Console.WriteLine("3- Calcular média geral");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
