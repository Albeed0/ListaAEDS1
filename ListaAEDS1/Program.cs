using System;

using System;

namespace ListaAEDS1
{
    class Program
    {
         static void Main(string[] args)
        {
            int opcao = -1;
            while (opcao != 0)
            {
                Console.WriteLine("\nEscolha a questão (1, 2, 3, 5, 6, 11) ou 0 para sair: ");
                if (!int.TryParse(Console.ReadLine(), out opcao))
                {
                    opcao = -1;
                }
 
                switch (opcao)
                {
                    case 1: Questao1(); break;
                    case 2: Questao2(); break;
                    case 3: Questao3(); break;
                    case 5: Questao5(); break;
                    case 6: Questao6(); break;
                    case 11: Questao11(); break;
                }
            }
        }
 
        static void Questao1()
        {
            int n, num, soma = 0, maior, menor, indiceMaior, indiceMenor, abaixoMedia = 0;
            double media;
            Console.WriteLine("Digite a quantidade de numeros inteiros: ");
            n = int.Parse(Console.ReadLine());
            int[] vet = new int[n];
 
            for (int i = 0; i < vet.Length; i++)
            {
                Console.WriteLine("Digite o numero: ");
                num = int.Parse(Console.ReadLine());
                vet[i] = num;
                soma += vet[i];
            }
 
            media = (double)soma / vet.Length;
 
            for (int i = 0; i < vet.Length; i++)
            {
                if (vet[i] < media)
                {
                    ++abaixoMedia;
                }
            }
 
            maior = vet.Max();
            menor = vet.Min();
 
            indiceMaior = Array.IndexOf(vet, maior);
            indiceMenor = Array.IndexOf(vet, menor);
 
            Console.WriteLine($"Soma: {soma}\nMedia: {media:f2}\nAbaixo da Media: {abaixoMedia}\nIndice do Maior: {indiceMaior}\nIndice do Menor: {indiceMenor}");
        }
 
        static void Questao2()
        {
            double soma = 0, media;
            int cont = 0;
            double[,] mat = new double[6, 6];
            Random rand = new Random();
 
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                for (int j = 0; j < mat.GetLength(1); j++)
                {
                    mat[i, j] = rand.Next(1, 100);
                    Console.Write(mat[i, j] + "\t");
                }
                Console.WriteLine();
            }
 
            // acima da diagonal secundária, incluindo ela: i + j <= 5
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                for (int j = 0; j < mat.GetLength(1); j++)
                {
                    if (i + j <= 5)
                    {
                        soma += mat[i, j];
                        cont++;
                    }
                }
            }
 
            media = soma / cont;
 
            Console.WriteLine($"Elementos considerados: {cont}\nSoma: {soma}\nMedia: {media:f2}");
        }
 
        static void Questao3()
        {
            int idade, sexo, estadoCivil, radio;
            int total = 0, somaIdades = 0, homens = 0, mulheres = 0;
            int mulheresCasadasBH = 0, homensMaior21JP = 0;
            int[] radios = new int[6]; // posições 1 a 5 = rádios; posição 0 = Outros
 
            Console.WriteLine("Idade (0 para encerrar): ");
            idade = int.Parse(Console.ReadLine());
 
            while (idade != 0)
            {
                Console.WriteLine("Sexo (1-Masculino, 2-Feminino): ");
                sexo = int.Parse(Console.ReadLine());
 
                Console.WriteLine("Estado civil (1-Casado, 2-Solteiro, 3-Viúvo, 4-Divorciado): ");
                estadoCivil = int.Parse(Console.ReadLine());
 
                Console.WriteLine("Rádio preferida (1-BHfm, 2-98fm, 3-Jovem Pan, 4-Itatiaia, 5-CDL): ");
                radio = int.Parse(Console.ReadLine());
 
                total++;
                somaIdades += idade;
 
                if (sexo == 1) homens++;
                else if (sexo == 2) mulheres++;
 
                if (radio >= 1 && radio <= 5) radios[radio]++;
                else radios[0]++;
 
                if (sexo == 2 && estadoCivil == 1 && radio == 1) mulheresCasadasBH++;
                if (sexo == 1 && idade > 21 && radio == 3) homensMaior21JP++;
 
                Console.WriteLine("Idade (0 para encerrar): ");
                idade = int.Parse(Console.ReadLine());
            }
 
            if (total == 0)
            {
                Console.WriteLine("Nenhum entrevistado.");
                return;
            }
 
            Console.WriteLine("\n--- Resultado ---");
            Console.WriteLine($"a) BHfm: {100.0 * radios[1] / total:f2}%");
            Console.WriteLine($"   98fm: {100.0 * radios[2] / total:f2}%");
            Console.WriteLine($"   Jovem Pan: {100.0 * radios[3] / total:f2}%");
            Console.WriteLine($"   Itatiaia: {100.0 * radios[4] / total:f2}%");
            Console.WriteLine($"   CDL: {100.0 * radios[5] / total:f2}%");
            Console.WriteLine($"   Outros: {100.0 * radios[0] / total:f2}%");
            Console.WriteLine($"b) Mulheres casadas que preferem BHfm: {mulheresCasadasBH}");
            Console.WriteLine($"c) Homens maiores de 21 anos que preferem Jovem Pan: {homensMaior21JP}");
            Console.WriteLine($"d) Média das idades: {(double)somaIdades / total:f2}");
            Console.WriteLine($"e) Homens: {100.0 * homens / total:f2}% | Mulheres: {100.0 * mulheres / total:f2}%");
        }
 
        static void Questao5()
        {
            TestaAluno.Executar();
        }
 
        static void Questao6()
        {
            TestaData.Executar();
        }
        static void Questao11()
        {
            Lista lista = new Lista();
            lista.Inserir(new NoLista(5));
            lista.Inserir(new NoLista(3));
            lista.Inserir(new NoLista(8));
            lista.Inserir(new NoLista(1));
 
            Console.WriteLine("Lista inicial:");
            lista.Imprimir();
 
            Console.WriteLine($"a) Média das chaves: {lista.GetMediaChaves():f2}");
            Console.WriteLine($"b) Quantidade de elementos: {lista.GetLength()}");
 
            NoLista no = lista.GetNo(1);
            Console.WriteLine("c) GetNo(1): " + (no != null ? no.chave.ToString() : "null"));
            no = lista.GetNo(10);
            Console.WriteLine("c) GetNo(10): " + (no != null ? no.chave.ToString() : "null"));
 
            NoLista maior = lista.GetMaiorChave();
            Console.WriteLine("d) Maior chave: " + (maior != null ? maior.chave.ToString() : "null"));
 
            Fila fila = new Fila();
            fila.Enfileirar(10);
            fila.Enfileirar(20);
            fila.Enfileirar(30);
            lista.AddItens(fila);
            Console.WriteLine("e) Depois de AddItens(fila):");
            lista.Imprimir();
 
            lista.TrocarChaves();
            Console.WriteLine("f) Depois de TrocarChaves():");
            lista.Imprimir();
        }
    }
 
    // Questão 4
    public class Aluno
    {
        private int matricula;
        private string nome;
        private double nota1, nota2, nota3;
 
        public Aluno(int mat, string nom, double n1, double n2, double n3)
        {
            matricula = mat;
            nome = nom;
            nota1 = n1;
            nota2 = n2;
            nota3 = n3;
        }
 
        public int GetMatricula()
        {
            return this.matricula;
        }
        public string GetNome()
        {
            return this.nome;
        }
        public double GetNotaFinal()
        {
            return (nota1 + nota2 + nota3) / 3;
        }
        public string GetResultado()
        {
            string msg = "Aprovado";
            double notaFinal = GetNotaFinal();
 
            if (notaFinal < 40)
            {
                msg = "Reprovado";
            }
            else if (notaFinal < 60)
            {
                msg = "Recuperação";
            }
 
            return msg;
        }
    }
 
    // Questão 5
    public class TestaAluno
    {
        public static void Executar()
        {
            int n;
            Console.WriteLine("Digite a quantidade de alunos: ");
            n = Convert.ToInt32(Console.ReadLine());
            Aluno[] alunos = new Aluno[n];
 
            for (int i = 0; i < alunos.Length; i++)
            {
                int mat;
                string nom;
                double n1, n2, n3;
                Console.WriteLine("Matrícula do " + (i + 1) + "º aluno: ");
                mat = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Nome: ");
                nom = Console.ReadLine();
                Console.WriteLine("1ª Nota: ");
                n1 = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("2ª Nota: ");
                n2 = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("3ª Nota: ");
                n3 = Convert.ToDouble(Console.ReadLine());
                alunos[i] = new Aluno(mat, nom, n1, n2, n3);
            }
 
            Console.WriteLine("\nDados dos alunos: ");
            for (int i = 0; i < alunos.Length; i++)
            {
                Console.WriteLine(alunos[i].GetNome() + "\t Resultado: " + alunos[i].GetResultado());
            }
        }
    }
 
    // Questão 6
    public class Data
    {
        private int dia, mes, ano;
 
        public Data(int dia, int mes, int ano)
        {
            this.dia = dia;
            this.mes = mes;
            this.ano = ano;
        }
 
        public void SetDia(int value)
        {
            dia = value;
        }
        public void SetMes(int value)
        {
            mes = value;
        }
        public void SetAno(int value)
        {
            ano = value;
        }
 
        public int GetDia()
        {
            return dia;
        }
        public int GetMes()
        {
            return mes;
        }
        public int GetAno()
        {
            return ano;
        }
 
        public string GetData()
        {
            return dia.ToString("00") + "/" + mes.ToString("00") + "/" + ano.ToString("0000");
        }
 
        public bool Valida()
        {
            int[] dias = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            if (ano % 400 == 0 || (ano % 4 == 0 && ano % 100 != 0)) // ano bissexto
                dias[1]++;
            if (ano < 1900 || ano > 2099)
                return false;
            if (mes < 1 || mes > 12)
                return false;
            if (dia < 1 || dia > dias[mes - 1])
                return false;
            return true;
        }
    }
 
    public class TestaData
    {
        public static void Executar()
        {
            Data d = new Data(5, 3, 2024);
            Console.WriteLine("Data: " + d.GetData() + " | Válida: " + d.Valida());
 
            d.SetDia(29);
            d.SetMes(2);
            d.SetAno(2023);
            Console.WriteLine("Data: " + d.GetData() + " | Válida: " + d.Valida()); // 2023 não é bissexto
 
            d.SetAno(2024);
            Console.WriteLine("Data: " + d.GetData() + " | Válida: " + d.Valida()); // 2024 é bissexto
 
            d.SetAno(1899);
            Console.WriteLine("Data: " + d.GetData() + " | Válida: " + d.Valida()); // fora da faixa
 
            Console.WriteLine("Dia: " + d.GetDia() + ", Mês: " + d.GetMes() + ", Ano: " + d.GetAno());
        }
    }
 
    // Questão 11
    public class NoLista
    {
        public int chave;
        public NoLista prox;
 
        public NoLista(int chave)
        {
            this.chave = chave;
            this.prox = null;
        }
    }
 
    public class Lista
    {
        private NoLista prim;
        private NoLista ult;
 
        public Lista()
        {
            prim = null;
            ult = null;
        }
 
        public void Inserir(NoLista item)
        {
            item.prox = null;
            if (prim == null)
            {
                prim = item;
                ult = item;
            }
            else
            {
                ult.prox = item;
                ult = item;
            }
        }
 
        public void Imprimir()
        {
            NoLista aux = prim;
            while (aux != null)
            {
                Console.Write(aux.chave + " ");
                aux = aux.prox;
            }
            Console.WriteLine();
        }
 
        public NoLista Pesquisar(int chave)
        {
            NoLista aux = prim;
            while (aux != null)
            {
                if (aux.chave == chave)
                {
                    return aux;
                }
                aux = aux.prox;
            }
            return null;
        }
 
        public void Remover(int chave)
        {
            NoLista anterior = null;
            NoLista atual = prim;
 
            while (atual != null && atual.chave != chave)
            {
                anterior = atual;
                atual = atual.prox;
            }
 
            if (atual == null)
            {
                return; // não achou
            }
 
            if (anterior == null)
            {
                prim = atual.prox; // removeu o primeiro
            }
            else
            {
                anterior.prox = atual.prox;
            }
 
            if (atual == ult)
            {
                ult = anterior; // removeu o último
            }
        }
 
        // a) média das chaves
        public double GetMediaChaves()
        {
            int soma = 0, cont = 0;
            NoLista aux = prim;
            while (aux != null)
            {
                soma += aux.chave;
                cont++;
                aux = aux.prox;
            }
 
            if (cont == 0)
            {
                return 0;
            }
            return (double)soma / cont;
        }
 
        // b) número de elementos
        public int GetLength()
        {
            int cont = 0;
            NoLista aux = prim;
            while (aux != null)
            {
                cont++;
                aux = aux.prox;
            }
            return cont;
        }
 
        // c) nó na posição indice (começa em 0)
        public NoLista GetNo(int indice)
        {
            if (indice < 0)
            {
                return null;
            }
 
            NoLista aux = prim;
            int i = 0;
            while (aux != null && i < indice)
            {
                aux = aux.prox;
                i++;
            }
            return aux; // null se a lista acabou antes
        }
 
        // d) nó com a maior chave
        public NoLista GetMaiorChave()
        {
            if (prim == null)
            {
                return null;
            }
 
            NoLista maior = prim;
            NoLista aux = prim.prox;
            while (aux != null)
            {
                if (aux.chave > maior.chave)
                {
                    maior = aux;
                }
                aux = aux.prox;
            }
            return maior;
        }
 
        // e) adiciona à lista os itens da fila (a fila é esvaziada)
        public void AddItens(Fila f)
        {
            while (!f.EstaVazia())
            {
                Inserir(new NoLista(f.Desenfileirar()));
            }
        }
 
        // f) cada nó recebe a chave do próximo; o último recebe a do primeiro
        public void TrocarChaves()
        {
            if (prim == null || prim.prox == null)
            {
                return; // com 0 ou 1 nó não há o que trocar
            }
 
            int primeiraChave = prim.chave;
            NoLista aux = prim;
            while (aux.prox != null)
            {
                aux.chave = aux.prox.chave;
                aux = aux.prox;
            }
            aux.chave = primeiraChave; // aux agora é o último nó
        }
    }
 
    // Fila mínima só para testar a questão 11 (troque pela sua, se já tiver uma)
    public class NoFila
    {
        public int chave;
        public NoFila prox;
 
        public NoFila(int chave)
        {
            this.chave = chave;
            this.prox = null;
        }
    }
 
    public class Fila
    {
        private NoFila prim;
        private NoFila ult;
 
        public bool EstaVazia()
        {
            return prim == null;
        }
 
        public void Enfileirar(int chave)
        {
            NoFila novo = new NoFila(chave);
            if (prim == null)
            {
                prim = novo;
            }
            else
            {
                ult.prox = novo;
            }
            ult = novo;
        }
 
        public int Desenfileirar()
        {
            int chave = prim.chave;
            prim = prim.prox;
            if (prim == null)
            {
                ult = null;
            }
            return chave;
        }
    }


}
