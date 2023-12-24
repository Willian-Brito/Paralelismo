using System.Diagnostics;

#region 1- Parallel

#region Exercicio 1 - Paralelismo de Metodos

// Console.WriteLine("Pressione ENTER para iniciar");
// Console.ReadLine();

// Invocar os métodos que vamos executar
// ExibirDias();
// ExibirMes();

// # Formas de uso:

// Parallel.Invoke(
//     new Action(ExibirDias),
//     new Action(ExibirMes)
// );

// Parallel.Invoke(
//     () => { ExibirDias(); },
//     () => { ExibirMes(); }
// );

// Aguardar a continuação do programa
// Console.WriteLine("\nO método Main foi encerrado. Telcle Enter");
// Console.ReadLine();

#region Metodos

static void ExibirDias()
{
    string[] diasArray = {"Segunda", "Terça", "Quarta", "Quinta", "Sexta", "Sabado", "Domingo"};

    foreach (var dia in diasArray)
    {
        Console.WriteLine($"Dia: {dia}");
        Thread.Sleep(1500);
    }
}

static void ExibirMes()
{
    string[] mesArray = {"Jan", "Fev", "Mar", "Abr", "Mai", "Jun", "Jul", "Ago", "Set", "Out", "Nov", "Dez"};

    foreach (var mes in mesArray)
    {
        Console.WriteLine($"Mes: {mes}");
        Thread.Sleep(1200);
    }
}
#endregion

#endregion

#region Exercicio 2 - Paralelismo com o For

// ProcessarLaco();
//PularLinha(2);

// Parallel.For(0,11,i => Console.WriteLine($"{i} \t"));

// Console.ReadLine();

// static void ProcessarLaco()
// {
//     for (int i = 0; i < 11; i++)
//     {
//         Console.WriteLine($"{i} Thread = {Thread.CurrentThread.ManagedThreadId} \t");
//         Thread.Sleep(500);
//     }
// }
#endregion

#region Exercicio 3 - Paralelismo com o Foreach

#region Objetos
var frutas = new List<string>();

frutas.Add("Maçã");
frutas.Add("Banana");
frutas.Add("Abacaxi");
frutas.Add("Melancia");
frutas.Add("Pera");
frutas.Add("Uva");
frutas.Add("Figo");
frutas.Add("Pessego");
frutas.Add("Laranja");
frutas.Add("Kiwi");
frutas.Add("Melão");
frutas.Add("Morango");
#endregion

// ProcessarFutas(frutas);
// PularLinha(1);
// ProcessarFrutasParallel(frutas);

// Console.ReadLine();

// static void ProcessarFutas(List<string> frutas)
// {
//     foreach (var fruta in frutas)
//     {
//         Console.WriteLine($"Fruta: {fruta} Thread = {Thread.CurrentThread.ManagedThreadId} \t");
//     }
// }

// static void ProcessarFrutasParallel(List<string> frutas)
// {
//     Parallel.ForEach(frutas, fruta => {
//         Console.WriteLine($"Fruta: {fruta} Thread = {Thread.CurrentThread.ManagedThreadId} \t");
//     });
// } 

#endregion

#endregion

#region 2- Task

#region Exercicio 1 - Sintaxe
// var task1 = Task.Factory.StartNew(() => FazerAlgo());
// // FazerAlgo();

static void FazerAlgo()
{
    Console.WriteLine("Executando uma tarefa => FazerAlgo()(task1)");
    Thread.Sleep(2000);
    Console.WriteLine("retornando...");
}
#endregion

#region Exercicio 2 - Esperando todas tarefas finalizarem WaitAll()

// var taskA = Task.Factory.StartNew(MetodoA);
// var taskB = Task.Factory.StartNew(MetodoB);

// Task.WaitAll(new Task[] {taskA, taskB});

// static void MetodoA()
// {
//     Console.WriteLine("Iniciando Metodo A");
//     Thread.Sleep(2000);
//     Console.WriteLine("Finalizando Metodo A");
// }

// static void MetodoB()
// {
//     Console.WriteLine("Iniciando Metodo B");
//     Thread.Sleep(3000);
//     Console.WriteLine("Finalizando Metodo B");
// }
#endregion

#region Exercicio 3 - Esperando as tarefas finalizarem individualmente WaitAny()

// var taskC = Task.Factory.StartNew(MetodoC);
// var taskD = Task.Factory.StartNew(MetodoD);

// Console.WriteLine($"Task C id = {taskC.Id}");
// Console.WriteLine($"Task D id = {taskD.Id}");

// var tarefas = new Task[] {taskC, taskD};
// int qualTask = Task.WaitAny(tarefas); // indice da tarefa que terminou primeiro.

// Console.WriteLine($"A Task de id {tarefas[qualTask].Id} acabou primeiro.");

//limites de tempo

// var CINCO_SEGUNDOS = 5000;

// taskC.Wait(CINCO_SEGUNDOS);
// taskD.Wait(CINCO_SEGUNDOS);
// Task.WaitAll(tarefas, CINCO_SEGUNDOS);
// Task.WaitAny(tarefas, CINCO_SEGUNDOS);

static void MetodoC()
{
    Console.WriteLine("Metodo C");
    Thread.SpinWait(100000000);
}

static void MetodoD()
{
    Console.WriteLine("Metodo D");
    Thread.SpinWait(100000000 / 2);
}
#endregion

#region Exercicio 4 - Utilizando método Run()

// ExibeInfoThread("Application");

// var task = Task.Run(() => ExibeInfoThread("Task"));

// task.Wait(); // espera finalizar a tarefa

// static void ExibeInfoThread(string app)
// {
//     Console.WriteLine($"{app} Thread ID: {Thread.CurrentThread.ManagedThreadId}");
// }
#endregion

#region Exercicio 5 - Utilizando método Run() com retorno

// var task = Task.Run(() => CalculaSoma(10, 20));

// var resultado = task.Result;

// Console.WriteLine($"Resultado: {resultado}");

// static int CalculaSoma(int n1, int n2)
// {
//     Thread.CurrentThread.Name = "Task CalculaSoma";
//     Console.WriteLine($"Thread: {Thread.CurrentThread.Name} \nID: {Thread.CurrentThread.ManagedThreadId}");
//     Thread.Sleep(2000);

//     return n1 + n2;
// }
#endregion

#region Exercicio 6 - Utilizando método Start()

// var task = new Task(() => FazAlgumaCoisa()); // TaskStatus: Created

// task.Start(); // TaskStatus: WaitingForActivation -> Running
// task.Wait();

// static void FazAlgumaCoisa()
// {
//     Console.WriteLine($"Task {Task.CurrentId} rodando na thread {Thread.CurrentThread.ManagedThreadId}");
//     Thread.Sleep(1000);

//     for(int i = 0; i <= 10; i++)
//         Console.WriteLine($"Iteração: {i}");    
// }
#endregion

#region Exercicio 7 - Cancelando uma Task com Status RanToCompletion

#region Primeira Tarefa

// Console.WriteLine("Tecle algo para iniciar a primeira tarefa\n");
// Console.ReadKey();

// var cts = new CancellationTokenSource();
// var tarefa = new Task<int>(() => MinhaTarefa("Task 1", 10, cts.Token), cts.Token);


// Console.WriteLine($"Status da tarefa = {tarefa.Status}");
// Console.WriteLine("\nEmitindo o token de cancelamento para a tarefa\n");

// cts.Cancel();

// Console.WriteLine($"Status da tarefa = {tarefa.Status}");
// Console.WriteLine("\nA primeira tarefa foi cancelada antes da execução\n");

// Console.WriteLine("Tecle algo para iniciar a segunda tarefa\n");
// Console.ReadKey();
#endregion

#region Segunfa Tarefa

// cts = new CancellationTokenSource();
// tarefa = new Task<int>(() => MinhaTarefa("Task 2", 10, cts.Token), cts.Token);

// tarefa.Start();

// for (int i = 0; i < 5; i++)
// {
//     Thread.Sleep(TimeSpan.FromSeconds(0.5));
//     Console.WriteLine($"Status da tarefa = {tarefa.Status}");
// }

// Console.WriteLine("\nEmitindo o token de cancelamento para a tarefa\n");
// cts.Cancel();

// for (int i = 0; i < 5; i++)
// {
//     Thread.Sleep(TimeSpan.FromSeconds(0.5));
//     Console.WriteLine($"Status da tarefa = {tarefa.Status}");
// }

// Console.WriteLine($"\nA tarefa foi completada com o status = {tarefa.Status}");
// Console.WriteLine($"\nA tarefa foi completada com o resultado = {tarefa.Result}");
// Console.ReadKey();
#endregion

#region MinhaTarefa
// static int MinhaTarefa(string nome, int segundos, CancellationToken token)
// {
//     Console.WriteLine(
//         $"Tarefa {nome} está rodando na thread de id " +
//         $"{Thread.CurrentThread.ManagedThreadId}\nÉ uma thread do Pool de Threads ? " +
//         $"{Thread.CurrentThread.IsThreadPoolThread}\n"
//     );

//     for(int i = 0; i < segundos; i++)
//     {
//         Thread.Sleep(TimeSpan.FromSeconds(2));

//         //verifica se o cancelamento foi soclicitado para esse token
//         if (token.IsCancellationRequested)
//             return -1;
//     }

//     return 42 * segundos;
// }
#endregion 

#endregion 

#region Exercicio 8 - Cancelando uma Task com Status Canceled

// Console.WriteLine("Tecle algo para iniciar a tarefa\n");
// Console.ReadKey();

// var cts = new CancellationTokenSource(); // Criando o Token de cancelamento
// CancellationToken ct = cts.Token; // Propagando o Token 

// var tarefa = Task.Run(() => MinhaTarefa(ct), cts.Token);


// Console.WriteLine($"Status da tarefa = {tarefa.Status}");
// Console.WriteLine("\nEmitindo o token de cancelamento para a tarefa\n");

// cts.Cancel();

// try
// {
//     await tarefa;
// }
// catch (OperationCanceledException ex)
// {
    
//     Console.WriteLine($"\n{nameof(OperationCanceledException)} lançada com: {ex.Message}");
//     Console.WriteLine($"\nStatus da tarefa: {tarefa.Status}");
// }
// finally
// {
//     cts.Dispose();
// }

// Console.ReadKey();

// static void MinhaTarefa(CancellationToken ct)
// {
//     // lança uma OperationCanceledException
//     // se o token para cancelar foi emitido
//     ct.ThrowIfCancellationRequested();

//     var continua = true;

//     while(continua)
//     {
//         // verifica se o cancelamento foi solicitado para esse token
//         if(ct.IsCancellationRequested)
//         {
//             // lança uma OperationCanceledException
//             // se o token para cancelar foi emitido
//             ct.ThrowIfCancellationRequested();
//         }
//     }
// }
#endregion

#region Exercicio 9 - Tratamento de Exceções

#region Exemplo 1

// Neste Exemplo a Exceção não é capturada porque a thread que está sendo tratada a tarefa (Main) 
// é diferente da thread que executa a tarefa

// Quando a tarefa ela é executada ela vai para fila de agendamento 
// e o fluxo de controle volta thread main 
// e a exceção é lançada em um escopo diferente da thread Main

// Console.WriteLine("Pressione algo para iniciar\n");
// Console.ReadKey();

// try 
// {
//     var task1 = new Task(() => 
//     {
//         throw new Exception("Task falhou... !");
//     });

//     Console.WriteLine($"Tarefa 1: {task1.Status} \n");
//     task1.Start();
//     Console.WriteLine($"Tarefa 1: {task1.Status} \n");
// }
// catch(Exception ex)
// {
//     Console.WriteLine($"{ex.Message}");
// }

// Console.WriteLine("Final do metodo");
// Console.ReadKey();
#endregion

#region Exemplo 2

// Os métodos Wait permitem o controle do fluxo de suas Tasks/Threads 
// em execução para retornar ao seu método de chamada.

// Fazem a thread principal parar até que a Task seja concluída 
// e permite capturar a exception

// Existe um método alternativo ao Wait que seria Task.ContinueWith
// que não bloqueia a thread principal

// Console.WriteLine("Pressione algo para iniciar\n");
// Console.ReadKey();

// try 
// {
//     var task2 = new Task(() => 
//     {
//         throw new Exception("Task falhou... !");
//     });

//     Console.WriteLine($"Tarefa 2: {task2.Status} \n");

//     task2.Start();
//     Task.WaitAll(task2);  // Aguarda até que todos os objetos Task fornecidos tenham concluído a execução.
//     // task2.Wait(); // Aguarda a tarefa consluir a execução.

//     Console.WriteLine($"Tarefa 2: {task2.Status} \n");
// }
// catch(Exception ex)
// {
//     Console.WriteLine($"{ex.Message}");
// }

// Console.WriteLine("Final do metodo");
// Console.ReadKey();

#endregion

#region Exemplo 3

// Neste modelo de tratamento de Exceções estamos utilizando
// a classe AggregateException que envolve cada Exception lançada pelas Tasks

// Essa Abordagem permite capturar várias exceções (assincronas) como apenas uma exceção.

// Agora podemos usar a propriedade InnerExceptions de AggregateException para examinar
// as exceções originais lançadas e manipular cada uma individualmente.

// Console.WriteLine("Pressione algo para iniciar\n");
// Console.ReadKey();

// try 
// {
//     var tarefas = new List<Task>(5);

//     for(int i = 0; i < 5; i++)
//     {
//         var tarefa = new Task(() => 
//         {
//             throw new Exception($"Task {Task.CurrentId} falhou... !");
//         });

//         tarefa.Start();
//         tarefas.Add(tarefa);
//     }

//     Task.WaitAll(tarefas.ToArray());
// }
// catch(AggregateException agex)
// {
//     Console.WriteLine("TPL Exceptions: ");
    
//     foreach (var ex in agex.InnerExceptions)
//         Console.WriteLine(ex.Message);
// }

// Console.WriteLine("Final do metodo");
// Console.ReadKey();

#endregion

#region Exemplo 4

// Nesta abordagem estamos tratando com Tasks que lançam exceptions
// sem bloquear a thread de chamada, tratando com as Exceptions dentro do escopo da Task

// Neste cenário o Console.WriteLine("Final do metodo") é executado primeiro pelo fato
// de que não estamos bloquando a thread de chamada

// Console.WriteLine("Pressione algo para iniciar\n");
// Console.ReadKey();

// for(int i = 0; i < 5; i++)
// {
//     var tarefa = new Task(() => 
//     {
//         try 
//         {
//             throw new Exception($"Task {Task.CurrentId} falhou... !");
//         }
//         catch(Exception ex)
//         {
//             Console.WriteLine(ex.Message);
//         }
//     });

//     tarefa.Start();
//     // Não espera a Task completar
// }

// Console.WriteLine("Final do metodo");
// Console.ReadKey();
#endregion

#endregion

#endregion

#region 3- PLINQ

#region Exercicio 1 - Execução Adiada

// int[] numeros = {1,2,3,4,5,6,7,8,9,10};
// int i = 3;

// // Este código não executa a consulta, Ele apenas capta a ideia da consulta em uma
// // estrutura de dados chamada árvore de expressão (expression tree).

// // Nesta arvore, contém as informações sobre a fonte de dados que deseja consultar (Array de inteiros),
// // a consulta que você quer fazer (Where) e o resultado que deseja retornar (itens <= 3).
// var resultado = numeros.Where(n => n <= i); 

// // i = 5;

// // Só acontece a execução quando a iteração é realizada no laço foreach
// foreach (var n in resultado) 
// {
//     Console.WriteLine(n);
// }

// Console.ReadLine();
#endregion 

#region Exercicio 2 - Execução Imediata

// Para realizar a execução imediata podemos usar os seguintes métodos:
// ToArray<T>(), ToList<>(), ToDictionary<T>(), ToLookup<T>(), Count, Sum, etc.

// Agora a expre~sao de consulta será executada imediatamente quando ToList() for chamado.
// E a variável resultado já vai conter os valores finais da consulta.

// int[] numeros = {1,2,3,4,5,6,7,8,9,10};
// int i = 3;

// // var resultado = (from n in numeros where n <= i select n).ToList();

// var resultado = numeros.Where(n => n <= i).ToList(); 

// i = 5;

// foreach (var n in resultado) 
// {
//     Console.WriteLine(n);
// }

// Console.ReadLine();

#endregion

#region Exercicio 3 - AsParallel(), AsOrdered()

// var alunos = Aluno.GetAlunos();
// Console.WriteLine("Pressione algo para iniciar...");
// Console.ReadLine();

// // var resultado = from aluno in alunos.AsParallel() 
// //                where aluno.Nome.StartsWith("C") 
// //               select aluno;

// // var resultado = alunos.AsParallel().Where(aluno => aluno.Nome.StartsWith("C"));
// var resultado = alunos.AsParallel().AsOrdered().Where(aluno => aluno.Nome.StartsWith("C"));

// foreach(var aluno in resultado) {  
// 	Console.WriteLine($"{aluno.Nome} - {aluno.Idade}");
// }

// Console.ReadKey();

#endregion

#region Exercicio 4 - Benchmark de Performance

#region Exemplo 1 - Não vale a pena Paralelismo
// int[] numeros = Enumerable.Range(0, short.MaxValue).ToArray();

// Console.WriteLine("Pressione algo para iniciar..");
// Console.ReadLine();

// var sw = new Stopwatch();

// sw.Start();
// var resultado_normal = numeros.Sum();
// Console.WriteLine($"Soma = {resultado_normal}");
// sw.Stop();
// Console.WriteLine($"Processamento Normal = {sw.Elapsed}");

// sw.Start();
// var resultado_paralelo = numeros.AsParallel().WithDegreeOfParallelism(2).Sum();
// Console.WriteLine($"Soma = {resultado_paralelo}");
// sw.Stop();
// Console.WriteLine($"Processamento Paralelo = {sw.Elapsed}");

// Console.ReadLine();
#endregion

#region Exemplo 2 - Vale a pena Paralelismo (foreach, Parallalel ForEach, ForAll)

// Console.WriteLine("Pressione algo para iniciar\n");
// Console.ReadKey();

// var numeros = Enumerable.Range(1, 10);

// LacoForeach(numeros);
// LacoParallelForeach(numeros);
// LacoParallelForAll(numeros);

// Console.ReadKey();

// static void LacoForeach(IEnumerable<int> numeros)
// {
//     var stopWatch = Stopwatch.StartNew();
    
//     foreach (var numero in numeros)
//     {
//         GastaTempo();
//         Console.WriteLine($" {numero}, Thread ID = {Thread.CurrentThread.ManagedThreadId}");
//     }

//     stopWatch.Stop();

//     Console.WriteLine($"\nlaço foreach = {stopWatch.Elapsed.TotalSeconds} segs\n");
// }

// static void LacoParallelForeach(IEnumerable<int> numeros)
// {
//     var stopWatch = Stopwatch.StartNew();

//     Parallel.ForEach(numeros, numero =>
//     {
//         GastaTempo();
//         Console.WriteLine($" {numero}, Thread ID = {Thread.CurrentThread.ManagedThreadId}");
//     });

//     stopWatch.Stop();

//     Console.WriteLine($"\nlaço Parallel.ForEach = {stopWatch.Elapsed.TotalSeconds} segs\n");
// }

// static void LacoParallelForAll(IEnumerable<int> numeros)
// {
//     var stopWatch = Stopwatch.StartNew();

//     numeros.AsParallel().ForAll(numero => {
//         GastaTempo();
//         Console.WriteLine($" {numero}, Thread ID = {Thread.CurrentThread.ManagedThreadId}");
//     });

//     stopWatch.Stop();

//     Console.WriteLine($"\nlaço ForAll = {stopWatch.Elapsed.TotalSeconds} segs\n");
// }

// static void GastaTempo()
// {
//     long total = 0;

//     for(int i = 1; i < 1000000000; i++)
//     {
//         total += i;
//     }
// }
#endregion

#region Exemplo 3 - Atribuindo numero máximo de threads

// Console.WriteLine("Pressione algo para iniciar\n");
// Console.ReadKey();

// LacoForeach();
// LacoParallelForeach();

// Console.ReadKey();

// static void LacoForeach()
// {
//     List<int> numeros = Enumerable.Range(1, 10).ToList();
//     var stopWatch = Stopwatch.StartNew();
    
//     foreach (var numero in numeros)
//     {
//         GastaTempo();
//         Console.WriteLine($" {numero}, Thread ID = {Thread.CurrentThread.ManagedThreadId}");
//     }

//     stopWatch.Stop();

//     Console.WriteLine($"\nlaço foreach = {stopWatch.Elapsed.TotalSeconds} segs\n");
// }

// static void LacoParallelForeach()
// {
//     var options = new ParallelOptions()
//     {
//         MaxDegreeOfParallelism = 4
//     };

//     List<int> numeros = Enumerable.Range(1, 10).ToList();
//     var stopWatch = Stopwatch.StartNew();

//     Parallel.ForEach(numeros, options, numero =>
//     {
//         GastaTempo();
//         Console.WriteLine($" {numero}, Thread ID = {Thread.CurrentThread.ManagedThreadId}");
//     });

//     stopWatch.Stop();

//     Console.WriteLine($"\nlaço Parallel.ForEach = {stopWatch.Elapsed.TotalSeconds} segs\n");
// }

// static void GastaTempo()
// {
//     long total = 0;

//     for(int i = 1; i < 100000000; i++)
//     {
//         total += i;
//     }
// }

#endregion

#endregion

#region Exercicio 5 - AsSequential

// string[] linguagens = {"Python", "Java", "JavaScrippt", "CSharp", "Bash", "C++", "Visual Basic"};

// var resultado = linguagens.AsParallel().AsOrdered()
//                           .Where(p => p.Contains('h'))
//                           .AsSequential().Where(p => p.Contains('r'))
//                           .Select(p => p);

// foreach (var linguagem in resultado)
// {
//     Console.WriteLine($"Qual a melhor Linguagem? : {linguagem}");
// }

// Console.ReadKey();
#endregion

#region Exercicio 6 - AsOrdered

// var numeros = Enumerable.Range(3,100);

// var parallel = numeros.AsParallel().AsOrdered().Where(num => num % 3 == 0);

// foreach(var item in parallel)
// {
//     Console.WriteLine($"{item}");
// }

// Console.ReadKey();
#endregion

#region Exercicio 7 - Tipos de Mesclagem

Console.WriteLine("Pressione algo para iniciar");
Console.ReadKey();

var numeros = Enumerable.Range(1, 50000);

var lista = numeros.AsParallel()
                   .WithMergeOptions(ParallelMergeOptions.FullyBuffered)
                   .Where(num => num % 5 == 0);

var stopWatch = Stopwatch.StartNew();

// lista.ForAll(item => Console.Write($"{item} | ")); // sempre sera NotBuffered

foreach(var resultado in lista)
{
    Console.Write($"{resultado} | ");
}

Console.WriteLine($"\nTempo gasto: {stopWatch.ElapsedMilliseconds} ms");
Console.ReadKey();

#endregion

#endregion

#region PularLinha
static void PularLinha(int numeroLinhas)
{
    for(int i = 0; i < numeroLinhas; i++)
    {
        Console.WriteLine("\n");
    }
}
#endregion